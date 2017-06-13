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
    }
}