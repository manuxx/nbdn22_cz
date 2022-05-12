using System;
using System.Buffers;
using System.Collections;
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
            return new ReadOnlySet(movies);
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

    public class ReadOnlySet : IEnumerable<Movie>
    {
        private readonly IEnumerable<Movie> _movies;

        public ReadOnlySet(IEnumerable<Movie> movies)
        {
            _movies = movies;
        }

        public IEnumerator<Movie> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}