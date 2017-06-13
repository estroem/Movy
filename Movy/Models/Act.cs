using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movy.Models
{
    public class Act
    {
        public int Id { get; set; }
        public virtual Character Character { get; set; }
        public virtual Person Person { get; set; }
        public virtual Movie Movie { get; set; }
    }
}