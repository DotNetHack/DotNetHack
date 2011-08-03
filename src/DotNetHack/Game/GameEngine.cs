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

namespace DotNetHack.Game
{
    /// <summary>
    /// GameEngine
    /// </summary>
    public class GameEngine
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
        }

        /// <summary>
        /// Run
        /// </summary>
        public void Run(EngineRunFlags aFlags)
        {
            // set engine run flags
            GameEngine.RunFlags = aFlags;

            // CursorVisible
            Console.CursorVisible = false;

            // set to true for exit.
            bool done = false;

            /// Load all monsters.
            try { MonsterStore = Persisted.Read<List<Monster>>(R.MonsterFile); }
            catch { UI.Graphics.MessageBox.Show("DotNetHack", "Monster file not found!"); }

            while (!done)
            {
            redo_input:
                Graphics.CursorToLocation(1, 1); // So as not to pile up blanks.
                ConsoleKeyInfo input = Console.ReadKey();
                Location3i UnitMovement = new Location3i(0, 0, 0);
                Tile nPlayerTile = CurrentMap.GetTile(Player.Location);

                switch (input.Key)
                {
                    default:
                        continue;
                    case ConsoleKey.LeftArrow:
                        UnitMovement.X--; break;
                    case ConsoleKey.RightArrow:
                        UnitMovement.X++; break;
                    case ConsoleKey.UpArrow:
                        UnitMovement.Y--; break;
                    case ConsoleKey.DownArrow:
                        UnitMovement.Y++; break;
                    case ConsoleKey.OemPeriod:
                        if (nPlayerTile.TileType == TileType.StairsUp)
                            UnitMovement.D--; break;
                    case ConsoleKey.P:
                        {
                            // TODO: allow for dynamic selection of what to put on,
                            // should be done via Func<IArmour, bool> for selecting
                            // from the greater list.
                            //
                            // perhaps genericize the dropdown concept.
                            var p = Player.Inventory.Armour.First<IArmour>();
                            Player.WornArmour.PutOn(p, true);
                            break;

                        }
                    case ConsoleKey.W:
                        {
                            // TODO: allow for dynamic selection of what to put on,
                            // should be done via Func<IWeapon, bool> for selecting.
                            Player.WieldedWeapons.Wield(
                                Dice.RandomChoice<IWeapon>(
                                Player.Inventory.Weapons.ToArray()));
                            break;
                        }
                    case ConsoleKey.OemComma:
                        if (input.Modifiers == ConsoleModifiers.Shift)
                        {
                            if (nPlayerTile.TileType == TileType.StairsDown)
                                UnitMovement.D++; break;
                        }
                        else
                        {
                            Tile nTileUnderPlayer = CurrentMap.GetTile(Player.Location);
                            while (nTileUnderPlayer.HasItems)
                            {
                                IItem cItem = nTileUnderPlayer.Items.Pop();

                                // switch by item type
                                switch (cItem.ItemType)
                                {
                                    default:
                                        // TODO: Inventory needs events.
                                        Player.Inventory.Push(cItem);
                                        break;
                                    // Occurs when a player picks up a key.
                                    case ItemType.Key:
                                        Player.KeyChain.AddKey((Key)cItem);
                                        break;
                                    // Occurs when a player picks up currency.
                                    case ItemType.Currency:
                                        Player.Wallet += (Currency)cItem;
                                        break;
                                }
                            }

                            CurrentMap.DungeonRenderer.ClearLocation(Player.Location);
                        }
                        break;

                    // If the player has potions, then take one off the top shelf 
                    // and drink it.
                    // TODO: Allow player to select exactly which potion they'd like to quaff.
                    case ConsoleKey.Q:
                        {
                            // TODO: allow for dynamic selection of potions to quaff.

                            var p = Player.Inventory.Potions.First<IPotion>();

                            Player.Inventory.Remove(p);

                            p.Quaff(Player);

                            break;
                        }
                    case ConsoleKey.O:
                        {
                            ConsoleKeyInfo tmpInput;
                            Location3i tmpUnitLocation = new Location3i(0, 0, 0);
                            switch (Input.Filter(x => x.Key == ConsoleKey.LeftArrow ||
                                x.Key == ConsoleKey.RightArrow ||
                                x.Key == ConsoleKey.UpArrow ||
                                x.Key == ConsoleKey.DownArrow, out tmpInput).Key)
                            {
                                case ConsoleKey.RightArrow:
                                    tmpUnitLocation.X++; break;
                                case ConsoleKey.LeftArrow:
                                    tmpUnitLocation.X--; break;
                                case ConsoleKey.UpArrow:
                                    tmpUnitLocation.Y--; break;
                                case ConsoleKey.DownArrow:
                                    tmpUnitLocation.Y++; break;
                            }
                            if (!CurrentMap.CheckBounds(
                                Player.Location + tmpUnitLocation))
                                goto redo_input;
                            Tile nDoorTile = CurrentMap.GetTile(Player.Location + tmpUnitLocation);
                            if (nDoorTile.TileFlags == TileFlags.Door)
                            {
                                Door tmpDoor = (Door)nDoorTile;

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
                                }
                            }

                            break;
                        }
                    case ConsoleKey.Escape:
                        done = true;
                        break;
                }

                if (!CurrentMap.CheckBounds(Player.Location + UnitMovement))
                    goto redo_input;

                var tmpMonster = CurrentMap.MonsterThere(Player.Location + UnitMovement);

                if (tmpMonster != null)
                {
                    new ActionMeleeAttack(Player, tmpMonster).Perform();
                    Time = Time.AddSeconds(3);
                }

                Tile nMoveToTile = CurrentMap.GetTile(Player.Location + UnitMovement);
                if (nMoveToTile.TileType == TileType.Wall)
                    goto redo_input;
                else if (nMoveToTile.TileFlags == TileFlags.Trap)
                {
                    var nTrapTile = (Trap)nMoveToTile;
                    nTrapTile.OnTrapTriggeredEvent(
                        new Trap.TrapEventArgs(Player));
                }
                else if (nMoveToTile.TileFlags == TileFlags.Door)
                    if (((Door)nMoveToTile).IsClosed)
                        goto redo_input;

                if (nMoveToTile.HasItems)
                {
                    if (nMoveToTile.Items.Count == 1)
                        UI.Graphics.Display.ShowMessage(nMoveToTile.Items.First<IItem>().Name);
                    else
                        UI.Graphics.Display.ShowMessage("{0}, {1} here",
                            nMoveToTile.Items.Count,
                            Speech.Pluralize("item", nMoveToTile.Items.Count));
                }

                // Apply the unit movement.
                if (CurrentMap.IsPassable(Player.Location + UnitMovement))
                {
                    Player.Location += UnitMovement;
                    Time = Time.AddSeconds(6);
                }

                Update();

                CurrentMap.Render(Player.Location);

                Player.Draw();
            }
        }

        public void Update()
        {
            // Perform regeneration step for player.
            Player.RegenerateHealth();
            Player.RegenerateMagika();

            // Show the status bar.
            UI.Graphics.Display.ShowStatsBar(Player);

            // Remove all NPC's that are dead, then run the ones that aren't (yet).
            CurrentMap.NonPlayerControlled.RemoveAll(x => x.Dead);
            foreach (var npc in CurrentMap.NonPlayerControlled)
                npc.Execute(Player);
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
