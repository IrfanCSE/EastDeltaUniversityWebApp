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
    public class TeacherController : Controller
    {
        private DepartmentManager _departmentManager;
        private TeacherManager _teacherManager;

        public TeacherController()
        {
            _departmentManager = new DepartmentManager();
            _teacherManager = new TeacherManager();
        }

        // GET: Teacher
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DepartmentId = _departmentManager.GetDepartmentList();
            ViewBag.DesignationId = _teacherManager.GetDesignations();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.DepartmentId = _departmentManager.GetDepartmentList();
                ViewBag.DesignationId = _teacherManager.GetDesignations();
                return View("Create", teacher);
            }
            _teacherManager.Save(teacher);
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Assign()
        {
            ViewBag.DepartmentId = _departmentManager.GetDepartmentList();

            return View();
        }

        [HttpPost]
        public ActionResult Assign(TeacherAssignView teacherAssignView,TeacherAssign teacherAssign)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DepartmentId = _departmentManager.GetDepartmentList();
                return View("Assign",teacherAssignView);
            }

            teacherAssign.Credit = teacherAssignView.Course.Credit;

            _teacherManager.Assign(teacherAssign);

            return RedirectToAction("Assign");
        }

        
        //JSON Result

        public JsonResult TeachersByDepartment(int departmentId)
        {
            var teachers=_teacherManager.TeachersByDepartment(departmentId);
            return Json(teachers);
        }

        public JsonResult CoursesByDepartment(int departmentId)
        {
            var courses = _teacherManager.CoursesByDepartment(departmentId);
            return Json(courses);
        }

        public JsonResult TeacherData(int teacherId)
        {
            var teacher=_teacherManager.TeacherData(teacherId);
            return Json(teacher);
        }

        public JsonResult CourseData(int courseId)
        {
            var course=_teacherManager.CourseData(courseId);
            return Json(course);
        }
    }
}