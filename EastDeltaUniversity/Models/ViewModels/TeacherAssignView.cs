using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.ViewModels
{
    public class TeacherAssignView
    {
        //public Department Department { get; set; }
        public CourseView Course { get; set; }
        public TeacherView Teacher { get; set; }
        public TeacherAssign TeacherAssign { get; set; }
    }
}