using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Editor.Components
{
    /// <summary>
    /// Extension methods
    /// </summary>
    public static class RTFColorExtension
    {
        /// <summary>
        /// Color2RtfRGB
        /// </summary>
        /// <param name="c">The color</param>
        /// <returns>RTF color string</returns>
        public static string Color2RtfRGB(this System.Drawing.Color c)
        {
            return string.Format(@"\red{0}\green{1}\blue{2};", c.R, c.G, c.B);
        }

        /// <summary>
        /// ColorArr2RtfRBG
        /// </summary>
        /// <param name="colors">colors</param>
        /// <returns>RTF color string</returns>
        public static string ColorArr2RtfRBG(this System.Drawing.Color[] colors)
        {
            string outValue = string.Empty;
            foreach (var c in colors)
                outValue += c.Color2RtfRGB();
            return outValue;
        }
    }

    /// <summary>
    /// TextEditorController
    /// </summary>
    [ToolboxItem(true)]
    [Description("DotNetHack Text Editor Controller")]
    public partial class TextEditorController : Component, IComponent
    {
        /// <summary>
        /// TextEditorController
        /// </summary>
        public TextEditorController()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TextEditorController
        /// </summary>
        /// <param name="container">a container</param>
        public TextEditorController(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Save() 
        { 

        }

        public void SaveAs() 
        {

        }

        /// <summary>
        /// Clear
        /// </summary>
        public void Clear() 
        {
            RedoStack.Clear();
            UndoStack.Clear();
        }

        /// <summary>
        /// Undo
        /// </summary>
        public void Undo() 
        {

        }

        /// <summary>
        /// Redo
        /// </summary>
        public void Redo() 
        {

        }

        /// <summary>
        /// UndoStack
        /// </summary>
        private Stack<string> UndoStack { get; set; }

        /// <summary>
        /// RedoStack
        /// </summary>
        private Stack<string> RedoStack { get; set; }
    }
}
