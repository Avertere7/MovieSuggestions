using MovieSuggestions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MovieSuggestions.Scripts;

namespace MovieSuggestions.Extensions
{
    static class UserExtensions
    {
        public static List<String> GetTenFilms(this IEnumerable<User> users,List<string> movies,bool best)
        {
            List<Rating> tmp = new List<Rating>();
            users.ToList().ForEach(u =>
            {
                tmp.AddRange(u.ratings.ToList().Where(r => !movies.Contains(r.Movie)));
            });
            var x = tmp.OrderByDescending(x => x.rating).Take(10).ToList();
            return best ? tmp.OrderByDescending(x => x.rating).Select(m => m.displayMovie).Take(10).ToList() : tmp.OrderBy(x => x.rating).Select(m => m.displayMovie).Take(10).ToList();

        }

        public static IEnumerable<User> findSimilarUsers(this List<User> db, User user)
        {
            foreach (var user2 in db)
            {
                if (user.name == user2.name) continue;
                user2.scores = Euclidean.euclidean_score(user, user2);
                yield return user2;
            }
        }
    }
}
