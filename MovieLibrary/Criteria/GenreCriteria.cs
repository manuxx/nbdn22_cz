using System.Collections.Generic;

namespace TrainingPrep.collections
{
    public class GenreCriteria : ICriteria<Movie>
    {
        private readonly Genre[] _genres;

        public GenreCriteria(Genre[] genres)
        {
            _genres = genres;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return ((IList<Genre>)_genres).Contains(movie.genre);
        }
    }
}