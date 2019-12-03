using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var fuelRequirements = new List<int>();
            foreach(var mass in File.ReadAllLines(args[0]).Select(line => int.Parse(line)))
            {
                var fuelRequirement = mass;
                while(fuelRequirement >= 0)
                {
                    fuelRequirement = (fuelRequirement / 3) - 2;
                    if(fuelRequirement >= 0)
                    {
                        fuelRequirements.Add(fuelRequirement);
                    }
                }
            }
            Console.WriteLine(fuelRequirements.Aggregate(0, (total, current) => total + current));
        }
    }
}
