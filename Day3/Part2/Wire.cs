using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace Part2
{
    public struct Wire
    {
        private readonly int _value;

        public Wire(int value)
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value = value;
        }

        [Pure]
        public Wire Next() => new Wire(_value + 1);

        [Pure]
        public int ToInt32() => _value;
        [Pure]
        public bool Equals(Wire other) => _value == other._value;
        public override bool Equals(object obj) => obj is Wire other && Equals(other);
        public override int GetHashCode() => _value;
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
