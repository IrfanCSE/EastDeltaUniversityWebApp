using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Gateway
{
    public class TeacherGateway
    {
        private ApplicationDbContext _context;

        public TeacherGateway()
        {
            _context = new ApplicationDbContext();
        }

        public List<Designation> GetDesignations()
        {
            return _context.Designations.ToList();
        }

        public void Save(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public List<Teacher> TeachersByDepartment(int id)
        {
            return _context.Teachers.Where(x => x.DepartmentId == id).ToList();
        }

        public List<Course> CoursesByDepartment(int id)
        {
            return _context.Courses.Where(x => x.DepartmentId == id).ToList();
        }

        public Teacher TeacherData(int id)
        {
            return _context.Teachers.FirstOrDefault(x => x.Id == id);
        }

        public Course CourseData(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }

        public void Assign(TeacherAssign teacherAssign)
        {
            _context.TeacherAssigns.Add(teacherAssign);
            _context.SaveChanges();
        }
    }
}