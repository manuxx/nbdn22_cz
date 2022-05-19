namespace TrainingPrep.collections
{
    public interface ICriteria<in TItem>
    {
        bool IsSatisfiedBy(TItem movie);
    }
}