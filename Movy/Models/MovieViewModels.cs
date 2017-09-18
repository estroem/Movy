using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movy.Models
{
    public class UploadTrailerViewModel
    {
        public Movie Movie { get; set; }
        public bool Uploaded { get; set; }
        public bool Successful { get; set; }
    }
}