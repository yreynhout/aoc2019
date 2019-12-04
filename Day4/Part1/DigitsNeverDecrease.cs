namespace Part1
{
    public class DigitsNeverDecrease : ISpecification
    {
        public bool IsSatisfiedBy(CandidatePassword password)
        {
            var digitsNeverDecrease = true;
            using(var enumerator = password.GetEnumerator())
            {
                if(enumerator.MoveNext())
                {
                    var previous = enumerator.Current;
                    while(enumerator.MoveNext() && digitsNeverDecrease)
                    {
                        digitsNeverDecrease = previous <= enumerator.Current;
                        if(digitsNeverDecrease)
                        {
                            previous = enumerator.Current;
                        }
                    }
                }
            }
            return digitsNeverDecrease;
        }
    }
}
