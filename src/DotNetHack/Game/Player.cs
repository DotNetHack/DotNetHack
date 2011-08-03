using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Events;
using DotNetHack.Game.Dungeon;
using DotNetHack.Game.Items;
using DotNetHack.Game.Items.Equipment.Armour;

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
            WornArmour = new ArmourWorn();
            WornArmour.OnFinishedDressingManeuver += 
                new EventHandler<ArmourWorn.WearEventArgs>(WornArmour_OnFinishedDressingManeuver);
            #endregion

            Stats.OnHealthChanged += new EventHandler(Stats_OnHealthChanged);
        }

        /// <summary>
        /// occurs when the a dressing maneuver is completed.
        /// </summary>
        /// <param name="sender">the event sender</param>
        /// <param name="e">the event args</param>
        void WornArmour_OnFinishedDressingManeuver(object sender, ArmourWorn.WearEventArgs e)
        {
            UI.Graphics.Display.ShowMessage(
                "You are now wearing {0}.", e.Armour.Name);
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

        /// <summary>
        /// The armour that is worn by the player.
        /// </summary>
        public ArmourWorn WornArmour { get; set; }
    }
}
