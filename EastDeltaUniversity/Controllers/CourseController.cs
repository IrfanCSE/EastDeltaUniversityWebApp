using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EastDeltaUniversity.Manager;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Controllers
{
    public class CourseController : Controller
    {
        private CourseManager _courseManager;
        private DepartmentManager _departmentManager;

        public CourseController()
        {
            _courseManager = new CourseManager();
            _departmentManager = new DepartmentManager();
        }

        // GET: Course
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DepartmentId=_departmentManager.GetDepartmentList();
            ViewBag.SemesterId=_courseManager.GetSemesters();
            ViewBag.message=TempData["message"];
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", course);
            }
            TempData["message"]=_courseManager.Save(course);
            return RedirectToAction("Create");
        }
    }
}