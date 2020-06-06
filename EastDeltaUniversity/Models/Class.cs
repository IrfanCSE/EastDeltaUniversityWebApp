using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EastDeltaUniversity.Context;

namespace EastDeltaUniversity.Models
{
    public partial class Class
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        [Display(Name = "Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required]
        [Display(Name = "Day")]
        public int DayId { get; set; }
        public Day Day { get; set; }

        [Required]
        [Display(Name = "From")]
        public TimeSpan FromTime { get; set; }

        [Required]
        [Display(Name = "To")]
        public TimeSpan ToTime { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        [Display(Name ="From")]
        [DataType(DataType.Time)]
        public DateTime FTime { get; set; }
        
        [NotMapped]
        [Display(Name ="To")]
        [DataType(DataType.Time)]
        public DateTime TTime { get; set; }
    }

    public partial class Class:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            var _context = new ApplicationDbContext();

            FromTime = FTime.TimeOfDay;
            ToTime = TTime.TimeOfDay;

            var course = _context.Classes.FirstOrDefault(x => x.DayId == DayId && x.CourseId == CourseId);
            if (course != null)
            {
                result.Add(new ValidationResult("Course Assigned This Day",new []{ "CourseId" }));
            }

            if (FromTime>=ToTime)
            {
                result.Add(new ValidationResult("Invalid Time Selection",new []{ "FTime", "TTime" }));
            }

            var classList=_context.Classes.Where(x => x.DayId == DayId && x.RoomId == RoomId).ToList();
            foreach (var dbClass in classList)
            {
                if ((dbClass.FromTime==FromTime && dbClass.ToTime==ToTime) || 
                    (FromTime<dbClass.FromTime && dbClass.FromTime<ToTime) || 
                    (FromTime < dbClass.ToTime && dbClass.ToTime < ToTime) || 
                    (dbClass.FromTime<FromTime && ToTime<dbClass.ToTime))
                {
                    result.Add(new ValidationResult("Class Time Overlaping",new []{"FTime","TTime"}));
                }
            }

            return result;
        }
    }

}