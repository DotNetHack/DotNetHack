using System;
namespace DotNetHack.Utility.Graph.Algorithm
{
    interface IAStar<T>
    {
        System.Collections.Generic.IEnumerable<T> GetNeighbors(T aNode);
        Func<T, double> Heuristic { get; set; }
        void Initialize();
        void PopulateClosedList();
    }
}
