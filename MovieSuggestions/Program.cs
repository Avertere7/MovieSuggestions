using System;
using System.Collections.Generic;
using System.Linq;
using MovieSuggestions.Extensions;

namespace MovieSuggestions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = CsvReader.LoadCSV().ToList();

          
            Console.WriteLine("Witaj w Movie Engine!\nWprowadź swoje imię i nazwisko\naby zaproponować 10 filmów które powinieneś i nie powinieneś obejrzeć:");
            string name = Console.ReadLine();
            User actualUser= User.getUserByName(users, name);

            var rankingUsers = users.findSimilarUsers(actualUser).OrderBy(sU=>sU.scores);
            List<String> bestTenFilms = rankingUsers.Where(x => x.scores > 0.5).GetTenFilms(actualUser.ratings.Select(x => x.Movie).ToList(), true);
            List<String> worstTenFilms = rankingUsers.Where(x => x.scores > 0.5).GetTenFilms(actualUser.ratings.Select(x => x.Movie).ToList(), false);

            Console.WriteLine("\n\nProponowane Top 10 filmów:");
            foreach(string best in bestTenFilms)
            {
                Console.WriteLine(best);
            }
            Console.WriteLine("\n\nNajgorsze 10 filmów:");
            foreach (string worst in worstTenFilms)
            {
                Console.WriteLine(worst);
            }

        }
    }
}
