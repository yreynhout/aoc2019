using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                (
                    from line in File.ReadAllLines(args[0])
                    let mass = int.Parse(line)
                    select ((mass / 3) - 2)
                ).Aggregate(0, (total, current) => total + current)
            );
        }
    }
}
