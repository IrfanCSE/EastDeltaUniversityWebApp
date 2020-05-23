using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;

namespace EastDeltaUniversity.Models
{
    public partial class Teacher
    {
        [Display(Name = "Teacher")]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        [RegularExpression(@"^(\d{11})$",ErrorMessage = "Contact No Should Be Valid")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        
        [Required]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        [Display(Name = "Credit To Be Taken")]
        [Range(0,Int32.MaxValue,ErrorMessage = "Credit Must Be Non-Negative Number")]
        public int Credit { get; set; }

        public int CreditTaken { get; set; }

        [NotMapped]
        [Display(Name = "Credit Remaining")]
        public int CreditRemaining { get; set; }

        [NotMapped]
        public bool EditMode { get; set; }

        public ICollection<TeacherAssign> TeacherAssigns { get; set; }
    }

    public partial class Teacher:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (EditMode == true)
                return results;

            ApplicationDbContext _context = new ApplicationDbContext();

            var email=_context.Teachers.FirstOrDefault(x => x.Email == Email);
            if (email != null)
            {
                results.Add(new ValidationResult("Duplicate Email",new[]{"Email"}));
            }

            var contact = _context.Teachers.FirstOrDefault(x => x.ContactNo == ContactNo);
            if (contact != null)
            {
                results.Add(new ValidationResult("Duplicate Contact No", new[] { "ContactNo" }));
            }
            return results;
        }
    }
}