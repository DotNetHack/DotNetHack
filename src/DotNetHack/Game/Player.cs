using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Events;
using DotNetHack.Game.Dungeon;
using DotNetHack.Game.Items;
using DotNetHack.Game.Items.Equipment.Armour;
using DotNetHack.Game.Items.Equipment.Weapons;
using DotNetHack.Utility.Media;

namespace DotNetHack.Game
{
    /// <summary>
    /// Player
    /// </summary>
    public class Player : Actor, IDrawable
    {
        /// <summary>
        /// Player
        /// </summary>
        /// <param name="aPlayerName"></param>
        public Player(string aPlayerName)
            : this(aPlayerName, new Location3i(0, 0, 0)) { }

        /// <summary>
        /// GameEngine_OnSound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GameEngine_OnSound(object sender, SoundEventArgs e)
        {
            if (e.Sound.IsSoundAmbient)
                UI.Graphics.Display.ShowSound(e.Sound);
            else if (Stats.Perception >= e.Distance(this))
                UI.Graphics.Display.ShowSound(e.Sound);
            SoundController.Instance.PlaySound(e.Description);
        }

        /// <summary>
        /// Player
        /// </summary>
        /// <param name="aPlayerName"></param>
        /// <param name="aLocation"></param>
        public Player(string aPlayerName, Location3i aLocation)
            : base()
        {
            GameEngine.OnSound += new EventHandler<SoundEventArgs>(GameEngine_OnSound);

            // Create the players key-chain
            KeyChain = new KeyChain();

            // Create the players wallet.
            Wallet = new Currency(0);

            G = '@';
            Name = aPlayerName;
            Location = aLocation;
            C = new Colour() { FG = ConsoleColor.Gray };
            Stats = new Stats()
            {
                Agility = 2,
                Charisma = 4,
                Endurance = 7,
                Intelligence = 7,
                Luck = 4,
                Perception = 2,
                Strength = 7,
            };

            Initialize();
        }

        /// <summary>
        /// should be called after stats exist.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            #region worn armour

            WornArmour.OnFinishedDressingManeuver += new EventHandler<EquipmentEventArgs<ArmourWorn.DressingActionType, IArmour>>(WornArmour_OnFinishedDressingManeuver);
            #endregion

            #region worn weapons
            WieldedWeapons.OnWieldWeaponEvent += new EventHandler<EquipmentEventArgs<WeaponsWielded.WieldEventType, IWeapon>>(WieldedWeapons_OnWieldWeaponEvent);
            #endregion

            Stats.OnHealthChanged += new EventHandler(Stats_OnHealthChanged);
        }

        /// <summary>
        /// Eat
        /// </summary>
        public void Eat(IFood aFood)
        {
            aFood.Eat();
        }

        /// <summary>
        /// fires when the wield status of a weapon changes.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event args (equipment)</param>
        void WieldedWeapons_OnWieldWeaponEvent(object sender, EquipmentEventArgs<WeaponsWielded.WieldEventType, IWeapon> e)
        {
            switch (e.EquipEventType)
            {
                case WeaponsWielded.WieldEventType.Sheath:
                    Inventory.Push(e.EquipmentInvolved);
                    UI.Graphics.Display.ShowMessage("The weapon {0} has been sheathed.",
                        e.EquipmentInvolved.Name);
                    break;
                case WeaponsWielded.WieldEventType.Wield:
                    Inventory.Remove(e.EquipmentInvolved);
                    UI.Graphics.Display.ShowMessage(string.Format("You are now wielding {0}.",
                        e.EquipmentInvolved.Name));

                    if (e.EquipmentInvolved.WeaponSubType.HasFlag(WeaponSubType.ShortBlade))
                        Sound.DoSound(Sound.SoundEventType.WieldShortSowrd);
                    else if (e.EquipmentInvolved.WeaponSubType.HasFlag(WeaponSubType.LongBlade))
                        Sound.DoSound(Sound.SoundEventType.WieldLongSword);
                    else if (e.EquipmentInvolved.WeaponSubType.HasFlag(WeaponSubType.Blunt))
                        Sound.DoSound(Sound.SoundEventType.WieldBluntWeapon);

                    /*
                    switch (e.EquipmentInvolved.WeaponType)
                    {
                        case WeaponType.Rapier:
                        case WeaponType.Stiletto:
                        case WeaponType.Shortsword:
                        case WeaponType.Scimitar:
                        case WeaponType.Sabre:
                        case WeaponType.Machete:
                        case WeaponType.Kris:
                            Sound.DoSound(Sound.SoundEventType.WieldShortSowrd);
                            break;

                        case WeaponType.BattleAxe:
                        case WeaponType.Claymore:
                        case WeaponType.Flamberge:
                        case WeaponType.Longsword:
                        case WeaponType.Pike:
                        case WeaponType.Swordstaff:
                        case WeaponType.Halberd:
                            Sound.DoSound(Sound.SoundEventType.WieldLongSword);
                            break;

                        case WeaponType.Club:
                        case WeaponType.Flail:
                        case WeaponType.Mace:
                        case WeaponType.Maul:
                        case WeaponType.MorningStar:
                            Sound.DoSound(Sound.SoundEventType.WieldBluntWeapon);
                            break;
                    }*/
                    break;
            }
        }

        /// <summary>
        /// occurs when a dressing meneuver is completed.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event arguemtn (equipment)</param>
        void WornArmour_OnFinishedDressingManeuver(object sender, EquipmentEventArgs<ArmourWorn.DressingActionType, IArmour> e)
        {
            switch (e.EquipEventType)
            {
                case ArmourWorn.DressingActionType.PutOn:
                    Inventory.Remove(e.EquipmentInvolved);
                    UI.Graphics.Display.ShowMessage(
                        "You are now wearing {0}.",
                        e.EquipmentInvolved.Name);
                    break;
                case ArmourWorn.DressingActionType.TakeOff:
                    Inventory.Push(e.EquipmentInvolved);
                    UI.Graphics.Display.ShowMessage(
                        "You are no longer wearing {0}.",
                        e.EquipmentInvolved.Name);
                    break;
            }
        }

        /// <summary>
        /// CommutedStats
        /// </summary>
        public StatsBase CommutedStats()
        {
            // commute worn armour stats
            StatsBase statsBase = WornArmour.CommutedStats(a => a.Condition > 0);

            // commute effect stats
            foreach (var effect in EffectStack)
                if (effect.EffectedStats != null)
                    statsBase = statsBase + effect.EffectedStats;

            return statsBase;
        }

        /// <summary>
        /// Occurs when the players health changes, this could be bad.
        /// </summary>
        /// <param name="sender">the event sender</param>
        /// <param name="e">event args (none really since stats will be inspected)</param>
        void Stats_OnHealthChanged(object sender, EventArgs e)
        {
            // WARNING: hack for now, until actually die logic can be made.
            if (Stats.Health <= 0)
                throw new DNHackException("you died!");
        }

        /// <summary>
        /// DLV
        /// </summary>
        public int DungeonLevel { get { return Location.D; } }

        /// <summary>
        /// The players key-chain
        /// </summary>
        public KeyChain KeyChain { get; set; }

        /// <summary>
        /// Wallet
        /// </summary>
        public Currency Wallet { get; set; }
    }
}
