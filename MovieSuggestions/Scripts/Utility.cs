using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MovieSuggestions.Models;

namespace MovieSuggestions.Scripts
{
    class Utility
    {

       

        public static User getUserByName(List<User> db,string name)
        {
            if (checkIfUserInDatabase(db, name))
                return db.SingleOrDefault(u => u.name == name);
            else
                userNotFound(name);

            return null; 
        }
        public static bool checkIfUserInDatabase(List<User> db, string name)
        {
            return db.Any(u => u.name == name);
        }

        public static IEnumerable<User> findSimilarUsers(List<User> db,User user)
        {
           foreach(var user2 in db)
            {
                if (user.name == user2.name) continue;
                user2.scores = Euclidean.euclidean_score(user, user2);
                yield return user2;
            }
        }

        public static List<String> getTenFilms(List<User> users,List<string> movies ,bool best)
        {
           List<Rating> tmp= new List<Rating>();
                users.ForEach(u =>
                {
                    tmp.AddRange(u.ratings.ToList().Where(r => !movies.Contains(r.Movie)));
                });
            return best ? tmp.OrderByDescending(x => x.rating).Select(m=>m.Movie).Take(10).ToList() : tmp.OrderBy(x => x.rating).Select(m => m.Movie).Take(10).ToList();
            
        }

        private static void userNotFound(string name)
        {
            Console.WriteLine("Nie znaleziono użytkownika " + name + " w bazie danych\nNacisnij dowolny klawisz...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
