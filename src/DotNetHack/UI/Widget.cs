using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game;

namespace DotNetHack.UI
{
    /// <summary>
    /// Left, Right, Center
    /// </summary>
    // public enum HorizontalAlignment { Left, Right, Center }
    /// <summary>
    /// Top, Bottom, Center
    /// </summary>
    // public enum VerticalAlignment { Top, Bottom, Center }

    /// <summary>
    /// 
    /// </summary>
    public enum Align { IOO, OIO, OOI };

    /// <summary>
    /// Widget
    /// </summary>
    public class Widget
    {
        public Widget(int x, int y, int width, int height)
        {
            X = x; Y = y; Width = width; Height = height;
        }

        public event EventHandler OnShow;

        public event EventHandler OnHide;

        public event EventHandler OnUpdate;

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool IsVisible { get; set; }

        public virtual void Show()
        {
            IsVisible = true;
            CursorState.PushCursorState();
            Console.SetCursorPosition(X, Y);
            if (OnShow != null)
                OnShow(this, null);
        }

        public virtual void Hide()
        {
            IsVisible = false;
            CursorState.PopAndSetCursorState();
            if (OnHide != null)
                OnHide(this, null);
        }

        public virtual void Update() 
        {
            if (OnUpdate != null)
                OnUpdate(this, null);
        }

        public virtual void Refresh() { }

        /// <summary>
        /// DisplayRegion
        /// </summary>
        public DisplayRegion DisplayRegion
        {
            get { return new DisplayRegion(X, Y, X + Width, Y + Height); }
        }
    }
}
