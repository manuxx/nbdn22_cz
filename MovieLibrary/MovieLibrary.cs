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

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return AllThatSatisfy(movie => movie.production_studio == ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            var ret = new List<Movie>(movies);
            ret.Sort((m1,m2)=> (-1)*m1.title.CompareTo(m2.title));
            return ret;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return AllThatSatisfy(movie => movie.genre == Genre.kids);
        }

        private IEnumerable<Movie> AllThatSatisfy(Func<Movie, bool> condition)
        {
            foreach (var movie in movies)
            {
                if (condition(movie))
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return AllThatSatisfy(movie => movie.genre == Genre.action);
        }

        public IEnumerable<Movie> all_movies_published_after(int i)
        {
            return AllThatSatisfy(movie => movie.date_published.Year > i);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int i, int i1)
        {
            return AllThatSatisfy(movie => movie.date_published.Year >= i && movie.date_published.Year <= i1);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return AllThatSatisfy(movie =>
                movie.production_studio == ProductionStudio.Pixar ||
                movie.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return AllThatSatisfy(movie => movie.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_kid_movies_published_after(int i)
        {
            return AllThatSatisfy(movie => movie.genre == Genre.kids && movie.date_published.Year > i);
        }

        public IEnumerable<Movie> all_horror_or_action()
        {
            return AllThatSatisfy(movie => movie.genre == Genre.action || movie.genre == Genre.horror);
        }
    }
}