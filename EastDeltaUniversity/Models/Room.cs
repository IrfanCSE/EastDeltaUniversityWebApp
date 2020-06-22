using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;

namespace EastDeltaUniversity.Models
{
    public partial class Room
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public ICollection<Class> Classes { get; set; }

        [NotMapped]
        public bool EditMode { get; set; }
    }

    public partial class Room:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            var _context = new ApplicationDbContext();

            if (EditMode == true)
                return result;

            var isRoomExist=_context.Rooms.FirstOrDefault(x => x.Name == Name);
            if (isRoomExist != null)
            {
                result.Add(new ValidationResult("Duplicate Room Name!",new []{"Name"}));
            }

            return result;
        }
    }

}