using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Part2
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

        public IEnumerable<CellMove> Walk(CellSquare from)
        {
            var step = new Step(0);
            var cursor = from;
            foreach(var instruction in Instructions)
            {
                foreach(var move in instruction.Walk(cursor, step))
                {
                    yield return move;
                    
                    if (move.LastInstructionMove)
                    {
                        cursor = move.Square;
                        step = move.Step;
                    }
                }
            }
        }
    }
}
