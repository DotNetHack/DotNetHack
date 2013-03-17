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
    public abstract class Widget : IDisposable, IColorScheme, IHasLocation
    {
        /// <summary>
        /// Retains the creation order of all widgets. If this gets cumbersome there should be a factory.
        /// </summary>
        internal static int creationOrder = 0;

        /// <summary>
        /// Focused
        /// </summary>
        static Widget Focus;

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
            Widgets = new List<Widget>();
            Console = new DisplayBuffer(width, height);

            // Most widgets are not selectable by default
            IsSelectable = false;

            if (WidgetID <= 1)
                GUI.Instance.KeyboardCallback += Instance_KeyboardCallback;
        }

        /// <summary>
        /// Traverse
        /// </summary>
        /// <param name="action"></param>
        /// <param name="root"></param>
        /// <param name="predicate"></param>
        internal static void Traverse(Action<Widget> action, Widget root, Predicate<Widget> predicate = null)
        {
            if (root.Widgets.Count <= 0)
                return;

            foreach (var w in root.Widgets)
            {
                if (predicate == null || (predicate != null && predicate(w)))
                {
                    action(w);
                }

                if (w.Widgets.Count > 0)
                {
                    Traverse(action, w);
                }
            }
        }

        /// <summary>
        /// Instance_KeyboardCallback
        /// </summary>
        /// <param name="obj"></param>
        internal void Instance_KeyboardCallback(ConsoleKeyInfo obj)
        {
            // TODO: Determine if the visibility constraint should be here.
            // TODO: If removing the delegate on Hide !Visible is redundant.
            if (KeyboardEvent == null || !Visible)
                return;

            // Intercept all keyboard events to define top level behavior
            switch (obj.Key)
            {
                default:
                    if (Focus != null && Focus.KeyboardEvent != null)
                    {
                        Focus.KeyboardEvent(this, new GUIKeyboardEventArgs(obj));
                    }
                    break;
                case ConsoleKey.Tab:

                    lock (Widgets)
                    {
                        if (Widgets.Count > 0)
                        {
                            Focus = Widgets[selector % Widgets.Count];

                            // deselect everything
                            foreach (var w in Widgets.Where(w => w.WidgetSelectedEvent != null))
                            {
                                w.WidgetSelectedEvent(w, new GUISelectionEventArgs(GUISelectionEventArgs.SelectionEventType.Deselected));
                            }

                            // fire selction event
                            if (Focus.WidgetSelectedEvent != null && Focus != null)
                            {
                                Focus.WidgetSelectedEvent(Focus,
                                    new GUISelectionEventArgs(GUISelectionEventArgs.SelectionEventType.Selected));
                            }
                        }
                    }

                    selector++;
                    break;
            }
        }

        /// <summary>
        /// selector
        /// </summary>
        int selector = 1;

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
            Widgets.Add(widget);
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
        public Point Location { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        public IDimensional Size { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Widgets
        /// </summary>
        public List<Widget> Widgets { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// WidgetID
        /// </summary>
        public int WidgetID { get; private set; }

        /// <summary>
        /// IsSelectable
        /// </summary>
        public bool IsSelectable { get; private set; }

        /// <summary>
        /// Selected
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// WidgetSelectedEvent
        /// </summary>
        public event EventHandler<GUISelectionEventArgs> WidgetSelectedEvent;

        /// <summary>
        /// EnableSelection
        /// </summary>
        public void EnableSelection()
        {
            IsSelectable = true;
        }

        /// <summary>
        /// EnableSelection
        /// </summary>
        public void DisableSelection()
        {
            IsSelectable = false;
        }

        #region Events

        /// <summary>
        /// KeyboardEvent
        /// </summary>
        public event EventHandler<GUIKeyboardEventArgs> KeyboardEvent;

        #endregion

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Hide();
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

        /// <summary>
        /// Box
        /// </summary>
        /// <param name="aTitle">The Title</param>
        /// <param name="x">The X-Coordinate</param>
        /// <param name="y">The Y-Coordinate</param>
        /// <param name="w">The Width.</param>
        /// <param name="h">The Height.</param>
        public void Box(string aTitle, int x, int y, int w, int h)
        {
            int l = aTitle.Length;
            if (l < w)
            {
                Box(x, y, w, h);
                Console.SetCursorPosition(x + ((w / 2) - (l / 2)), y);
                Console.Write(aTitle);
            }
            else Box(aTitle, x, y, l + 2, h);
        }

        /// <summary>
        /// Box
        /// </summary>
        /// <param name="aTile">The Title</param>
        /// <param name="x">The X-Coordinate</param>
        /// <param name="y">The Y-Coordinate</param>
        /// <param name="w">The Width.</param>
        /// <param name="h">The Height.</param>
        /// <param name="ralign">Right Align?</param>
        public void Box(string aTile, int x, int y, int w, int h, bool ralign)
        {
            if (!ralign)
                Box(aTile, x, y, w, h);
            else Box(aTile, Console.Width - (((aTile.Length > w ? aTile.Length + 2 : w)) + x), y, w, h);
        }
    }
}
