namespace Part2
{
    public class CellMove
    {
        public CellMove(Step step, CellSquare square, bool firstInstructionMove, bool lastInstructionMove)
        {
            Step = step;
            Square = square;
            FirstInstructionMove = firstInstructionMove;
            LastInstructionMove = lastInstructionMove;
        }

        public Step Step { get; }
        public CellSquare Square { get; }
        public bool FirstInstructionMove { get; }
        public bool LastInstructionMove { get; }
    }
}
