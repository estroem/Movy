using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movy.Models;

namespace Movy.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string s)
        {
            ViewBag.NoMatch = false;

            if (String.IsNullOrWhiteSpace(s))
                return View();

            var movie = db.Movies.FirstOrDefault(m => m.Name == s);

            if (movie == null)
            {
                ViewBag.NoMatch = true;
                return View();
            }

            return RedirectToAction("Details", "Movies", new { id = movie.Id });
        }
    }
}