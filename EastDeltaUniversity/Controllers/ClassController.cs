using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EastDeltaUniversity.Manager;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Controllers
{
    public class ClassController : Controller
    {
        private ClassManager _classManager;
        private DepartmentManager _departmentManager;
        private CourseManager _courseManager;

        public ClassController()
        {
            _classManager = new ClassManager();
            _departmentManager = new DepartmentManager();
            _courseManager = new CourseManager();
        }

        // GET: Class
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Allocate()
        {
            ViewBag.DepartmentId=_departmentManager.GetDepartmentList();
            ViewBag.RoomId = _classManager.GetRooms();
            ViewBag.DayId = _classManager.GetDays();

            return View();
        }

        [HttpPost]
        public ActionResult Allocate(Class aClass)
        {
            //aClass.FromTime = aClass.FTime.TimeOfDay;
            //aClass.ToTime = aClass.TTime.TimeOfDay;

            if (!ModelState.IsValid)
            {
                ViewBag.DepartmentId = _departmentManager.GetDepartmentList();
                ViewBag.RoomId = _classManager.GetRooms();
                ViewBag.DayId = _classManager.GetDays();

                return View("Allocate",aClass);
            }

            _classManager.Allocate(aClass);
            return RedirectToAction("Allocate");
        }


        //JSON Result

        public JsonResult CoursesByDepartment(int departmentId)
        {
            var course = _courseManager.CoursesByDepartment(departmentId);
            return Json(course);
        }
        
    }
}