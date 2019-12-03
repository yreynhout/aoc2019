using System.Collections.Generic;

namespace Part1
{
    public class GridCell
    {
        public static readonly GridCell Empty = new GridCell();

        private HashSet<Wire> _wires;

        public GridCell()
        {
            _wires = new HashSet<Wire>();
        }

        public void CrossedBy(Wire wire)
        {
            _wires.Add(wire);
        }

        public bool IsCrossedByAtLeastTwoWires()
        {
            return _wires.Count > 1;
        }
    }
}
