namespace Utils.Specifications
{
    // implementing Specification Pattern. See: https://en.wikipedia.org/wiki/Specification_pattern
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
        ISpecification<T> And(ISpecification<T> other);
        ISpecification<T> Or(ISpecification<T> other);
        ISpecification<T> Not();
    }
}