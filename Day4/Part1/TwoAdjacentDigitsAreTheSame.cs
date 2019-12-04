namespace Part1
{
    public class TwoAdjacentDigitsAreTheSame : ISpecification
    {
        public bool IsSatisfiedBy(CandidatePassword password)
        {
            var foundTwoAdjacentDigitsThatAreTheSame = false;
            using(var enumerator = password.GetEnumerator())
            {
                if(enumerator.MoveNext())
                {
                    var previous = enumerator.Current;
                    while(enumerator.MoveNext() && !foundTwoAdjacentDigitsThatAreTheSame)
                    {
                        foundTwoAdjacentDigitsThatAreTheSame = enumerator.Current.Equals(previous);
                        if(!foundTwoAdjacentDigitsThatAreTheSame)
                        {
                            previous = enumerator.Current;
                        }
                    }
                }
            }
            return foundTwoAdjacentDigitsThatAreTheSame;
        }
    }
}
