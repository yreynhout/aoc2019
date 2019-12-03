using System.Collections.Generic;

namespace Part2
{
    public interface IWirePathInstruction 
    {
        IEnumerable<CellMove> Walk(CellSquare from, Step current);
    }
}
