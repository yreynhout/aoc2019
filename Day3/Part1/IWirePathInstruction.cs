using System.Collections.Generic;

namespace Part1
{
    public interface IWirePathInstruction 
    {
        IEnumerable<CellSquare> Walk(CellSquare from);
    }
}
