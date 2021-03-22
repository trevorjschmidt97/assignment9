using System;
using System.Collections.Generic;

namespace TrevorSchmidtAssignment3.Models
{
    public static class TempStorage
    {
        // Creates a list of movies
        private static List<Movie> movies = new List<Movie>();

        // public function to create an enumerable list of movies,
        // and sets them as the list of movies
        public static IEnumerable<Movie> Movies => movies;

        // public funtion to add a movie to our list of movies
        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
    }
}
