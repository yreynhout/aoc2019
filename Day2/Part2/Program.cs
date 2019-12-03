using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Part2
{
    public class Program
    {
        public int[] InitialMemory { get; }
        public int[] Memory { get; private set; }

        static void Main(string[] args)
        {
            var memory = File.ReadAllText(args[0]).Split(",").Select(value => int.Parse(value)).ToArray();
            var program = new Program(memory);
            for(var noun = 0; noun <= 99; noun++)
            {
                Console.WriteLine("Noun="+noun);
                for(var verb = 0; verb <= 99; verb++)
                {
                    Console.WriteLine("Verb="+verb);
                    program.Reset();
                    program.SetNoun(noun);
                    program.SetVerb(verb);
                    program.Run();
                    if(program.Memory[0] == 19690720)
                    {
                        Console.WriteLine((100 * noun) + verb);
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void Reset()
        {
            Memory = new List<int>(InitialMemory).ToArray();
        }

        public Program(int[] memory)
        {
            InitialMemory = memory;
            Reset();
        }

        public void RestoreState()
        {
            SetNoun(12);
            SetVerb(2);
        }

        public void SetNoun(int value) => Memory[1] = value;
        public void SetVerb(int value) => Memory[2] = value;

        public int GetInstructionParameter(int position)
        {
            return Memory[position];
        }

        public int GetAddressPointer(int position)
        {
            return Memory[position];
        }

        public void SetOutput(int position, int value)
        {
            Memory[position] = value;
        }

        public void Run()
        {
            var pointer = 0;
            var instruction = new Instruction(pointer);
            while(!instruction.Execute(this))
            {
                pointer += 4;
                instruction = new Instruction(pointer);
            }
        }

        public int GetInstructionOpCode(int position)
        {
            return Memory[position];
        }
    }

    public class Instruction
    {
        public Instruction(int position)
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
            switch(program.GetInstructionOpCode(Position))
            {
                case 1:
                    program.SetOutput(program.GetAddressPointer(Position + 3), program.GetInstructionParameter(program.GetAddressPointer(Position + 1)) + program.GetInstructionParameter(program.GetAddressPointer(Position + 2)));
                    break;
                case 2:
                    program.SetOutput(program.GetAddressPointer(Position + 3), program.GetInstructionParameter(program.GetAddressPointer(Position + 1)) * program.GetInstructionParameter(program.GetAddressPointer(Position + 2)));
                    break;
                case 99:
                    done = true;
                    break;
                default:
                    throw new InvalidOperationException("The program contains an invalid opcode:" + program.GetInstructionOpCode(Position));
            }
            return done;
        }
    }
}
