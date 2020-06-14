using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Letter { get; set; }
        public double Point { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}