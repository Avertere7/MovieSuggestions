using MovieSuggestions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieSuggestions
{
    class User
    {
        public string name { get; set; }
        public List<Rating> ratings {get;set;}

        public double scores { get; set; }
        public User(string name)
        {
            this.name = name;
            ratings = new List<Rating>();
        }

        public static User getUserByName(List<User> db, string name)
        {
            if (db.Any(u => u.name.ToLower().Trim() == name.ToLower().Trim()))
                return db.SingleOrDefault(u => u.name.ToLower().Trim() == name.ToLower().Trim());
            else
                userNotFound(name);

            return null;
        }

        private static void userNotFound(string name)
        {
            Console.WriteLine("Nie znaleziono użytkownika " + name + " w bazie danych\nNacisnij dowolny klawisz...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
