using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspnet.Models;
using aspnet.ViewModels;
using System.Data.Entity;

namespace aspnet.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult AddMovie()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };
            return View("EditOrAddMovie", viewModel);
        }

        [Route("movies/edit/{id}")]
        public ActionResult EditMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("EditOrAddMovie", viewModel);

        }

        [HttpPost]
        public ActionResult CreateMovie(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                //movieInDb.Description = movie.Description;
                //movieInDb.ReleaseDate = movie.ReleaseDate;
                //movieInDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Route("movies/details/{id}")]
        public ActionResult SingleMovie(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(mov => mov.Id == id);
            return View(movie);
        }

    }
}