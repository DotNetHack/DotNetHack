using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Dungeon.Tiles;
using DotNetHack.Game.Dungeon;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Utility.Graph.Algorithm
{
    /// <summary>
    /// DungeonPathFinding
    /// </summary>
    public class DungeonPathFinding : AStar<Node>
    {
        /// <summary>
        /// DungeonPathFinding
        /// </summary>
        /// <param name="d">The dungeon that data is ultimately pulled from.</param>
        /// <param name="aStart">The end node.</param>
        public DungeonPathFinding(Dungeon3 d, Node aStart)
            : base(aStart) 
        {
            Initialize();            
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public override void Initialize()
        {
            // call down to base
            base.Initialize();

            // find all impassable tiles, add them to the closed list.
            Dungeon.IterateDungeonData(delegate(int x, int y, int d)
            {
                ITile examineTile = Dungeon.MapData[x, y, d];
                if (examineTile.Impassable)
                    ClosedList.Add(new Node(examineTile, new Game.Location3i(x, y, d)));
            });
        }

        /// <summary>
        /// Dungeon
        /// </summary>
        Dungeon3 Dungeon { get; set; }
    }

    /// <summary>
    /// AStar
    /// </summary>
    /// <typeparam name="T">The node type</typeparam>
    abstract class AStar<T>
    {
        /// <summary>
        /// Create a new genericized. AStar search
        /// </summary>
        /// <param name="aStart"></param>
        public AStar(T aStart)
        {
            OpenList = new List<T>();
            ClosedList = new List<T>();
            StartNode = aStart;
        }

        /// <summary>
        /// This should init the closed list.
        /// </summary>
        public virtual void Initialize() 
        {
            OpenList.Add(StartNode);
        }

        /// <summary>
        /// The starting node.
        /// </summary>
        protected T StartNode { get; set; }

        /// <summary>
        /// The open list.
        /// </summary>
        List<T> OpenList { get; set; }

        /// <summary>
        /// This is the closed, list, these can be ignored.
        /// </summary>
        protected List<T> ClosedList { get; set; }
    }
}
