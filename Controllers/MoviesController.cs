using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieWebApp.Models;
using MovieWebApp.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;

namespace MovieWebApp.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/
        //
        // GET: /Customers/
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

       
 
        public ViewResult Index()
        {
            List<Movie> movies = _context.Movies.Include(x => x.Genre).ToList(); // Eager Loading (Include..)

            var viewModel = new RandomMovieModel
            {
                Movies = movies
            };

            return View(viewModel);
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.ID == id); // Eager Loading (Include..)

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }



        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                //Movie = new Movie(), // to avoid the validation errors like: The ID field is required.
                Genres = genres
            };

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);

            }


            if (movie.ID == 0)
            {
                _context.Movies.Add(movie);
            }
            else // existing movie
            {
                var existingMovie = _context.Movies.Single(c => c.ID == movie.ID);

                existingMovie.GenreId = movie.GenreId;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies"); // "action" , "Controller"
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.ID == id);

            if (movie == null)
                return new HttpNotFoundResult();

            var viewModel = new MovieFormViewModel(movie)
            {
               Genres =  _context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }



        
	}
}