namespace Part1
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(CandidatePassword password);
    }
}
