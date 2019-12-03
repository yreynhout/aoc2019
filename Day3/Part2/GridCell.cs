using System;
using System.Collections.Generic;
using System.Linq;

namespace Part2
{
    public class GridCell
    {
        public static readonly GridCell Empty = new GridCell();

        private Dictionary<Wire, List<Step>> _wires;

        public GridCell()
        {
            _wires = new Dictionary<Wire, List<Step>>();
        }

        public void CrossedBy(Wire wire, Step atStep)
        {
            if(!_wires.TryGetValue(wire, out var steps))
            {
                steps = new List<Step>();
                _wires.Add(wire, steps);
            }
            steps.Add(atStep);
        }

        public bool IsIntersection()
        {
            return _wires.Count > 1;
        }

        public Step TotalStepsTakenByAllCrossingWires()
        {
            if(_wires.Count > 1)
            {
                return _wires.Select(pair => pair.Value.Min()).Aggregate(new Step(0), (total, current) => total.Plus(current));
            }
            return new Step(int.MaxValue);
        }
    }
}
