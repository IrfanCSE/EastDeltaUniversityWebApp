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

        //Constatn Field
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
            var courseList = new List<CourseView>();
            var courses =
                _context.Courses.Include(x => x.Semester)
                    .Include(x => x.TeacherAssigns)
                    .Where(x => x.DepartmentId == id)
                    .ToList();

            foreach (var course in courses)
            {
                if (course.TeacherAssigns.Count != Zero)
                {
                    foreach (var teachers in course.TeacherAssigns)
                    {
                        var teacher = _context.Teachers.FirstOrDefault(x => x.Id == teachers.TeacherId);

                        var data = new CourseView()
                        {
                            Code = course.Code,
                            Name = course.Name,
                            SemesterName = course.Semester.Name,
                            TeacherName = teacher.Name
                        };
                        courseList.Add(data);
                    }

                }
                else
                {
                    var data = new CourseView()
                    {
                        Code = course.Code,
                        Name = course.Name,
                        SemesterName = course.Semester.Name,
                        TeacherName = "Not Assigned Yet"
                    };
                    courseList.Add(data);
                }
            }

            return courseList;
        }

        public List<Course> CoursesByDepartment(int id)
        {
            return _context.Courses.Where(x => x.DepartmentId == id).ToList();
        }
    }
}