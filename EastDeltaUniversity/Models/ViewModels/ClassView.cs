using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.ViewModels
{
    public class ClassView
    {
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        
        [Display(Name = "Code")]
        public string CourseCode { get; set; }
        
        [Display(Name = "Name")]
        public string CourseName { get; set; }
        
        [Display(Name = "Course Info")]
        public string CourseInfo { get; set; }
    }
}