using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;

namespace EastDeltaUniversity.Models
{
    public partial class Course
    {
        [Display(Name = "Course")]
        public int Id { get; set; }
        
        [Required]
        [StringLength(10,MinimumLength = 5, ErrorMessage = "Code At-least 5 Characters Long")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(.5,5,ErrorMessage = "Credit Can't less than .5 and more than 5")]
        public int Credit { get; set; }
        
        public string Description { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public ICollection<TeacherAssign> TeacherAssigns { get; set; }

        public ICollection<Class> Classes { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }

    public partial class Course:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ApplicationDbContext _context = new ApplicationDbContext();

            Code = Code.ToUpper();
            var code = _context.Courses.FirstOrDefault(x => x.Code == Code);
            if (code != null)
            {
                results.Add(new ValidationResult("Duplicate Code",new[] {"Code"}));
            }

            Name = Name.ToUpper();
            var name = _context.Courses.FirstOrDefault(x => x.Name == Name);
            if (name != null)
            {
                results.Add(new ValidationResult("Duplicate Name", new[] { "Name" }));
            }

            return results;
        }
    }
}