using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Part1
{
    public class Range : IEnumerable<CandidatePassword>
    {
        private Range(CandidatePassword from, CandidatePassword to)
        {
            From = from;
            To = to;
        }

        public CandidatePassword From { get; }
        public CandidatePassword To { get; }

        public static Range Parse(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var parts = value.Split("-");
            if(parts.Length != 2)
            {
                throw new FormatException("The range was not well formed because it did not have the format [0-9]*\\-[0-9]*.");
            }

            if(!int.TryParse(parts[0], out var from))
            {
                throw new FormatException("The range was not well formed because the from part was not a whole number.");
            }

            if(!int.TryParse(parts[1], out var to))
            {
                throw new FormatException("The range was not well formed because the to part was not a whole number.");
            }

            return new Range(new CandidatePassword(from), new CandidatePassword(to));
        }

        public IEnumerator<CandidatePassword> GetEnumerator()
        {
            return Enumerable
                .Range(From.ToInt32(), To.ToInt32() - From.ToInt32())
                .Select(value => new CandidatePassword(value))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
