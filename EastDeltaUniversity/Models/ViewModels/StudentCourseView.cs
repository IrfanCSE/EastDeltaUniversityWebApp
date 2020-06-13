using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EastDeltaUniversity.Context;

namespace EastDeltaUniversity.Models.ViewModels
{
    public partial class StudentCourseView
    {
        public int Id { get; set; }

        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public StudentView Student { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public CourseView Course { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool IsActive { get; set; }
    }

    public partial class StudentCourseView : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            var _context = new ApplicationDbContext();

            var student = _context.StudentCourses.FirstOrDefault(x =>
                x.StudentId == StudentId && x.CourseId == CourseId && x.IsActive == true);

            if (student != null)
            {
                result.Add(new ValidationResult("Student Have This Course", new[] { "CourseId" }));
            }

            return result;
        }
    }

}