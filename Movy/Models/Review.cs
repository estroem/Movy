using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movy.Models
{
    public class Review
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Rating { get; set; }
        
        [Required]
        public virtual Movie Movie { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}