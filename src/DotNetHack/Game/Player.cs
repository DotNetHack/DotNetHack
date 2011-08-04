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
            : this(aPlayerName, new Location3i(0, 0, 0))
        { }

        /// <summary>
        /// Player
        /// </summary>
        /// <param name="aPlayerName"></param>
        /// <param name="aLocation"></param>
        public Player(string aPlayerName, Location3i aLocation)
            : base()
        {
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
