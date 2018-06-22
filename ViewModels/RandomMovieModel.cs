using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieWebApp.Models;

namespace MovieWebApp.ViewModels
{
    public class RandomMovieModel
    {
        public Movie Movie { get; set; }

        public Customer customer { get; set; }
        public List<Customer> Customers { get; set; }

        public List<Movie> Movies { get; set; }
    }
}