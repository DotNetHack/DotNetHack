using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Dungeon.Tiles;
using DotNetHack.Game.Dungeon;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game;

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
        /// GetNeighbors
        /// </summary>
        /// <param name="aNode">The current node.</param>
        /// <returns></returns>
        public override IEnumerable<Node> GetNeighbors(Node aNode)
        {
            // List enumeration for neighboring nodes
            List<Node> tmpList = new List<Node>();

            // This nodes location (used repeatedly)
            Location3i l = aNode.Location;

            // The dungeon level were working on.
            int d = l.D;

            // get ortho left, right, up, down locations from current location (l)
            var lLeft = Location3i.GetNew(l.X - 1, l.Y, d);
            var lRight = Location3i.GetNew(l.X + 1, l.Y, d);
            var lDown = Location3i.GetNew(l.X, l.Y + 1, d);
            var lUp = Location3i.GetNew(l.X, l.Y - 1, d);

            // get ortho left, right, up, down tiles
            var tLeft = Dungeon.GetTile(lLeft, l.D);
            var tRight = Dungeon.GetTile(lRight, l.D);
            var tDown = Dungeon.GetTile(lDown, l.D);
            var tUp = Dungeon.GetTile(lUp, l.D);

            // all all of them to a short list.
            tmpList.Add(new Node(tLeft, lLeft, aNode));
            tmpList.Add(new Node(tRight, lRight, aNode));
            tmpList.Add(new Node(tDown, lDown, aNode));
            tmpList.Add(new Node(tUp, lUp, aNode));

            // return an IEnumerable<Node> based on some predicate.
            return tmpList.Where<Node>(t => !t.Impassable);
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
    public abstract class AStar<T>
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
        public virtual void Initialize() { OpenList.Add(StartNode); }

        /// <summary>
        /// GetOpenListNeighbors
        /// </summary>
        public abstract IEnumerable<T> GetNeighbors(T aNode);

        /// <summary>
        /// The starting node.
        /// </summary>
        T StartNode { get; set; }

        /// <summary>
        /// The open list.
        /// </summary>
        protected List<T> OpenList { get; set; }

        /// <summary>
        /// This is the closed, list, these can be ignored.
        /// </summary>
        protected List<T> ClosedList { get; set; }
    }
}
