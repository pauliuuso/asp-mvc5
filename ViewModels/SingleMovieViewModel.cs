using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aspnet.Models;

namespace aspnet.ViewModels
{
    public class SingleMovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Customer> Customers { get; set; }
    }
}