using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;
using DotNetHack.Game.Items.Equipment.Armor;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.UI.Windows
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowCharacterSheet : Window
    {
        /// <summary>
        /// Create a new character sheet for the supplied actor.
        /// </summary>
        /// <param name="aActor">The supplied actor</param>
        public WindowCharacterSheet(Actor aActor)
            : base("Character Sheet for \"" + aActor.Name + "\" (lvl." +
                aActor.Stats.Level + ")")
        {
            Character = aActor;

        }

        /// <summary>
        /// show the character sheet.
        /// </summary>
        public override void Show()
        {
            // called first
            base.Show();

            int y_coord = 0;

            var xStats = Character.WornArmour.CommutedStats(x => x.Condition > 0);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Mana:         {0}", Character.Stats.ManaPoints);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Health:       {0}", Character.Stats.HitPoints);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Armour:       {0}", Character.Stats.ArmourClass);

            y_coord++;

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Strength:     {0}+{1}", Character.Stats.Strength, xStats.Strength);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Perception:   {0}+{1}", Character.Stats.Perception, xStats.Perception);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Endurance:    {0}+{1}", Character.Stats.Endurance, xStats.Endurance);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Charisma:     {0}+{1}", Character.Stats.Charisma, xStats.Charisma);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Intelligence: {0}+{1}", Character.Stats.Intelligence, xStats.Intelligence);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Agility:      {0}+{1}", Character.Stats.Agility, xStats.Agility);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Luck:         {0}+{1}", Character.Stats.Luck, xStats.Luck);

            // skip 1
            y_coord = 0;

            int x_coord = 44;

            Console.SetCursorPosition(x_coord, 3 + y_coord++);

            new ProgressBar("mana", 44, 5,
                GameEngine.Player.Stats.ManaPercent).Show();

            new ProgressBar("hp", 44, 7,
                GameEngine.Player.Stats.HealthPercent).Show();

            x_coord = 22;

            /// Head, 0 
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            IArmour armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Head);
            if (armour != null)
                Console.WriteLine("Head: " + armour.Name);
            else Console.WriteLine("Head:       (none)");

            /// Neck, 1
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Neck);
            if (armour != null)
                Console.WriteLine("Neck: " + armour.Name);
            else Console.WriteLine("Neck:       (none)");
            armour = null;

            /// Chest, 2
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Chest);
            if (armour != null)
                Console.WriteLine("Chest:       " + armour.Name);
            else Console.WriteLine("Chest:      (none)");
            armour = null;

            /// Arms, 3
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Arms);
            if (armour != null)
                Console.WriteLine("Arms:        " + armour.Name);
            else Console.WriteLine("Arms:       (none)");
            armour = null;

            /// Hands, 4
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Hands);
            if (armour != null)
                Console.WriteLine("Hands:       " + armour.Name);
            else Console.WriteLine("Hands:      (none)");
            armour = null;

            /// Legs, 5
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Legs);
            if (armour != null)
                Console.WriteLine("Legs:        " + armour.Name);
            else Console.WriteLine("Legs:       (none)");
            armour = null;

            /// Feet, 6
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Feet);
            if (armour != null)
                Console.WriteLine("Feet:        " + armour.Name);
            else Console.WriteLine("Feet:       (none)");
            armour = null;

            /// LeftFinger, 7
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.LeftFinger);
            if (armour != null)
                Console.WriteLine("LeftFinger:  " + armour.Name);
            else
                Console.WriteLine("LeftFinger: (none)");
            armour = null;

            /// RightFinger, 8
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.RightFinger);
            if (armour != null)
                Console.WriteLine("RightFinger: " + armour.Name);
            else
                Console.WriteLine("RightFinger:(none)");

            armour = null;

            Console.ReadKey(true);
        }



        /// <summary>
        /// The character in this character sheet.
        /// </summary>
        Actor Character { get; set; }
    }
}
