using System.ComponentModel.DataAnnotations;

namespace EastDeltaUniversity.Models.ViewModels
{
    public class TeacherView
    {
        [Display(Name = "Teacher")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Credit To Be Taken")]
        public int Credit { get; set; }

        public int CreditTaken { get; set; }

        [Display(Name = "Credit Remaining")]
        public int CreditRemaining { get; set; }
    }
}