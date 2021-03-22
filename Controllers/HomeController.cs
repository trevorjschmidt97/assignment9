using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrevorSchmidtAssignment3.Models;

namespace TrevorSchmidtAssignment3.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDBContext context { get; set; }

        //Added these two in to check when to delete the movie if editing it
        private static Movie? movieToDelete { get; set; }
        private static bool fromEdit { get; set; } = false;

        public HomeController(MoviesDBContext con)
        {
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        // I utilized this function to also edit movies
        [HttpPost]
        public IActionResult EnterMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // If youre coming from editing the movie, you need to delete the old one
                if (fromEdit)
                {
                    context.movies.Remove(movieToDelete);
                    context.SaveChanges();
                }

                context.movies.Add(movie);
                context.SaveChanges();

                fromEdit = false;
                movieToDelete = null;
                return View("Confirmation");
            } else
            {
                return View();
            } 
        }

        public IActionResult MoviesList()
        {
            return View(context.movies);
        }

        // My edit function
        public IActionResult EditMovie(Movie movie)
        {
            fromEdit = true;
            movieToDelete = movie;
            return View("EnterMovie", movie);
        }

        // My delete function
        public IActionResult RemoveMovie(Movie movie)
        {
            context.movies.Remove(movie);
            context.SaveChanges();
            return View("MoviesList", context.movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
