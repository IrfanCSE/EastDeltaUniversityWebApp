using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EastDeltaUniversity.Context;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Controllers
{
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext _context;
        public DepartmentsController()
        {
            _context= new ApplicationDbContext();
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

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
            _context.Departments.Add(department);
            _context.SaveChanges();
            TempData["message"] = "Saved";
            return RedirectToAction("Create");
        }
    }
}