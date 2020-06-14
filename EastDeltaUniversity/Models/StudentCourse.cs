using System;
using System.ComponentModel.DataAnnotations;

namespace EastDeltaUniversity.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Display(Name = "Grade")]
        public int? GradeId { get; set; }
        public Grade Grade { get; set; }

    }

}