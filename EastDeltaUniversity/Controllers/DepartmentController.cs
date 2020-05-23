using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EastDeltaUniversity.Context;
using EastDeltaUniversity.Manager;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Controllers
{
    public class DepartmentController : Controller
    {
        private ApplicationDbContext _context;
        private DepartmentManager _departmentManager;
        public DepartmentController()
        {
            _departmentManager = new DepartmentManager();
            _context= new ApplicationDbContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var department=_departmentManager.GetDepartmentList();
            return View(department);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.message=TempData["message"];
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", department);
            }
            _departmentManager.Save(department);
            TempData["message"] = "Saved";
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var department = _departmentManager.GetDepartment(id);
            return View(department);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = _departmentManager.GetDepartment(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Update(Department department)
        {
            _departmentManager.Update(department);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var department = _departmentManager.GetDepartment(id);
            return View(department);
        }
        
        [HttpPost]
        public ActionResult Delete(Department department)
        {
            _departmentManager.Delete(department.Id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}