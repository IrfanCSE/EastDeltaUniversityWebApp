using System.ComponentModel.DataAnnotations;


namespace EastDeltaUniversity.Models.ViewModels
{
    public class CourseView
    {
        [Display(Name = "Course")]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int Credit { get; set; }

        //public string Description { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
    }
}