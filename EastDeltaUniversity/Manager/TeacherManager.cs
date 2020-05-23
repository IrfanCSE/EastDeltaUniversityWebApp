using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Gateway;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Manager
{
    public class TeacherManager
    {
        private TeacherGateway _teacherGateway;

        public TeacherManager()
        {
            _teacherGateway = new TeacherGateway();
        }

        public List<Designation> GetDesignations()
        {
            return _teacherGateway.GetDesignations();
        }

        public void Save(Teacher teacher)
        {
            _teacherGateway.Save(teacher);
        }

        public List<Teacher> TeachersByDepartment(int id)
        {
            return _teacherGateway.TeachersByDepartment(id);
        }

        public List<Course> CoursesByDepartment(int id)
        {
            return _teacherGateway.CoursesByDepartment(id);
        }

        public Teacher TeacherData(int id)
        {
            var teacher = _teacherGateway.TeacherData(id);
            teacher.CreditRemaining = teacher.Credit - teacher.CreditTaken;
            return teacher;
        }

        public Course CourseData(int id)
        {
            return _teacherGateway.CourseData(id);
        }

        public void Assign(TeacherAssign teacherAssign)
        {
            _teacherGateway.Assign(teacherAssign);
        }

    }
}