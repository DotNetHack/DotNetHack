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
    ///   The following pages were and still are quite informative:
    ///     http://en.wikipedia.org/wiki/A*_search_algorithm
    ///     http://www.policyalmanac.org/games/aStarTutorial.htm
    ///     
    /// TODO: Significant amount of tuning still required for this A* implementation.
    ///  - F, G, and H performance numbers all require additional work.
    ///  - General tuning, right now one monster is dog slow.
    /// 7/26/2011 - Initial working copy.
    /// </summary>
    [Serializable]
    public class DungeonPathFinding
    {
        /// <summary>
        /// DungeonPathFinding
        /// </summary>
        /// <param name="d">The dungeon</param>
        /// <param name="aAlpha">Start location</param>
        /// <param name="aOmega">End location</param>
        public DungeonPathFinding(Dungeon3 d)
        {
            // Set the dungeon, the start node and the end node.
            Dungeon = d;

            // Setup G, client code may overwrite this functionality.
            GFunc = delegate(Node a, Node b)
            {
                return new Rectangle(a.Location, b.Location).ManhattanDistance() * 10;
            };

            // Setup G, client code may overrite this functionality.
            HFunc = delegate(Node a, Node b) { return (int)(a.Distance(b) * 100); };
        }

        /// <summary>
        /// The initialization step.
        /// </summary>
        void Initialize(Location3i aAlpha, Location3i aOmega)
        {
            StartNode = new Node(Dungeon.GetTile(aAlpha), aAlpha);
            EndNode = new Node(Dungeon.GetTile(aOmega), aOmega);

            // Initialize FCost dictionary.
            FCostDict = new Dictionary<Node, FCost>();

            // create the closed list and the open list.
            OpenList = new List<Node>();
            ClosedList = new List<Node>();

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
        /// UnwindPath, holy smoke.
        /// </summary>
        /// <returns></returns>
        public void UnwindPath(Node aNode, Stack<Node> aResult)
        {
            aResult.Push(aNode);
            if (aNode.Parent != null)
                UnwindPath(aNode.Parent, aResult);
        }
        /// <summary>
        /// http://en.wikipedia.org/wiki/A*_search_algorithm
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Stack<Node> Solve(IHasLocation aAlpha, IHasLocation aOmega)
        {
            // infinityly close for path finding.
            if (aAlpha.Location == aOmega.Location)
                return null;

            // TODO: Beside this, determine what happens when different floors.
            if (aAlpha.Location.D != aOmega.Location.D)
                return null;

            Initialize(aAlpha.Location, aOmega.Location);

            Node n, last = null;
            while (OpenList.Count > 0)
            {
                OpenList.Sort(Cmp);
                n = OpenList[0];

                if (n.Location == EndNode.Location)
                {
                    last = n;
                    break;
                }

                OpenList.Remove(n);
                ClosedList.Add(n);

#if A_STAR_VIS
                ///
                /// WARNING: for visualization only.
                ///

                foreach (var k in OpenList)
                    Dungeon.GetTile(k.Location).C = Colour.Green;

                foreach (var k in ClosedList)
                    Dungeon.GetTile(k.Location).C = Colour.Road;

                Dungeon.DungeonRenderer.Render(n.Location);
#endif

                foreach (var y in GetNeighbors(n))
                {
                    if (ClosedList.Contains(y))
                        continue;
                    if (!OpenList.Contains(y))
                        OpenList.Add(y);
                    y.Parent = n;
                }
            }

            if (last != null)
                if (last.Parent != null)
                {
                    // no sense in being celverm this'll get it done 
                    Stack<Node> retVal = new Stack<Node>();
                    UnwindPath(last, retVal);

                    retVal.Reverse();
                    retVal.Pop();

                    return retVal;
                }
            return null;
        }

        /// <summary>
        /// To keep from re-computing FCost a dictionary is used to short cirtcuit
        /// results that may have already been calculated.
        /// </summary>
        Dictionary<Node, FCost> FCostDict { get; set; }

        /// <summary>
        /// Computes the FCost of the given node. 
        /// </summary>
        /// <param name="start">The start location.</param>
        /// <param name="n">The node</param>
        /// <param name="end">The end location.</param>
        /// <returns>An integer representing the computed FCost</returns>
        public int Compute(Node start, Node n, Node end)
        {
            var fCost = new FCost(GFunc(start, n), HFunc(n, end));
            if (!FCostDict.ContainsKey(n))
                FCostDict.Add(n, fCost);
            return FCostDict[n].F;
        }

        /// <summary>
        /// Compares two nodes' FCost and returns equivalency integer
        /// </summary>
        /// <param name="a">LHS node</param>
        /// <param name="b">RHS node</param>
        /// <returns>equivalency integer</returns>
        public int Cmp(Node a, Node b)
        {
            return Compute(StartNode, a, EndNode) -
                Compute(StartNode, b, EndNode);
        }

        /// <summary>
        /// One method used used to compute H and G's
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
                // note: IsPassable takes into account monsters.
                ITile examineTile = Dungeon.GetTile(x, y, d);
                if (!Dungeon.IsPassable(new Location3i(x, y, d)))
                    ClosedList.Add(new Node(examineTile,
                        new Game.Location3i(x, y, d)));
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
                tmpList.Add(new Node(Dungeon.GetTile(lLeft, l.D), lLeft));

            Location3i lRight = Location3i.GetNew(l.X + 1, l.Y, d);
            if (Dungeon.CheckBounds(lRight))
                tmpList.Add(new Node(Dungeon.GetTile(lRight, l.D), lRight));

            Location3i lDown = Location3i.GetNew(l.X, l.Y + 1, d);
            if (Dungeon.CheckBounds(lDown))
                tmpList.Add(new Node(Dungeon.GetTile(lDown, l.D), lDown));

            Location3i lUp = Location3i.GetNew(l.X, l.Y - 1, d);
            if (Dungeon.CheckBounds(lUp))
                tmpList.Add(new Node(Dungeon.GetTile(lUp, l.D), lUp));

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
        public Node StartNode { get; set; }

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
        public Func<Node, Node, int> GFunc { get; set; }

        /// <summary>
        /// Computing H
        /// </summary>
        public Func<Node, Node, int> HFunc { get; set; }
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
