using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack;
using DotNetHack.UI;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Dungeon;
using DotNetHack.Game.Dungeon.Tiles;
using DotNetHack.Game.Items;
using DotNetHack.Game.Dungeon.Tiles.Traps;
using DotNetHack.Game.NPC.Monsters;
using System.Xml.Serialization.Persisted;
using DotNetHack.Game.Actions;
using DotNetHack.Game.Items.Equipment.Weapons;
using DotNetHack.Game.Events;
using System.IO;
using System.Threading;
using DotNetHack.Game.NPC;
using DotNetHack.UI.Windows;

namespace DotNetHack.Game
{
    /// <summary>
    /// Movement command delegate
    /// </summary>
    /// <param name="aUnitMovement">The unit movement</param>
    /// <returns>true if the movement was sucessful</returns>
    public delegate bool ProcessCommand(ConsoleKeyInfo input);

    /// <summary>
    /// Action commands are fired if and only if the player can act.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public delegate DAction ActionCommand(ConsoleKeyInfo input);

    /// <summary>
    /// GameEngine
    /// </summary>
    public partial class GameEngine : IDisposable
    {
        /// <summary>
        /// GameEngine
        /// </summary>
        /// <param name="aPlayer"></param>
        public GameEngine(Player aPlayer, Dungeon3 aStartDungeon)
        {
            Time = new DateTime(1688, 11, 16);
            Player = aPlayer;
            CurrentMap = aStartDungeon;

            // TODO: more junk
            foreach (var m in aStartDungeon.NonPlayerControlled)
                m.WieldedWeapons.CurrentWeapon = new ShortswordOfRending(null);
        }

        static bool Done = false;

        TargetSelector TargetSelect = null;

        /// <summary>
        /// Excecutes the game engine until !done.
        /// </summary>
        /// <param name="aFlags">Pass various flags to the game engine to
        /// adjust context, perform tests, etc. </param>
        /// <param name="args">The same args from entry point (ref)</param>
        public void Run(EngineRunFlags aFlags, ref string[] args)
        {
            GameEngine.RunFlags = aFlags;

            try
            {
                Initialize();

                while (!Done)
                {
                    Graphics.CursorToLocation(0, 0);

                    var input = Console.ReadKey(true);

                    if (!ProcessCommand(input))
                        continue;

                    TargetSelect = null;

                    // TODO: Make a distintion between action(s)
                    // and general commands. ProcessAction(input);

                    Update();

                    CurrentMap.Render(Player.Location);

                    UI.Graphics.Display.ShowStatsBar(Player);

                    Player.Draw();

                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                if (OnException != null)
                    OnException(this, new ErrorEventArgs(ex));
            }
            finally { Dispose(); }
        }

        /// <summary>
        /// processes all incoming commands and triggers associated actions and events.
        /// </summary>
        /// <param name="input">raw input</param>
        /// <returns></returns>
        bool ProcessCommand(ConsoleKeyInfo input)
        {
            bool isMoveCommand = false;
            bool isTargetCommand = false;

            Func<ITile, bool> aRestriction = null;

            Tile nMoveFrom = CurrentMap.GetTile(Player);
            Tile nMoveTo = null;

            Location3i UnitMovement = new Location3i(0, 0, 0);

            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    isMoveCommand = true;
                    UnitMovement.X--; break;
                case ConsoleKey.RightArrow:
                    isMoveCommand = true;
                    UnitMovement.X++; break;
                case ConsoleKey.UpArrow:
                    isMoveCommand = true;
                    UnitMovement.Y--; break;
                case ConsoleKey.DownArrow:
                    isMoveCommand = true;
                    UnitMovement.Y++; break;
                case ConsoleKey.OemPeriod:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        isMoveCommand = true;
                        aRestriction = new Func<ITile, bool>(
                            x => x.TileType == TileType.StairsDown);
                        UnitMovement.D--;
                    } break;
                case ConsoleKey.OemComma:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        isMoveCommand = true;
                        aRestriction = new Func<ITile, bool>(
                            x => x.TileType == TileType.StairsUp);
                        UnitMovement.D++;
                    }
                    else
                    {
                        // TODO: move this
                        DAction a = new ActionPickup(Player,
                            CurrentMap.GetTile(Player).Items);
                        a.Perform();
                    }

                    break;

                case ConsoleKey.P:
                    {
                        Player.WornArmour.PutOn(
                            Player.Inventory.Armour.First(), true);
                        break;
                    }
                case ConsoleKey.W:
                    {
                        Player.WieldedWeapons.Wield(
                            Player.Inventory.Weapons.First(), true);
                        break;
                    }
                case ConsoleKey.Q:
                    {
                        var potion = Player.Inventory.Potions.First();
                        if (potion != null)
                            potion.Quaff(Player);
                        break;
                    }
                case ConsoleKey.Tab:
                    isTargetCommand = true;
                    if (TargetSelect == null)
                        TargetSelect = new TargetSelector(
                        CurrentMap.NonPlayerControlled.Where(
                            n => n.Distance(Player) < 10));
                    if (TargetSelect.HasTargets)
                    {
                        var currentTarget = TargetSelect.NextTarget();
                        var currentTargetLocation = currentTarget.Location;
                        char currentSymbol = currentTarget.G;
                        UI.Graphics.CursorToLocation(currentTargetLocation);
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Graphics.CursorToLocation(currentTargetLocation);
                        Console.Write(currentSymbol);
                    }

                    break;

                case ConsoleKey.C:

                    // create a new character sheet for the player
                    WindowCharacterSheet characterSheet =
                        new WindowCharacterSheet(Player);

                    characterSheet.Show();

                    CurrentMap.DungeonRenderer.ClearBuffer();

                    break;

                case ConsoleKey.O:
                    {
                        Door tmpDoor;
                        if (TryOpenCloseDoor(Player, Input.GetDirection(), out tmpDoor))
                        {
                            if (OnDoorOpenedClosed != null)
                                OnDoorOpenedClosed(this, new DoorEventArgs(Player, tmpDoor));
                        }
                    } break;
                case ConsoleKey.Escape:
                    Done = true;
                    break;
            }

            if (isTargetCommand)
                return false;

            if (isMoveCommand)
                if (TryMove(Player, Player.Location + UnitMovement, out nMoveTo, aRestriction))
                {
                    if (OnPlayerMoved != null)
                        OnPlayerMoved(this, new MoveEventArgs(Player, nMoveFrom, nMoveTo));
                }
                else
                {
                    NPC.NonPlayerControlled tmpNPC = CurrentMap.GetNPC(
                        Player.Location + UnitMovement);
                    if (tmpNPC != null)
                        new ActionMeleeAttack(Player, tmpNPC).Perform();
                }

            return true;
        }

        public ActionCommand ProcessAction(ConsoleKeyInfo input)
        {
            return null;
        }

        /// <summary>
        /// Occurs when errors are thrown.
        /// </summary>
        public event ErrorEventHandler OnException;

        /// <summary>
        /// Occurs specifically when a player moves onto a new tile.
        /// </summary>
        public event EventHandler<MoveEventArgs> OnPlayerMoved;

        /// <summary>
        /// Occurs when any actor, including the play moves onto a new tile.
        /// </summary>
        public event EventHandler<MoveEventArgs> OnActorMoved;

        /// <summary>
        /// occurs when *any* door is opended or closed.
        /// </summary>
        public event EventHandler<DoorEventArgs> OnDoorOpenedClosed;

        /// <summary>
        /// Occurs when DoSound is called.
        /// </summary>
        public static event EventHandler<SoundEventArgs> OnSound;

        /// <summary>
        /// load monsters, weapons, potions.
        /// </summary>
        public bool Initialize()
        {
            OnActorMoved += new EventHandler<MoveEventArgs>(GameEngine_OnActorMoved);
            OnPlayerMoved += new EventHandler<MoveEventArgs>(GameEngine_OnPlayerMoved);
            OnException += new ErrorEventHandler(GameEngine_OnException);

            try { MonsterStore = Persisted.Read<List<Monster>>(R.MonsterFile); }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// triggered when any actor moves to a *different* tile.
        /// <remarks>
        /// - triggers traps,
        /// ...
        /// - triggers clear/rerender of location.
        /// </remarks>
        /// </summary>
        /// <param name="sender">the event sender</param>
        /// <param name="e">the move event argument.</param>
        void GameEngine_OnActorMoved(object sender, MoveEventArgs e)
        {
            if (e.MoveToTile.TileFlags == TileFlags.Trap)
                ((Trap)e.MoveToTile).OnTrapTriggeredEvent(new Trap.TrapEventArgs(e.ActorInvolved));

            CurrentMap.DungeonRenderer.ClearLocation(Player.Location);
        }

        /// <summary>
        /// occurs specifically when the player moves to a new tile
        /// <remarks>used generally for diplay and ui purposes.</remarks>
        /// </summary>
        /// <param name="sender">the event sender</param>
        /// <param name="e">the event argument</param>
        void GameEngine_OnPlayerMoved(object sender, MoveEventArgs e)
        {
            if (e.MoveToTile.TileFlags.HasFlag(TileFlags.Trap))
            {
                Trap t = ((Trap)e.MoveToTile);

                t.OnTrapTriggeredEvent(new Trap.TrapEventArgs(Player));
            }
            else if (e.MoveToTile.HasItems)
            {
                if (e.MoveToTile.Items.Count == 1)
                    UI.Graphics.Display.ShowMessage(e.MoveToTile.Items.First<IItem>().Name);
                else
                    UI.Graphics.Display.ShowMessage("{0}, {1} here",
                        e.MoveToTile.Items.Count,
                        Speech.Pluralize("item", e.MoveToTile.Items.Count));
            }
        }

        /// <summary>
        /// Occurs when an exception is caught.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        void GameEngine_OnException(object sender, ErrorEventArgs ex)
        {
            UI.Graphics.MessageBox.Show("DNH Exception", ex.GetException());
            ex.GetException().Write(R.ExceptionFile);
        }

        /// <summary>
        /// Cleanup after the game-engine runs.
        /// </summary>
        public void Dispose()
        {
            Done = false;
        }

        /// <summary>
        /// Try to open what *may* be a door at the given location.
        /// <remarks>in the event there is a door the out param is populated.</remarks>
        /// </summary>
        /// <param name="aActor">the actor opening the door</param>
        /// <param name="aLocation">the door location</param>
        /// <returns>true if the door has been opened.</returns>
        public bool TryOpenCloseDoor(Actor aActor, Location3i aLocation, out Door tmpDoor)
        {
            tmpDoor = null;

            if (!CurrentMap.CheckBounds(aActor.Location + aLocation))
                return false;

            tmpDoor = (Door)CurrentMap.GetTile(aActor.Location + aLocation);

            if (tmpDoor.TileFlags == TileFlags.Door)
            {
                if (!tmpDoor.IsLocked)
                {
                    if (tmpDoor.IsOpen)
                        tmpDoor.CloseDoor();
                    else tmpDoor.OpenDoor();
                }
                else
                {
                    if (Player.KeyChain.CanUnLock(tmpDoor))
                    {
                        if (tmpDoor.IsOpen)
                            tmpDoor.CloseDoor();
                        else tmpDoor.OpenDoor();
                    }
                    else return false;
                }
            }

            return true;
        }

        /// <summary>
        /// - check the boundary ? return false
        /// - get the tile (set as out)
        /// - check the clipping ? return false
        /// - change actor location
        /// - return true
        /// <remarks>in the event the tile is invalid, expect oMoveToTile to be null.</remarks>
        /// </summary>
        /// <param name="aObject">the aObject being moved</param>
        /// <param name="aLocation">the location the actor is moving to</param>
        /// <param name="oMoveToTile">the tile the actor <c>moved</c> to. (out)</param>
        /// <returns>true on success</returns>
        private bool TryMove(IHasLocation aObject, Location3i aLocation,
            out Tile oMoveToTile, Func<ITile, bool> aPredicate = null)
        {
            oMoveToTile = null;

            if (!CurrentMap.CheckBounds(aLocation))
                return false;

            oMoveToTile = CurrentMap.GetTile(aLocation);

            if (oMoveToTile == null)
                return false;
            else if (oMoveToTile.Impassable)
                return false;

            if (aPredicate != null)
                if (!aPredicate(oMoveToTile))
                    return false;

            if (!CurrentMap.IsPassable(aLocation))
                return false;

            aObject.Location = aLocation;

            return true;
        }

        /// <summary>
        /// performs various stateful updates to game objects.
        /// </summary>
        public void Update()
        {
            // Perform regeneration step for player.
            Player.RegenerateHealth();
            Player.RegenerateMagika();
            Player.ApplyEffects();


            // Remove all NPC's that are dead, then run the ones that aren't (yet).
            CurrentMap.NonPlayerControlled.RemoveAll(x => x.Dead);
            foreach (var npc in CurrentMap.NonPlayerControlled)
            {
                npc.ApplyEffects();
                npc.Execute(Player);
            }
        }

        /// <summary>
        /// DoSound, generates a sound. Calls subscribed listeners.
        /// </summary>
        /// <param name="aSound">The sound that is generated.</param>
        public static void DoSound(Sound aSound)
        {
            if (OnSound != null)
                OnSound(null, new SoundEventArgs(aSound));
        }

        /// <summary>
        /// Time
        /// </summary>
        public static DateTime Time { get; private set; }

        /// <summary>
        /// Player
        /// </summary>
        public static Player Player { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public enum TimeScale
        {
            World, Dungeon,
        }

        /// <summary>
        /// CurrentMap
        /// </summary>
        private Dungeon3 CurrentMap { get; set; }

        /// <summary>
        /// RunFlags
        /// </summary>
        public static EngineRunFlags RunFlags { get; set; }

        /// <summary>
        /// MonsterStore
        /// </summary>
        public static List<Monster> MonsterStore { get; set; }

        /// <summary>
        /// EngineRunFlags
        /// </summary>
        [Flags]
        public enum EngineRunFlags { Normal, Editor, Debug }
    }
}
