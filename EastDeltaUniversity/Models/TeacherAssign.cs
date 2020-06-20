using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;

namespace EastDeltaUniversity.Models
{
    public partial class TeacherAssign
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "The Teacher field is required")]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required(ErrorMessage = "The Course field is required")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [NotMapped]
        public int Credit { get; set; }

        [NotMapped]
        public bool UpdateMode { get; set; }

    }

    public partial class TeacherAssign:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results= new List<ValidationResult>();

            if (UpdateMode==true)
            {
                return results;
            }

            ApplicationDbContext _context = new ApplicationDbContext();

            var course = _context.TeacherAssigns.FirstOrDefault(x => x.CourseId == CourseId && x.IsActive == true);
            if (course != null)
            {
                results.Add(new ValidationResult("Course Already Assigned", new[] { "CourseId" }));
            }

            var teacher = _context.TeacherAssigns.FirstOrDefault(x => x.CourseId == CourseId && x.TeacherId == TeacherId);
            if (teacher != null)
            {
                results.Add(new ValidationResult("Teacher Have This Course", new[] { "TeacherId" }));
            }

            return results;
        }
    }

}