using MovieSuggestions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MovieSuggestions.Scripts
{
    class Euclidean
    {
        public static double euclidean_score( User user1, User user2)
        {
            return 1 / (1 + getSquaredDiff(user1, user2).Sum());
          
        }

        private static IEnumerable<double> getSquaredDiff(User user1, User user2)
        {
            foreach (var rating in user1.ratings)
                if (user2.ratings.Any(r => r.Movie == rating.Movie))
                    yield return (Math.Sqrt(Math.Abs(rating.rating - user2.ratings.SingleOrDefault(r => r.Movie == rating.Movie).rating)));
                
                   
        }

      
    }
}
