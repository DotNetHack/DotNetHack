using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Events;
using DotNetHack.Game.Dungeon;
using DotNetHack.Game.Items;

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
            Stats.OnHealthChanged += new EventHandler(Stats_OnHealthChanged);
        }


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
