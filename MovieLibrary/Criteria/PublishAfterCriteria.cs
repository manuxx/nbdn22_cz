namespace TrainingPrep.collections
{
    public class PublishAfterCriteria : ICriteria<Movie>
    {
        private readonly int _year;
        
        public PublishAfterCriteria(int year)
        {
            _year = year;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return movie.date_published.Year > _year;
        }
    }
}