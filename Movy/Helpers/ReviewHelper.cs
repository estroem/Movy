using Movy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movy.Helpers
{
    public class ReviewHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ReviewHelper(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddReview(Review review)
        {
            db.Reviews.Add(review);
            review.Movie.Reviews.Add(review);
            db.SaveChanges();
        }
    }
}