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

            foreach(var user in users)
            {
                    Console.WriteLine("User" + user.name + " ratings:");
                    foreach (var rating in user.ratings)
                        Console.WriteLine("Movie:" + rating.Movie + " rating:" + rating.rating);
                    
            }
            Console.WriteLine("Witaj w Movie Engine!\nWprowadź swoje imię i nazwisko\naby zaproponować 10 filmów które powinieneś i nie powinieneś obejrzeć:");
            string name = Console.ReadLine();
            
            if(!users.Any(u=>u.name==name))
            {
                Console.WriteLine("Nie znaleziono użytkownika " + name + " w bazie danych\nNacisnij dowolny klawisz...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.ReadKey();

        }
    }
}
