using System;
using System.IO;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Range.Parse(File.ReadAllText(args[0]));
            var specification = new PasswordSpecification();
            var count = 0;
            foreach(var password in range)
            {
                if(specification.IsSatisfiedBy(password))
                {
                    count++;
                    Console.WriteLine(password);
                }
            }
            Console.WriteLine(count);
        }
    }
}
