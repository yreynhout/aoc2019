using System.Collections.Generic;

namespace Part2
{
    public class PasswordSpecification : ISpecification
    {
        private readonly IReadOnlyCollection<ISpecification> _specifications;
        public PasswordSpecification()
        {
            _specifications = new ISpecification[] {
                //new TwoAdjacentDigitsAreTheSame(),
                new DigitsNeverDecrease(),
                new AdjacentMatchingDigitsNotPartOfLargerGroup()
            };
        }
        public bool IsSatisfiedBy(CandidatePassword password)
        {
            foreach(var specification in _specifications)
            {
                if(!specification.IsSatisfiedBy(password))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
