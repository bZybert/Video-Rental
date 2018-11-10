using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoRental.Models;
using VideoRental.ViewModel;

namespace VideoRental.Controllers
{
    public class MoviesController : Controller
    {
        private EFCContext _context;

        public MoviesController()
        {
            _context = new EFCContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();
            return View(movie);
        }

        public IActionResult Details(int id)
        {

            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return Content("Nie znaleziono");

            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            var viewModel = new NewMovieFormViewModel(movie)
            {
                
               

                Genres = _context.Genre.ToList()
            };
            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieFormViewModel(movie)
                {
                   
                    Genres = _context.Genre.ToList()
                };

                return View("MoviesForm", viewModel);
            }

            if (movie.Id == 0)  // sprawdzamy czy movie jest nowy
            {
                _context.Movies.Add(movie);
            }
            else  // jeżeli nie wyszukujemy w bazie 
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);

                // TryUpdateModelAsync(customer);
                //przypisyjemy ręcznie lub alternatywa  AutoMapper  Mapper.Map(customer,customerInDb)
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");


        }

        public IActionResult New()
        {
            var genre = _context.Genre.ToList();

            var viewModel = new NewMovieFormViewModel
            {
                Genres = genre
            };
            return View("MoviesForm", viewModel);
        }

        


    }
}