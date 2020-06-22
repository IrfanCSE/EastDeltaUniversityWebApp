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

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.DepartmentId = _departmentManager.GetDepartmentList();

            return View();
        }

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

        [HttpGet]
        public ActionResult Unassign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnassignClasses()
        {
            _classManager.Unassign();
            return RedirectToAction("Index", "Class");
        }

        [HttpGet]
        public ActionResult Room()
        {
            var rooms=_classManager.GetRooms();
            return View(rooms);
        }

        [HttpGet]
        public ActionResult RoomCreate(int? id)
        {
            if (id != null)
            {
            var room = _classManager.GetRoomById(id);
            room.EditMode = true;
            return View(room);
            }
            return View();
        }

        [HttpPost]
        public ActionResult RoomCreate(Room room)
        {
            if (!ModelState.IsValid)
            {
                return View("RoomCreate", room);
            }
            _classManager.RoomSave(room);
            return RedirectToAction("RoomCreate", "Class");
        }

        public ActionResult RoomEdit(int id)
        {
            return RedirectToAction("RoomCreate", "Class",new {id=id});
        }

        public ActionResult RoomDelete(int id)
        {
            _classManager.RoomDelete(id);
            return RedirectToAction("Room", "Class");
        }





        //JSON Result

        public JsonResult CoursesByDepartment(int departmentId)
        {
            var course = _courseManager.CoursesByDepartment(departmentId);
            return Json(course);
        }

        public JsonResult ClassInfo(int departmentId)
        {
            var classInfo=_classManager.ClassInfo(departmentId);
            return Json(classInfo);
        }
        
    }
}