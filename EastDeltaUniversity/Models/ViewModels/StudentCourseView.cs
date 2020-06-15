using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Grade")]
        public int? GradeId { get; set; }
        public Grade Grade { get; set; }

        public bool Grading { get; set; }
    }

    public partial class StudentCourseView : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            var _context = new ApplicationDbContext();

            if (Grading==true)
            {
                //var IsGraded = _context.StudentCourses.Where(x =>
                //    x.StudentId == StudentId && x.CourseId == CourseId &&
                //    x.IsActive == true && x.GradeId != null).Single();

                //if (IsGraded != null)
                //{
                //    result.Add(new ValidationResult("Course Already Graded for this student",new []{"CourseId"}));
                //}
                return result;
            }

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