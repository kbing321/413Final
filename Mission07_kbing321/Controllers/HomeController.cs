using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission07_kbing321.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission07_kbing321.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext movieContext { get; set; }

        public HomeController(MovieContext mc)
        {
            movieContext = mc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Baconsale()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            return View("NewMovie", new MovieEntryForm());
        }

        [HttpPost]
        public IActionResult NewMovie(MovieEntryForm mef)
        {
            if (ModelState.IsValid)
            {
                // add and save movie info from html form to db
                movieContext.Add(mef);
                movieContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                return View();
            }
            
            
        }
        // movielist action
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = movieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }

        //movie edit actions
        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movie = movieContext.Movies.Single(x => x.MovieId == movieid);

            return View("NewMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieEntryForm mef, int movieid)
        {
            if (ModelState.IsValid)
            {
                movieContext.Update(mef);
                movieContext.SaveChanges();

                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();

                var movie = movieContext.Movies.Single(x => x.MovieId == movieid);

                return View("NewMovie", movie);
            }
        }

        // movie delete actions
        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var movie = movieContext.Movies.Single(x => x.MovieId == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete (MovieEntryForm mef)
        {
            movieContext.Movies.Remove(mef);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
