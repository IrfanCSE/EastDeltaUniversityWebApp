using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models
{
    public class Course
    {
        public int Id { get; set; }
        
        public string Code { get; set; }
        
        public string Name { get; set; }
        
        public int Credit { get; set; }
        
        public string Description { get; set; }
        
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
    }
}