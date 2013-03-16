using DotNetHack.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Widgets
{
    /// <summary>
    /// TextBox
    /// </summary>
    public class TextBox : Widget
    {
        /// <summary>
        /// TextBox
        /// </summary>
        /// <param name="label"></param>
        /// <param name="inputMaxLength"></param>
        public TextBox(int x, int y, int inputMaxLength) 
            : base("", x, y, inputMaxLength, 1)
        {
            MaxLength = inputMaxLength;
            EnableSelection();
            KeyboardEvent += TextBox_KeyboardEvent;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();
        }

        /// <summary>
        /// TextBox_KeyboardEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TextBox_KeyboardEvent(object sender, Events.GUIKeyboardEventArgs e)
        {
            if (!Visible)
                return;

            char tmpChar = e.ConsoleKeyInfo.KeyChar;

            switch (e.ConsoleKeyInfo.Key)
            {
                default:
                    if (!char.IsLetterOrDigit(tmpChar))
                        return;

                    AddNewChar(tmpChar);
                    break;

                case ConsoleKey.Backspace:
                    EraseLastChar();
                    break;

                case ConsoleKey.Enter:
                    OnEntered(Text);
                    break;
            }
        }

        /// <summary>
        /// EraseChar
        /// </summary>
        void EraseLastChar()
        {
            if (Text.Length <= 0)
                return;

            Text = Text.Substring(0, Text.Length - 1);
        }

        /// <summary>
        /// AddChar
        /// </summary>
        /// <param name="ch"></param>
        void AddNewChar(char ch)
        {
            if (Text.Length + 1 > MaxLength)
                return;

            Text += ch;

            Console.Invalidate();
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            const char DEFAULT_CHAR = ' ';

            base.Show();

            Console.SetCursorPosition(0, 0);

            if (Selected)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }

            for (int index = 0; index < MaxLength; ++index)
            {
                if (index < Text.Length)
                {
                    Console.Write(Text[index]);
                }
                else
                {
                    Console.Write(DEFAULT_CHAR);
                }
            }
        }

        /// <summary>
        /// OnEntered some Text
        /// </summary>
        public Action<string> OnEntered { get; set; }

        /// <summary>
        /// MaxLength
        /// </summary>
        public int MaxLength { get; protected set; }
    }
}
