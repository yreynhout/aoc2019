using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace Part1
{
    public struct CellSquare
    {
        public int X { get; }

        public int Y { get; }

        public CellSquare(int x, int y)
        {
            X = x;
            Y = y;
        }

        [Pure]
        public bool Equals(CellSquare other) => X == other.X && Y == other.Y;
        public override bool Equals(object obj) => obj is CellSquare other && Equals(other);
        public override int GetHashCode() => X ^ Y;

        public CellSquare MoveDown()
        {
            return new CellSquare(X, Y + 1);
        }

        public CellSquare MoveUp()
        {
            return new CellSquare(X, Y - 1);
        }

        public CellSquare MoveRight()
        {
            return new CellSquare(X + 1, Y);
        }

        public CellSquare MoveLeft()
        {
            return new CellSquare(X - 1, Y);
        }

        public int DistanceTo(CellSquare point)
        {
            return Math.Abs(X - point.X) + Math.Abs(Y - point.Y);
        }

        public override string ToString() => string.Format("[{0},{1}]", X.ToString(CultureInfo.InvariantCulture), Y.ToString(CultureInfo.InvariantCulture));
    }
}
