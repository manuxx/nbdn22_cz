namespace TrainingPrep.collections
{
    public class AlternativeCriteria : ICriteria<Movie>
    {
        private readonly ICriteria<Movie>[] _criteria;

        public AlternativeCriteria(params ICriteria<Movie>[] criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            foreach (var criterion in _criteria)
            {
                if (criterion.IsSatisfiedBy(movie))
                    return true;
            }

            return false;
        }
    }
}