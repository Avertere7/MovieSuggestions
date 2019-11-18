using MovieSuggestions.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieSuggestions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = CsvReader.LoadCSV().ToList();

          
            Console.WriteLine("Witaj w Movie Engine!\nWprowadź swoje imię i nazwisko\naby zaproponować 10 filmów które powinieneś i nie powinieneś obejrzeć:");
            string name = Console.ReadLine();
            User actualUser = Utility.getUserByName(users, name);

            var rankingUsers=Utility.findSimilarUsers(users,actualUser).OrderBy(sU=>sU.scores);
            List<String> bestTenFilms =Utility.getTenFilms(rankingUsers.Where(x => x.scores > 0.5).ToList(), actualUser.ratings.Select(x => x.Movie).ToList(), true);
            List<String> worstTenFilms =Utility.getTenFilms(rankingUsers.Where(x => x.scores < 0.5).ToList(), actualUser.ratings.Select(x => x.Movie).ToList(), false);

            Console.WriteLine("Proponowane Top 10 filmów:");
            foreach(string best in bestTenFilms)
            {
                Console.WriteLine(best);
            }
            Console.WriteLine("Najgorsze 10 filmów:");
            foreach (string worst in worstTenFilms)
            {
                Console.WriteLine(worst);
            }

        }
    }
}
