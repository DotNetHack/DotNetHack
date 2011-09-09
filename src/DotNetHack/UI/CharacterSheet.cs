using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;
using DotNetHack.Game.Items.Equipment.Armor;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class CharacterSheet : Window
    {
        /// <summary>
        /// Create a new character sheet for the supplied actor.
        /// </summary>
        /// <param name="aActor">The supplied actor</param>
        public CharacterSheet(Actor aActor)
            : base("Character Sheet for \"" + aActor.Name + "\" (lvl." +
                aActor.Stats.Level + ")")
        { Character = aActor; }

        /// <summary>
        /// show the character sheet.
        /// </summary>
        public override void Show()
        {
            // called first
            base.Show();

            int y_coord = 0;

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Mana:         {0}", Character.Stats.ManaPoints);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Health:       {0}", Character.Stats.HitPoints);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Armour:       {0}", Character.Stats.ArmourClass);

            y_coord++;

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Strength:     {0}", Character.Stats.Strength);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Perception:   {0}", Character.Stats.Perception);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Endurance:    {0}", Character.Stats.Endurance);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Charisma:     {0}", Character.Stats.Charisma);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Intelligence: {0}", Character.Stats.Intelligence);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Agility:      {0}", Character.Stats.Agility);

            Console.SetCursorPosition(3, 3 + y_coord++);
            Console.Write("Luck:         {0}", Character.Stats.Luck);

            // skip 1
            y_coord = 0;

            int x_coord = 22;

            /// Head
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            IArmour armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Head);
            if (armour != null)
                Console.WriteLine("Head: " + armour.Name);
            else Console.WriteLine("Head:       (none)");

            /// Neck
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Neck);
            if (armour != null)
                Console.WriteLine("Neck: " + armour.Name);
            else Console.WriteLine("Neck:       (none)");
            armour = null;

            /// Chest
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Chest);
            if (armour != null)
                Console.WriteLine("Chest:       " + armour.Name);
            else Console.WriteLine("Chest:      (none)");
            armour = null;

            /// Arms
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Arms);
            if (armour != null)
                Console.WriteLine("Arms:        " + armour.Name);
            else Console.WriteLine("Arms:       (none)");
            armour = null;

            /// Hands
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Hands);
            if (armour != null)
                Console.WriteLine("Hands:       " + armour.Name);
            else Console.WriteLine("Hands:      (none)");
            armour = null;

            /// Legs
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Legs);
            if (armour != null)
                Console.WriteLine("Legs:        " + armour.Name);
            else Console.WriteLine("Legs:       (none)");
            armour = null;

            /// Feet
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.Feet);
            if (armour != null)
                Console.WriteLine("Feet:        " + armour.Name);
            else Console.WriteLine("Feet:       (none)");
            armour = null;

            /// LeftFinger
            Console.SetCursorPosition(x_coord, 3 + y_coord++);
            armour = null;
            armour = Character.WornArmour.GetWornArmourByLocation(
                Game.Items.Equipment.Armour.ArmourLocation.LeftFinger);
            if (armour != null)
                Console.WriteLine("LeftFinger:  " + armour.Name);
            else
                Console.WriteLine("LeftFinger: (none)");
            armour = null;

            /// RightFinger
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
