using Movy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movy.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/ShowAll
        public ActionResult ShowAll()
        {
            var db = new ApplicationDbContext();
            List<Movie> movies = db.Movies.ToList();
            
            return View(movies);
        }

        // GET: Movie/Show
        public ActionResult Show()
        {
            return View();
        }

        // GET: Movie/Add
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            var db = new ApplicationDbContext();
            db.Movies.Add(movie);
            db.SaveChanges();

            return View();
        }
    }
}