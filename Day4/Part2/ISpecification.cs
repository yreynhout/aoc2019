namespace Part2
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(CandidatePassword password);
    }
}
