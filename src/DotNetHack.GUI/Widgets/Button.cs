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
    [DebuggerDisplay("{leftDecoration}{}rightDecoration{}")]
    public class Button : Widget
    {
        readonly ButtonDecoration decoration;
        readonly char leftDecoration;
        readonly char rightDecoration;
        readonly string text;

        /// <summary>
        /// Create a new button
        /// </summary>
        public Button(String text, int x, int y, ButtonDecoration decor = ButtonDecoration.SquareBracket)
            : base(text, x, y, text.Length + 2, 1)
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

            this.text = text;
            this.text = string.Format("{0}{1}{2}", leftDecoration, text, rightDecoration);
        }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();

            Console.SetCursorPosition(this);

            foreach (var s in text)
            {
                Console.Write(s);
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
