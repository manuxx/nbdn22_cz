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
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            var ret = new List<Movie>(movies);
            ret.Sort((m1,m2)=> (-1)*m1.title.CompareTo(m2.title));
            return ret;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return AllThatSatisfy(x => x.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return AllThatSatisfy(x => x.genre == Genre.action);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return AllThatSatisfy(x => x.date_published.Year > year);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int start_year, int end_year)
        {
            return AllThatSatisfy(x => 
                x.date_published.Year >= start_year &&
                x.date_published.Year <= end_year);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return AllThatSatisfy(x => x.production_studio == ProductionStudio.Pixar ||
                x.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return AllThatSatisfy(x => x.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_kid_movies_published_after(int year)
        {
            return AllThatSatisfy(x => x.date_published.Year > year &&
                x.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_horror_or_action()
        {
            return AllThatSatisfy(x => x.genre == Genre.horror ||
                x.genre == Genre.action);
        }

        private IEnumerable<Movie> AllThatSatisfy(Func<Movie, bool> filterAction)
        {
            foreach (var movie in movies)
            {
                if (filterAction(movie))
                    yield return movie;
            };
        }
    }
}