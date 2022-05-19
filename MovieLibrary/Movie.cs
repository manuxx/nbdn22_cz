using System;
using System.Collections.Generic;

namespace TrainingPrep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public bool Equals(Movie other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return title == other.title;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Movie)obj);
        }

        public override int GetHashCode()
        {
            return (title != null ? title.GetHashCode() : 0);
        }

        public static bool operator ==(Movie left, Movie right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Movie left, Movie right)
        {
            return !Equals(left, right);
        }

        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public static Predicate<Movie> IsOfGenres(params Genre[] genres)
        {
            return x => ((IList<Genre>)genres).Contains(x.genre);
        }

        public static Predicate<Movie> IsPublishedAfter(int year)
        {
            return x => x.date_published.Year > year;
        }

        public static Predicate<Movie> IsPublishedBetween(int start_year, int end_year)
        {
            return x => 
                x.date_published.Year >= start_year &&
                x.date_published.Year <= end_year;
        }
    }
}