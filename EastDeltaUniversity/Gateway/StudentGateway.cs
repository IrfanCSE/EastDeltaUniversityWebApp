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
    public class StudentGateway
    {
        private ApplicationDbContext _context;

        public StudentGateway()
        {
            _context = new ApplicationDbContext();
        }


        public void Save(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public int StudentCount(int departmentId)
        {
            return _context.Students.Count(x => x.DepartmentId == departmentId);
        }

        public StudentView GetStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            return new StudentView()
            {
                Registration = student.Registration,
                Name = student.Name,
                Email = student.Email,
                Date = student.Date,
                Address = student.Address,
                Contact = student.Contact,
            };
        }

        public List<Student> GetStudents()
        {
            return _context.Students.OrderBy(x=>x.DepartmentId).ToList();
        }

        public Student StudentById(int id)
        {
            return _context.Students.Include(x=>x.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Enroll(StudentCourse studentCourse)
        {
            _context.StudentCourses.Add(studentCourse);
            _context.SaveChanges();
        }

        public List<StudentCourse> CoursesByStudent(int id)
        {
            return _context.StudentCourses.Where(x => x.StudentId == id && x.IsActive == true).Include(x=>x.Course).ToList();
        }

        public List<Grade> Grades()
        {
            return _context.Grades.ToList();
        }

        public void Grading(StudentCourse studentCourse)
        {
            var course = _context.StudentCourses.FirstOrDefault(x =>
                x.StudentId == studentCourse.StudentId && x.CourseId == studentCourse.CourseId && x.IsActive == true);

            if (course != null) course.GradeId = studentCourse.GradeId;

            _context.SaveChanges();
        }


    }
}