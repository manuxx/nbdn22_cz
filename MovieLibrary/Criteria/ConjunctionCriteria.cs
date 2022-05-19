namespace TrainingPrep.collections
{
    public class ConjunctionCriteria : ICriteria<Movie>
    {
        private readonly ICriteria<Movie>[] _criteria;

        public ConjunctionCriteria(params ICriteria<Movie>[] criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            foreach (var criterion in _criteria)
            {
                if (!criterion.IsSatisfiedBy(movie))
                    return false;
            }

            return true;
        }
    }
}