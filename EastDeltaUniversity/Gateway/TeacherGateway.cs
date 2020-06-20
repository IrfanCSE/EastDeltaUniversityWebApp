using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        // Constant Field
        private const int Zero = 0;

        
        // Methods

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

        public int Assign(TeacherAssign teacherAssign)
        {
            _context.TeacherAssigns.Add(teacherAssign);
            return _context.SaveChanges();
        }

        public void AddCredit(int teacherId, int credit)
        {
            var teacher = _context.Teachers.SingleOrDefault(x => x.Id == teacherId);

            if (teacher != null)
            {
                teacher.CreditTaken += credit;
                teacher.EditMode = true;
                //_context.Entry(teacher).State=EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void UnassignTeacher()
        {
            var teachers = _context.TeacherAssigns.Where(x => x.IsActive == true).ToList();

            foreach (var teacher in teachers)
            {
                teacher.IsActive = false;
                teacher.UpdateMode = true;
            }

            _context.SaveChanges();
        }

        public void ResetTeacherCredit()
        {
            var teachersAssigns=_context.TeacherAssigns.Where(x => x.IsActive == true).ToList();
            foreach (var assign in teachersAssigns)
            {
                var teacher=_context.Teachers.FirstOrDefault(x => x.Id == assign.TeacherId);
                if (teacher != null)
                {
                    teacher.CreditTaken = Zero;
                    teacher.EditMode = true;
                    _context.SaveChanges();
                }
            }
        }
    }
}