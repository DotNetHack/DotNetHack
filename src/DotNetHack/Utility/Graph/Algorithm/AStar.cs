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
    /// Extension methods for rectangle, specific to this A* implementation.
    /// </summary>
    public static class RectangleExt
    {
        /// <summary>
        /// Manhattan method, where you calculate the total number of squares moved
        /// horizontally and vertically to reach the target square from the current
        /// square, ignoring diagonal movement, and ignoring any obstacles that may
        /// be in the way. 
        /// <example>
        /// the following rectangle has a manhattan distance of 14.
        /// <code>
        /// x
        /// x
        /// x
        /// x
        /// x
        /// x y y y y y y y y
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static int ManhattanDistance(this  Rectangle r) { return r.Width + r.Length; }
    }

    /// <summary>
    /// DungeonPathFinding
    /// </summary>
    public class DungeonPathFinding
    {
        /// <summary>
        /// DungeonPathFinding
        /// </summary>
        /// <param name="d">The dungeon</param>
        /// <param name="aAlpha">Start location</param>
        /// <param name="aOmega">End location</param>
        public DungeonPathFinding(Dungeon3 d, IHasLocation aAlpha, IHasLocation aOmega)
        {
            // Set the dungeon, the start node and the end node.
            Dungeon = d;
            StartNode = new Node(Dungeon.GetTile(aAlpha.Location), aAlpha.Location);
            EndNode = new Node(Dungeon.GetTile(aOmega.Location), aOmega.Location);

            // create the closed list and the open list.
            OpenList = new List<Node>();
            ClosedList = new List<Node>();

            Initialize();
        }

        /// <summary>
        /// The initialization step.
        /// </summary>
        void Initialize() 
        {
            OpenList.Add(StartNode);

            // find all closed tiles
            PopulateClosedList();

            // Index through viable neighbors, add it to open list.
            foreach (var t in GetNeighbors(StartNode))
                OpenList.Add(t);

            /// Drop the starting square A from your open list, and add it 
            /// to a “closed list” of squares that you don’t need to look at again for now.
            OpenList.Remove(StartNode);
        }

        /// <summary>
        /// Solve
        /// </summary>
        /// <returns></returns>
        public Node Solve(Node aNode)
        {
            // GetNeighbors
            foreach (var t in GetNeighbors(aNode))
                OpenList.Add(t);

            // We can set capacity since we know it'll be around open lists cardinality.
            SortedDictionary<Node, int> fCostDict = new SortedDictionary<Node, int>();

            // For all nodes in the open list compute the fCost.
            foreach (Node o in OpenList)
                fCostDict.Add(o, ComputeFCost(o));

            // Found the min node.
            Node tmpMinimalNode = fCostDict.Min().Key;

            // Set as parent.
            tmpMinimalNode.Parent = aNode;

            if (tmpMinimalNode.Location.Equals(EndNode.Location))
                return null;

            // rtaio;ls
            return Solve(tmpMinimalNode);
        }

        /// <summary>
        /// The starting point and end point are already maintained; so we only need
        /// the single node, G and H will be computed bsed on start and end.
        /// </summary>
        /// <param name="aNode"></param>
        /// <returns></returns>
        int ComputeFCost(Node aSelected)
        {
            // Both G & H anonymous functions with the signature Func<Node, Node, int>
            // this was done since each of these computation for G & H may be slightly different.
            return new FCost(
                G(StartNode, aSelected),
                H(aSelected, EndNode)
                ).F;
        }

        /// <summary>
        /// Used to compute H and G's
        /// </summary>
        /// <param name="aNode"></param>
        /// <returns></returns>
        double ManhattanDistance(Node from, Node to)
        {
            return new Rectangle(from.Location, to.Location).ManhattanDistance();
        }

        /// <summary>
        /// Find all closed tiles. Should be done right off the bat.
        /// </summary>
        public void PopulateClosedList()
        {
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
        public IEnumerable<Node> GetNeighbors(Node aNode)
        {
            // List enumeration for neighboring nodes
            List<Node> tmpList = new List<Node>();

            // This nodes location (used repeatedly)
            Location3i l = aNode.Location;

            // The dungeon level were working on.
            int d = l.D;

            /// Repeat for all n sides.
            /// 
            /// 1. get ortho location.
            /// 1.1. check bounds for location
            /// 1.1.1. Add node to short list.

            Location3i lLeft = Location3i.GetNew(l.X - 1, l.Y, d);
            if (Dungeon.CheckBounds(lLeft))
                tmpList.Add(new Node(Dungeon.GetTile(lLeft, l.D), lLeft, aNode));

            Location3i lRight = Location3i.GetNew(l.X + 1, l.Y, d);
            if (Dungeon.CheckBounds(lRight))
                tmpList.Add(new Node(Dungeon.GetTile(lRight, l.D), lRight, aNode));

            Location3i lDown = Location3i.GetNew(l.X, l.Y + 1, d);
            if (Dungeon.CheckBounds(lDown))
                tmpList.Add(new Node(Dungeon.GetTile(lDown, l.D), lDown, aNode));

            Location3i lUp = Location3i.GetNew(l.X, l.Y - 1, d);
            if (Dungeon.CheckBounds(lUp))
                tmpList.Add(new Node(Dungeon.GetTile(lUp, l.D), lUp, aNode));

            // return an IEnumerable<Node> based on some predicate.
            return tmpList.Where<Node>(t => !t.Impassable);
        }

        /// <summary>
        /// Dungeon
        /// </summary>
        Dungeon3 Dungeon { get; set; }

        /// <summary>
        /// The starting node.
        /// </summary>
        Node StartNode { get; set; }

        /// <summary>
        /// the ending terminal node
        /// </summary>
        Node EndNode { get; set; }

        /// <summary>
        /// The open list.
        /// </summary>
        List<Node> OpenList { get; set; }

        /// <summary>
        /// This is the closed, list, these can be ignored.
        /// </summary>
        List<Node> ClosedList { get; set; }

        /// <summary>
        /// Computing G
        /// </summary>
        public Func<Node, Node, int> G { get; set; }

        /// <summary>
        /// Computing H
        /// </summary>
        public Func<Node, Node, int> H { get; set; }
    }

    /// <summary>
    /// The key to determining which squares to use when figuring out
    /// the path is the following equation:
    /// <example><code>F = G + H</code></example>
    /// </summary>
    class FCost : IComparable<FCost>
    {
        /// <summary>
        /// Creates a new instance of f cost.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="h"></param>
        public FCost(int g, int h) { H = h; G = g; }

        /// <summary>
        /// the movement cost to move from the starting point A to a given square 
        /// on the grid, following the path generated to get there. 
        /// </summary>
        public int G { get; set; }

        /// <summary>
        /// the estimated movement cost to move from that given square on
        /// the grid to the final destination, point B. This is often referred 
        /// to as the heuristic, which can be a bit confusing.
        /// </summary>
        public int H { get; set; }

        /// <summary>
        /// F is calculated by adding G and H.
        /// </summary>
        public int F { get { return G + H; } }

        /// <summary>
        /// CompareTo
        /// </summary>
        /// <param name="other">The other FCost being compared.</param>
        /// <returns>comparison result.</returns>
        public int CompareTo(FCost other) { return F.CompareTo(other.F); }
    }
}
