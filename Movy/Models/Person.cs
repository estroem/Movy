using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movy.Models
{
    public class Person
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string Name
        {
            get
            {
                return String.Format("{0} {1}", Firstname, Lastname);
            }
        }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}