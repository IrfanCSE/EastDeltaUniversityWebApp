using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EastDeltaUniversity.Context;
using EastDeltaUniversity.Models;
using EastDeltaUniversity.Models.ViewModels;
using Microsoft.Ajax.Utilities;

namespace EastDeltaUniversity.Gateway
{
    public class ClassGateway
    {
        private ApplicationDbContext _context;

        public ClassGateway()
        {
            _context = new ApplicationDbContext();
        }

        public List<Room> GetRooms()
        {
            return _context.Rooms.ToList();
        }

        public List<Day> GetDays()
        {
            return _context.Days.ToList();
        }

        public void Allocate(Class aClass)
        {
            _context.Classes.Add(aClass);
            _context.SaveChanges();
        }

        public List<ClassView> ClassInfo(int departmentId)
        {
            var courseList=_context.Courses.Where(x => x.DepartmentId == departmentId).ToList();

            var classes = new List<ClassView>();

            foreach (var course in courseList)
            {
                var classList=_context.Classes.Include(x => x.Course).Include(x => x.Room).Include(x => x.Day)
                    .Where(x => x.CourseId == course.Id && x.IsActive==true).OrderBy(x=>x.DayId).ToList();
                
                var classInfo = new ClassView()
                {
                    CourseCode = course.Code,
                    CourseName = course.Name
                };

                if (classList.Count > 0)
                {
                    foreach (var aClass in classList)
                    {
                        classInfo.CourseInfo += aClass.Room.Name + " Day :" + aClass.Day.Name + " Time : " +
                                                aClass.FromTime + "-" + aClass.ToTime + "<br/>";
                    }
                }
                else
                {
                    classInfo.CourseInfo = "Not Scheduled Yet";
                }
                
                classes.Add(classInfo);
            }

            return classes;
        }


    }
}