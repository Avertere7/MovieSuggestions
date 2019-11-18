using MovieSuggestions.Models;
using System;
using System.Collections.Generic;
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
    }
}
