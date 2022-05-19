namespace TrainingPrep.collections
{
    public class NegationCriteria<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _criteria;

        public NegationCriteria(ICriteria<TItem> criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_criteria.IsSatisfiedBy(item);
        }
    }
}