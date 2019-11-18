using MovieSuggestions.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;

namespace MovieSuggestions
{
    class CsvReader
    {

        public static IEnumerable<User> LoadCSV()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\Dane_filmowe.csv");
            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines)
            {
                string[] cells =line.Split(",");

                if (cells[0] == "Osoba") //skip headers
                    continue;
                User user = new User(cells[0]);
                for(int i=2;i<(cells.Length);i=i+2) // iterate every two cells - movie:rate
                {
                    
                    if (String.IsNullOrEmpty(cells[i].ToString())) // if  name of movie is empty break
                        break;

                    int rate;
                    if (!int.TryParse(cells[i + 1], out rate)) // if cant prase ratring to int skip movie
                        continue;

                    Rating rating = new Rating(cells[i],rate);
                    if(!user.ratings.Any(r=>r.Movie==rating.Movie)) // check for duplicate 
                        user.ratings.Add(rating);
                }
                yield return user;
                
            }
        }
    }
}
