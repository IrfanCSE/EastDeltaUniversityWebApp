using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EastDeltaUniversity.Manager;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager _studentManager;
        private DepartmentManager _departmentManager;

        public StudentController()
        {
            _departmentManager = new DepartmentManager();
            _studentManager = new StudentManager();
        }


        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Registration()
       {
            ViewBag.DepartmentId=_departmentManager.GetDepartmentList();
            return View();
        }

        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DepartmentId = _departmentManager.GetDepartmentList();
                return View("Registration");
            }

          _studentManager.Save(student);
            var s = student;
            return RedirectToAction("Preview",new{id=student.Id});
        }

        public ActionResult Preview(int id)
        {
            var student =_studentManager.GetStudent(id);
            return View(student);
        }

    }
}