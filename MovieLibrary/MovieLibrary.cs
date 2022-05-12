using System;
using System.Buffers;
using System.Collections.Generic;

namespace TrainingPrep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return new ReadOnlySet<Movie>(movies);
        }

        public void add(Movie movie)
        {
            foreach (var movie1 in movies)
            {
                if (movie1.title==movie.title)
                    return;
            }
            movies.Add(movie);
        }
    }
}