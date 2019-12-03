using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace Part2
{
    public struct Step : IComparable<Step>
    {
        private readonly int _value;

        public Step(int value)
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value = value;
        }

        [Pure]
        public Step Next() => new Step(_value + 1);

        [Pure]
        public Step Plus(Step other) => new Step(_value + other._value);

        [Pure]
        public int ToInt32() => _value;
        [Pure]
        public bool Equals(Step other) => _value == other._value;
        public override bool Equals(object obj) => obj is Step other && Equals(other);
        public override int GetHashCode() => _value;
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);

        public int CompareTo(Step other) => _value.CompareTo(other._value);

        public static bool operator <(Step left, Step right) => left.CompareTo(right) < 0;
        public static bool operator <=(Step left, Step right) => left.CompareTo(right) <= 0;
        public static bool operator >(Step left, Step right) => left.CompareTo(right) > 0;
        public static bool operator >=(Step left, Step right) => left.CompareTo(right) >= 0;
        public static bool operator ==(Step left, Step right) => left.Equals(right);
        public static bool operator !=(Step left, Step right) => !left.Equals(right);
    }
}
