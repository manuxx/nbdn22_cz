namespace TrainingPrep.collections
{
    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria;

        public Negation(Criteria<TItem> criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(TItem movie)
        {
            return ! _criteria.IsSatisfiedBy(movie);
        }
    }
}