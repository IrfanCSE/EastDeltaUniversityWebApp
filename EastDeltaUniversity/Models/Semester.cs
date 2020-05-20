using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}