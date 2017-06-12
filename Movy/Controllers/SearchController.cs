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
        public ActionResult Index(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return View();
            return Content(s);
        }
    }
}