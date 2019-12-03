using System;
using System.Collections.Generic;

namespace Part1
{
    public class MoveRightInstruction : IWirePathInstruction
    {
        public MoveRightInstruction(int times)
        {
            if(times < 0)
                throw new ArgumentOutOfRangeException(nameof(times));
            Times = times;
        }

        public int Times { get; }

        public IEnumerable<CellSquare> Walk(CellSquare from)
        {
            var cursor = from;
            for(var index = 0; index < Times; index++)
            {
                cursor = cursor.MoveRight();
                yield return cursor;
            }
        }
    }
}
