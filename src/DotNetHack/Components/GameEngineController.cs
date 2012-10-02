using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetHack.Core;

namespace DotNetHack.Components
{
    /// <summary>
    /// GameEngineController
    /// </summary>
    [ToolboxItem(true)]
    [Description("DotNetHack GameEngine Controller")]
    public partial class GameEngineController : Component, IComponent, GameEngine.IGameEngineComponent
    {
        /// <summary>
        /// InitializeComponent
        /// </summary>
        public GameEngineController()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GameEngineController
        /// </summary>
        /// <param name="container"></param>
        public GameEngineController(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// GameState
        /// </summary>
        public GameEngine.GameState GameState { get; set; }
    }
}
