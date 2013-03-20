using DotNetHack.GUI.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Widgets
{
    /// <summary>
    /// Button
    /// </summary>
    [DebuggerDisplay("{Text}")]
    public class Button : Widget
    {
        readonly ButtonDecoration decoration;
        readonly char leftDecoration;
        readonly char rightDecoration;

        /// <summary>
        /// Create a new button
        /// </summary>
        public Button(Widget parent, String text, int x, int y, ButtonDecoration decor = ButtonDecoration.SquareBracket)
            : base(text, x, y, text.Length + 2, 1, parent)
        {
            this.decoration = decor;

            switch (decor)
            {
                case ButtonDecoration.AngleBracket:
                    leftDecoration = DECORATION_ANGLE_L;
                    rightDecoration = DECORATION_ANGLE_R;
                    break;

                case ButtonDecoration.Stars:
                    leftDecoration = DECORATION_STAR;
                    rightDecoration = DECORATION_STAR;
                    break;
                case ButtonDecoration.SquareBracket:
                    leftDecoration = DECORATION_SQUARE_L;
                    rightDecoration = DECORATION_SQUARE_R;
                    break;
            }

            Text = string.Format("{0}{1}{2}", leftDecoration, text, rightDecoration);

            EnableSelection();

            KeyboardEvent += Button_KeyboardEvent;
        }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button_KeyboardEvent(object sender, Events.GUIKeyboardEventArgs e)
        {
            switch (e.ConsoleKeyInfo.Key)
            {
                default:
                    break;
                case ConsoleKey.Enter:
                    if (OkayEvent != null)
                        OkayEvent(this, new GUIEventArgs());
                    break;
            }
        }

        /// <summary>
        /// OkayEvent
        /// </summary>
        public event EventHandler<GUIEventArgs> OkayEvent;

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();

            for (int index = 0; index < Text.Length; ++index)
            {
                // decoration text style
                if (index == 0 || index == Text.Length - 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else 
                {
                    // normal text style
                    if (Selected)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.Write(Text[index]);
            } 
        }

        /// <summary>
        /// ButtonDecoration
        /// </summary>
        public enum ButtonDecoration 
        {
            SquareBracket,
            AngleBracket,
            Stars
        }

        #region Various Decoration Constants

        /// <summary>
        /// The decoration on the right of the button
        /// </summary>
        const char DECORATION_SQUARE_R = ']';

        /// <summary>
        /// The decoration ont he left of the button
        /// </summary>
        const char DECORATION_SQUARE_L = '[';

        /// <summary>
        /// The decoration on the right of the button
        /// </summary>
        const char DECORATION_ANGLE_R = '>';

        /// <summary>
        /// The decoration ont he left of the button
        /// </summary>
        const char DECORATION_ANGLE_L = '<';

        /// <summary>
        /// The decoration on the right of the button
        /// </summary>
        const char DECORATION_STAR = '*';

        #endregion
    }
}
