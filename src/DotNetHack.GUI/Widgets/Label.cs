using DotNetHack.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Widgets
{
    /// <summary>
    /// Label
    /// </summary>
    public class Label : Widget
    {

        /// <summary>
        /// Label
        /// </summary>
        /// <param name="parent">the parent</param>
        /// <param name="text">the text</param>
        /// <param name="x">the x-coordinate</param>
        /// <param name="y">the y-coordinate</param>
        public Label(Widget parent, string text, int x, int y)
            : base(text, x, y, text.Length, 1, parent)
        {
            DisableSelection();
        }

        /// <summary>
        /// Label
        /// </summary>
        /// <param name="parent">the parent</param>
        /// <param name="text">the text</param>
        /// <param name="location">the location</param>
        public Label(Widget parent, string text, Point location)
            : base(text, location.X, location.Y, text.Length, 1, parent)
        {
            DisableSelection();
        }

        /// <summary>
        /// Label placed left adjusted based on some other object; be sure there is enough 
        /// room with a spacer of 1 between the two objects.
        /// </summary>
        /// <param name="parent">the parent</param>
        /// <param name="text">the text</param>
        /// <param name="locatable">the locatable object</param>
        public Label(Widget parent, string text, IHasLocation locatable)
            : this(parent, text, new Point(locatable.Location.X - text.Length - 1, locatable.Location.Y))
        {
            if (Location.X <= 0)
            {
                throw new ArgumentException("Moving relative to object took us into negative territory.");
            }
        }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();
        }

        /// <summary>
        /// Hide
        /// </summary>
        public override void Hide()
        {
            base.Hide();
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();

            if (BackgroundColor == ForegroundColor)
            {
                ForegroundColor = ConsoleColor.White;
            }

            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;

            Console.Write(Text);
        }
    }
}
