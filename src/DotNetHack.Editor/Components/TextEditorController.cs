using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Editor.Components
{
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

        /// <summary>
        /// 
        /// </summary>
        public void Undo() { }

        /// <summary>
        /// 
        /// </summary>
        public void Redo() { }

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
