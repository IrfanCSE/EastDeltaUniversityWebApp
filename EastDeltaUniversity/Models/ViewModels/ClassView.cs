using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.ViewModels
{
    public class ClassView
    {
        public int DepartmentId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseInfo { get; set; }
    }
}