using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Gateway;
using EastDeltaUniversity.Models;
using EastDeltaUniversity.Models.ViewModels;

namespace EastDeltaUniversity.Manager
{
    public class StudentManager
    {
        private StudentGateway _studentGateway;

        public StudentManager()
        {
            _studentGateway = new StudentGateway();
        }


        public void Save(Student student)
        {
            student.Registration=GetRegistration(student.DepartmentName, student.Date, student.DepartmentId);

            _studentGateway.Save(student);
        }

        public string GetRegistration(string name, DateTime date, int departmentId)
        {
            var number=_studentGateway.StudentCount(departmentId);
            number += 1;
            string serial="";
            if (number<100)
            {
                var num = number.ToString();
                serial =num.PadLeft(3, '0');
            }

            string registration = name + "-" + date.Year + "-"+serial;

            return registration;
        }

        public StudentView GetStudent(int id)
        {
            return _studentGateway.GetStudent(id);
        }

        public List<Student> GetStudents()
        {
            return _studentGateway.GetStudents();
        }

        public Student StudentById(int id)
        {
            return _studentGateway.StudentById(id);
        }

        public void Enroll(StudentCourseView studentCourse)
        {
            var student = new StudentCourse()
            {
                CourseId=studentCourse.CourseId,
                StudentId=studentCourse.StudentId,
                Date=studentCourse.Date,
                IsActive=studentCourse.IsActive
            };

            _studentGateway.Enroll(student);
        }


    }
}