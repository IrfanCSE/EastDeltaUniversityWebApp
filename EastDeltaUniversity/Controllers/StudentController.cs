using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EastDeltaUniversity.Manager;
using EastDeltaUniversity.Models;
using EastDeltaUniversity.Models.ViewModels;

namespace EastDeltaUniversity.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager _studentManager;
        private DepartmentManager _departmentManager;
        private CourseManager _courseManager;

        public StudentController()
        {
            _departmentManager = new DepartmentManager();
            _studentManager = new StudentManager();
            _courseManager = new CourseManager();
        }


        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Registration()
       {
            ViewBag.DepartmentId=_departmentManager.GetDepartmentList();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DepartmentId = _departmentManager.GetDepartmentList();
                return View("Registration");
            }

            _studentManager.Save(student);
            return RedirectToAction("Preview",new{id=student.Id});
        }

        [HttpGet]
        public ActionResult Preview(int id)
        {
            var student =_studentManager.GetStudent(id);
            return View(student);
        }

        [HttpGet]
        public ActionResult Enroll()
        {
            ViewBag.StudentId = _studentManager.GetStudents();
            return View();
        }

        [HttpPost]
        public ActionResult Enroll(StudentCourseView studentCourse)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.StudentId = _studentManager.GetStudents();
                return View("Enroll",studentCourse);
            }

            _studentManager.Enroll(studentCourse);

            return RedirectToAction("Enroll","Student");
        }

        [HttpGet]
        public ActionResult Grading()
        {
            ViewBag.StudentId = _studentManager.GetStudents();
            ViewBag.GradeId = _studentManager.Grades();
            return View();
        }



        //JSON Result.

        public JsonResult StudentById(int studentId)
        {
            var student = _studentManager.StudentById(studentId);
            
            var studentInfo = new Student()
            {
                Name=student.Name,
                Email = student.Email,
                DepartmentName=student.Department.Name,
                DepartmentId = student.DepartmentId
            };

            return Json(studentInfo);
        }

        public JsonResult CourseByDepartment(int departmentId)
        {
            var course = _courseManager.CoursesByDepartment(departmentId);
            return Json(course);
        }

        public JsonResult CoursesByStudent(int studentId)
        {
            var courses=_studentManager.CoursesByStudent(studentId);
            return Json(courses);
        }


    }
}