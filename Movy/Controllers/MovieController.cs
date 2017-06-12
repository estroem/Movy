using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movy.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Show()
        {
            return View();
        }
    }
}