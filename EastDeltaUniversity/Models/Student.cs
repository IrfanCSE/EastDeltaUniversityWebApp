using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;

namespace EastDeltaUniversity.Models
{
    public partial class Student
    {
        [Display(Name = "Student")]
        public int Id { get; set; }
        
        [Display(Name = "Registration")]
        public string Registration { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contact")]
        [Phone]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Contact Number Should Be Valid")]
        public string Contact { get; set; }
        
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

        [NotMapped]
        public string DepartmentName { get; set; }

        [NotMapped]
        public bool EditMode { get; set; }
    }

    public partial class Student:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (EditMode == true)
                return results;

            ApplicationDbContext _context = new ApplicationDbContext();

            var email = _context.Students.FirstOrDefault(x=>x.Email==Email);
            if (email != null)
            {
                results.Add(new ValidationResult("Duplicate Email", new[] { "Email" }));
            }

            var contact = _context.Students.FirstOrDefault(x => x.Contact == Contact);
            if (contact != null)
            {
                results.Add(new ValidationResult("Duplicate Contact No", new[] { "Contact" }));
            }
            return results;

        }
    }
}