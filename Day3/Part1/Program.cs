using System;
using System.IO;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid();
            var wire = new Wire(1);
            foreach(var line in File.ReadAllLines(args[0]))
            {
                var path = WirePath.FromPathString(line);
                grid.DrawWire(wire, path);
                wire = wire.Next();
            }
            Console.WriteLine(grid.WhatIsTheShortestDistanceToCentralPortFromTheClosestIntersection());
        }
    }
}
