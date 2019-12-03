using System.Collections.Generic;

namespace Part1
{
    public class Grid
    {
        public static readonly CellSquare CentralPort = new CellSquare(0,0);

        private readonly Dictionary<CellSquare, GridCell> _cells;

        public Grid()
        {
            _cells = new Dictionary<CellSquare, GridCell>();
        }

        public void DrawWire(Wire wire, WirePath path)
        {
            foreach(var point in path.Walk(CentralPort))
            {
                if(!_cells.TryGetValue(point, out var cell))
                {
                    cell = new GridCell();
                    _cells.Add(point, cell);
                }
                cell.CrossedBy(wire);
            }
        }

        public int WhatIsTheShortestDistanceToCentralPortFromTheClosestIntersection()
        {
            var shortestDistance = int.MaxValue;
            foreach(var cell in _cells)
            {
                if(cell.Value.IsCrossedByAtLeastTwoWires())
                {
                    var candidateDistance = cell.Key.DistanceTo(CentralPort);
                    if (candidateDistance < shortestDistance)
                    {
                        shortestDistance = candidateDistance;
                    }
                }
            }
            return shortestDistance;
        }
    }
}
