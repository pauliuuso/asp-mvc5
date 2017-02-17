using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspnet.Models;
using aspnet.ViewModels;

namespace aspnet.Controllers
{
    public class MoviesController : Controller
    {
        [Route("movies/movie/{id}")]
        public ActionResult Movie(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie() { Name = "Interstellar", Description = "Science fiction drama, one of the best modern movies" });
            movies.Add(new Movie() { Name = "Sigur Ros Heima", Description = "Very warm filled with positive emotions movie" });

            var customers = new List<Customer>
            {
                new Customer { Name = "Paulius" },
                new Customer { Name = "Kristina" },
                new Customer { Name = "Mindaugas" },
                new Customer { Name = "Dovile" },
                new Customer { Name = "Justinas" }
            };

            var viewModel = new SingleMovieViewModel
            {
                Movie = movies[id]
            };

            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDates(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Edit(int id)
        {
            return Content("<h2>id = " + id + "</h2>");
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if(!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if(String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex = {0}; sortBy = {1}", pageIndex, sortBy));

        }

    }
}