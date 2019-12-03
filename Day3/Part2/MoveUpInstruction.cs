using System;
using System.Collections.Generic;

namespace Part2
{
    public class MoveUpInstruction : IWirePathInstruction
    {
        public MoveUpInstruction(int times)
        {
            if(times < 0)
                throw new ArgumentOutOfRangeException(nameof(times));
            Times = times;
        }

        public int Times { get; }
        
        public IEnumerable<CellMove> Walk(CellSquare from, Step current)
        {
            var step = current.Next();
            var cursor = from;
            for(var index = 0; index < Times; index++)
            {
                cursor = cursor.MoveUp();
                yield return new CellMove(step, cursor, index == 0, index + 1 == Times);
                step = step.Next();
            }
        }
    }
}
