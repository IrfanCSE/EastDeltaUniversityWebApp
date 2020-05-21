using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;

namespace EastDeltaUniversity.Models
{
    public partial class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(7,MinimumLength = 2,ErrorMessage = "Code Must Be Minimum 2 and Maximum 7 Letter.")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Teacher> Teachers { get; set; }

        [NotMapped]
        public bool EditMode { get; set; }
    }

    public partial class Department:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (EditMode)
            {
                return results;
            }

            ApplicationDbContext _context = new ApplicationDbContext();
            var code = _context.Departments.FirstOrDefault(x => x.Code == Code.ToUpper());
            var name = _context.Departments.FirstOrDefault(x=>x.Name==Name.ToUpper());
            if (code != null)
            {
                results.Add(new ValidationResult("Duplicate Code!",new[]{"Code"}));
            }
            if (name != null)
            {
                results.Add(new ValidationResult("Duplicate Name!", new[] { "Name" }));
            }
            return results;
        }
    }
}