namespace TrainingPrep.collections
{
    public class PublishedBetweenCriteria : ICriteria<Movie>
    {
        private readonly int _startYear;
        private readonly int _endYear;

        public PublishedBetweenCriteria(int startYear, int endYear)
        {
            _startYear = startYear;
            _endYear = endYear;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return movie.date_published.Year >= _startYear && movie.date_published.Year <= _endYear;
        }
    }
}