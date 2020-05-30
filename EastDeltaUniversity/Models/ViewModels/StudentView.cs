using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EastDeltaUniversity.Models.ViewModels
{
    public class StudentView
    {

        public int Id { get; set; }

        public string Registration { get; set; }


        public string Name { get; set; }


        public string Email { get; set; }

        public string Contact { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Address { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

    }
}