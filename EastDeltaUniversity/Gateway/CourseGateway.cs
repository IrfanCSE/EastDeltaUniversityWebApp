using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;
using EastDeltaUniversity.Models;
using EastDeltaUniversity.Models.ViewModels;

namespace EastDeltaUniversity.Gateway
{
    public class CourseGateway
    {
        private ApplicationDbContext _context;
        public CourseGateway()
        {
            _context = new ApplicationDbContext();
        }

        // Constant Field
        private const int Zero = 0;

        
        //All Methods

        public List<Semester> GetSemesters()
        {
            return _context.Semesters.ToList();
        }

        public int Save(Course course)
        {
            _context.Courses.Add(course);
            return _context.SaveChanges();
        }

        public List<CourseView> CourseDataByDepartment(int id)
        {
            var courseInfo = new List<CourseView>();
            
            var courseList = _context.Courses.Where(x => x.DepartmentId == id).Include(x=>x.Semester).ToList();
            
            foreach (var course in courseList)
            {
                var assign = _context.TeacherAssigns.Where(x => x.CourseId == course.Id && x.IsActive == true).Include(x=>x.Teacher).FirstOrDefault();
                
                var data = new CourseView
                {
                    Code = course.Code, 
                    Name = course.Name, 
                    SemesterName = course.Semester.Name
                };
                
                if (assign != null)
                {
                    data.TeacherName = assign.Teacher.Name;
                    courseInfo.Add(data);
                }
                else
                {
                    data.TeacherName = "Not Assigned Yet";
                    courseInfo.Add(data);
                }
            }

            return courseInfo;
        }

        public List<Course> CoursesByDepartment(int id)
        {
            return _context.Courses.Where(x => x.DepartmentId == id).ToList();
        }

        public void UnassignCourses()
        {
            var courses=_context.StudentCourses.Where(x => x.IsActive == true).ToList();
            foreach (var course in courses)
            {
                course.IsActive = false;
            }

            _context.SaveChanges();
        }
        

    }
}