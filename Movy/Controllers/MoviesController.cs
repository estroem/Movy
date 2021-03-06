﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movy.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace Movy.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult UploadTrailer(int id)
        {
            Movie movie = db.Movies.Find(id);
            UploadTrailerViewModel UTViewModel = new UploadTrailerViewModel { Movie = movie, Uploaded = false};
            return View(UTViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UploadTrailer(int id, HttpPostedFileBase file)
        {
            Movie movie = db.Movies.Find(id);

            if (movie == null)
            {
                // movie not found
            }

            bool success = false;

            try
            {
                if (file.ContentLength > 0 && file.FileName.Contains(".mp4"))
                {
                    string path = Path.Combine(Server.MapPath("~/Trailers"), id.ToString() + ".mp4");
                    file.SaveAs(path);

                    success = true;
                }
            }
            catch
            {
                success = false;
            }

            UploadTrailerViewModel UTViewModel = new UploadTrailerViewModel { Movie = movie, Uploaded = true, Successful = success };

            return View(UTViewModel);
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult AddReview(int rating, string reviewText, int movieId)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var movie = db.Movies.Find(movieId);
            var review = new Review { Rating = rating, Text = reviewText, Movie = movie, User = user };

            movie.Reviews.Add(review);

            db.Reviews.Add(review);
            db.SaveChanges();
            
            return Content("Review Added Successfully");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
