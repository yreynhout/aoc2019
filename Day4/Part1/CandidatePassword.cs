using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;

namespace Part1
{
    public struct CandidatePassword : IEnumerable<int>
    {
        private readonly int _value;

        public CandidatePassword(int value)
        {
            if(value >= 1_000_000 || value <= 99_999)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value = value;
        }

        [Pure]
        public int ToInt32() => _value;
        [Pure]
        public bool Equals(CandidatePassword other) => _value == other._value;
        public override bool Equals(object obj) => obj is CandidatePassword other && Equals(other);
        public override int GetHashCode() => _value;
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);

        public IEnumerator<int> GetEnumerator()
        {
            return _value
                .ToString()
                .Select(digitChar => int.Parse(digitChar.ToString()))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
