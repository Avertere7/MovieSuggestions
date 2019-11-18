using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MovieSuggestions.Models
{
    class Rating
    {
        private string movie;
        public int rating { get; set; }
       
        public string Movie { 
            get
            {
                return this.movie;
            }
            set
            {
                this.movie = removeSymbols(value);
            }
        }
        public Rating(string movie, int rating)
        {
            this.rating = rating;
            this.movie = removeSymbols(movie);
        }

        private string  removeSymbols( string name)
        {
            System.Text.EncodingProvider provider = System.Text.CodePagesEncodingProvider.Instance; // enable coding in .net core framework for env

            Encoding.RegisterProvider(provider);
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(name); // remove polish symbols

            return Regex.Replace(System.Text.Encoding.ASCII.GetString(bytes), "[^a-zA-Z0-9 ]+", "", RegexOptions.Compiled).ToLower(); // remove special characters "[^a-zA-Z0-9_.]+"

        }

      
    }
}
