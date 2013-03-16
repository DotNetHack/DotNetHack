using DotNetHack.GUI.Events;
using DotNetHack.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI
{
    /// <summary>
    /// Widget
    /// </summary>
    public abstract class Widget : IDisposable, IColorScheme
    {
        /// <summary>
        /// Retains the creation order of all widgets. If this gets cumbersome there should be a factory.
        /// </summary>
        internal static int creationOrder = 0;

        /// <summary>
        /// Create a new widget
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Widget(string text, int x, int y, int width, int height)
        {
            WidgetID = creationOrder++;

            Size = new Size(width, height);
            Location = new Point(x, y);
            Location.X = x;
            Location.Y = y;
            Text = text;
            Widgets = new Stack<Widget>();
            Console = new DisplayBuffer(width, height);
            GUI.Instance.KeyboardCallback += Instance_KeyboardCallback;
        }

        /// <summary>
        /// Instance_KeyboardCallback
        /// </summary>
        /// <param name="obj"></param>
        internal void Instance_KeyboardCallback(ConsoleKeyInfo obj)
        {
            // TODO: Determine if the visibility constraint should be here.
            if (keyboardEvent == null || !Visible)
                return;

            keyboardEvent(this, new GUIKeyboardEventArgs(obj));
        }

        /// <summary>
        /// Create a new Widget
        /// </summary>
        /// <param name="text">the text to initialize the widget with</param>
        /// <param name="region">the screen region for the widget</param>
        public Widget(string text, IScreenRegion region)
            : this(text, region.Location.X, region.Location.Y, region.Width, region.Height)
        {

        }

        /// <summary>
        /// Create a new Widget
        /// </summary>
        /// <param name="text">the text to initialize the widget with</param>
        public Widget(string text)
            : this(text, 0, 0, 0, 0)
        {

        }

        /// <summary>
        /// Console
        /// </summary>
        public DisplayBuffer Console { get; private set; }

        /// <summary>
        /// BG
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// FG
        /// </summary>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public virtual void InitializeWidget()
        {
            Console.Clear(this);
        }

        /// <summary>
        /// Show
        /// </summary>
        public virtual void Show()
        {
            Visible = true;
        }

        /// <summary>
        /// Hide
        /// </summary>
        public virtual void Hide()
        {
            Visible = false;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="widget">Add a widget</param>
        public void Add(Widget widget)
        {
            Widgets.Push(widget);
        }

        /// <summary>
        /// Width
        /// </summary>
        public int Width
        {
            get { return Size.Width; }
        }

        /// <summary>
        /// Height
        /// </summary>
        public int Height
        {
            get { return Size.Height; }
        }

        /// <summary>
        /// Location
        /// </summary>
        public IPoint Location { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        public IDimensional Size { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// ActiveWidget
        /// </summary>
        public Widget ActiveWidget { get { return Widgets.Peek(); } }

        /// <summary>
        /// Widgets
        /// </summary>
        public Stack<Widget> Widgets { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// WidgetID
        /// </summary>
        public int WidgetID { get; private set; }

        #region Events 

        /// <summary>
        /// keyboardEvent
        /// </summary>
        public event EventHandler<GUIKeyboardEventArgs> keyboardEvent;

        #endregion

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// Box
        /// </summary>
        /// <param name="x">The X-Coordinate</param>
        /// <param name="y">The Y-Coordinate</param>
        /// <param name="w">The Width.</param>
        /// <param name="h">The Height.</param>
        public void Box(int x, int y, int w, int h)
        {
            if (w <= 2)
                throw new ArgumentException(
                    string.Format("Display box width must be greater than 2. Was {0}.", w));

            for (int c = 0; c < w; ++c)
            {
                Console.SetCursorPosition(x + c, y);
                if (c == 0)
                    Console.Write('╔');
                else if (c == w - 1)
                    Console.Write('╗');
                else
                    Console.Write('═');
            }
            for (int c = 1; c < h; ++c)
            {
                Console.SetCursorPosition(x, y + c);
                Console.Write('║');
                Console.SetCursorPosition(x + w - 1, y + c);
                Console.Write('║');
            }
            for (int c = 0; c < w; ++c)
            {
                Console.SetCursorPosition(x + c, y + h);
                if (c == 0)
                    Console.Write('╚');
                else if (c == w - 1)
                    Console.Write('╝');
                else
                    Console.Write('═');
            }

            string spacer = string.Empty;
            for (int c = 0; c < w - 2; ++c)
                spacer += " ";

            for (int c = 1; c < h; ++c)
            {
                Console.SetCursorPosition(x + 1, y + 1);
                Console.Write(spacer);
            }
        }
    }
}
