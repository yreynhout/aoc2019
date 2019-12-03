using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    public class Program
    {
        public int[] Data { get; }

        static void Main(string[] args)
        {
            var program = new Program(File.ReadAllText(args[0]).Split(",").Select(value => int.Parse(value)));
            program.RestoreState();
            program.Run();
            Console.WriteLine(program.Data[0]);
        }

        public Program(IEnumerable<int> data)
        {
            Data = data.ToArray();
        }

        public void RestoreState()
        {
            Data[1] = 12;
            Data[2] = 2;
        }

        public int GetInput(int position)
        {
            return Data[position];
        }

        public int GetPosition(int position)
        {
            return Data[position];
        }

        public void SetOutput(int position, int value)
        {
            Data[position] = value;
        }

        public void Run()
        {
            var position = 0;
            var opCode = new OpCode(position);
            while(!opCode.Execute(this))
            {
                position += 4;
                opCode = new OpCode(position);
            }
        }

        public int GetOpCode(int position)
        {
            return Data[position];
        }
    }

    public class OpCode
    {
        public OpCode(int position)
        {
            Position = position;
        }

        public int Position { get; }

        public bool Execute(Program program)
        {
            if (program is null)
            {
                throw new ArgumentNullException(nameof(program));
            }

            var done = false;
            switch(program.GetOpCode(Position))
            {
                case 1:
                    program.SetOutput(program.GetPosition(Position + 3), program.GetInput(program.GetPosition(Position + 1)) + program.GetInput(program.GetPosition(Position + 2)));
                    break;
                case 2:
                    program.SetOutput(program.GetPosition(Position + 3), program.GetInput(program.GetPosition(Position + 1)) * program.GetInput(program.GetPosition(Position + 2)));
                    break;
                case 99:
                    done = true;
                    break;
                default:
                    throw new InvalidOperationException("The program contains an invalid opcode:" + program.GetOpCode(Position));
            }
            return done;
        }
    }
}
