using System;

namespace Part2
{
    public class AdjacentMatchingDigitsNotPartOfLargerGroup : ISpecification
    {
        public bool IsSatisfiedBy(CandidatePassword password)
        {
            var foundTwoAdjacentDigits = false;
            using(var enumerator = password.GetEnumerator())
            {
                if(enumerator.MoveNext())
                {
                    var previous = enumerator.Current;
                    var count = 1;
                    while(enumerator.MoveNext() && !foundTwoAdjacentDigits)
                    {
                        if(previous.Equals(enumerator.Current))
                        {
                            count++;
                        }
                        else
                        {
                            if (count == 1)
                            {
                                previous = enumerator.Current;
                            }
                            else if(count == 2)
                            {
                                foundTwoAdjacentDigits = true;
                            }
                            else
                            {
                                count = 1;
                                previous = enumerator.Current;
                            }
                        }
                    }
                    if(!foundTwoAdjacentDigits && count == 2)
                    {
                        foundTwoAdjacentDigits = true;
                    }
                }
            }
            return foundTwoAdjacentDigits;
        }
    }
}
