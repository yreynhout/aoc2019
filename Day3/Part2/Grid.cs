using System;
using System.Collections.Generic;

namespace Part2
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
            foreach(var move in path.Walk(CentralPort))
            {
                Console.WriteLine("Wire{4}: step={0}, square={1}, first={2}, last={3}", move.Step, move.Square, move.FirstInstructionMove, move.LastInstructionMove, wire);
                if(!_cells.TryGetValue(move.Square, out var cell))
                {
                    cell = new GridCell();
                    _cells.Add(move.Square, cell);
                }
                cell.CrossedBy(wire, move.Step);
            }
        }

        public int WhatIsTheFewestCombinedStepsTheWiresMustTakeToReachAnIntersection()
        {
            var fewestSteps = new Step(int.MaxValue);
            foreach(var cell in _cells)
            {
                if(cell.Value.IsIntersection())
                {
                    var candidateSteps = cell.Value.TotalStepsTakenByAllCrossingWires();
                    if (candidateSteps < fewestSteps)
                    {
                        fewestSteps = candidateSteps;
                    }
                }
            }
            return fewestSteps.ToInt32();
        }
    }
}
