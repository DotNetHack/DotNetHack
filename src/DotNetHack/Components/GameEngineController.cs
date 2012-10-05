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
    public partial class GameEngineController : Component, IComponent, GameEngine.IGameEngineController
    {
        /// <summary>
        /// InitializeComponent
        /// </summary>
        public GameEngineController()
        { 
            InitializeComponent();
            Engine = new GameEngine(GameEngine.GameEngineFlags.Debug)
                .RegisterStartStopCallbacks(timerMain.Start, timerMain.Stop);
            timerMain.Tick += Engine.Update;
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
        /// Engine
        /// </summary>
        public GameEngine Engine { get; set; }
    }
}
