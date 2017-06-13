using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movy.Models
{
    public class Movie
    {
        public const int MAX_RATING = 10;

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Director")]
        public virtual ICollection<Person> Directors { get; set; }

        [DisplayName("Starring")]
        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public int GetAverageRating() {
            if (Reviews.Count == 0)
                return 0;
            int sum = 0;
            foreach(Review review in Reviews)
                sum += review.Rating;
            return sum / Reviews.Count;
        }
    }
}