using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Part1
{
    public class WirePath
    {
        public WirePath(IWirePathInstruction[] instructions)
        {
            Instructions = instructions ?? throw new ArgumentNullException(nameof(instructions));
        }

        public IWirePathInstruction[] Instructions { get; }

        public static WirePath FromPathString(string path)
        {
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var instructions = new List<IWirePathInstruction>();
            foreach(var instruction in path.Split(","))
            {
                switch(instruction[0])
                {
                    case 'U':
                        instructions.Add(new MoveUpInstruction(int.Parse(instruction.Substring(1))));
                        break;
                    case 'D':
                        instructions.Add(new MoveDownInstruction(int.Parse(instruction.Substring(1))));
                        break;
                    case 'L':
                        instructions.Add(new MoveLeftInstruction(int.Parse(instruction.Substring(1))));
                        break;
                    case 'R':
                        instructions.Add(new MoveRightInstruction(int.Parse(instruction.Substring(1))));
                        break;
                    default:
                        throw new FormatException($"The instruction {instruction} is not recognized.");
                }
            }
            return new WirePath(instructions.ToArray());
        }

        public IEnumerable<CellSquare> Walk(CellSquare from)
        {
            var cursor = from;
            foreach(var instruction in Instructions)
            {
                foreach(var point in instruction.Walk(cursor))
                {
                    cursor = point;
                    yield return point;
                }
            }
        }
    }
}
