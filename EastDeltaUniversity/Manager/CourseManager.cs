using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Gateway;
using EastDeltaUniversity.Models;
using EastDeltaUniversity.Models.ViewModels;

namespace EastDeltaUniversity.Manager
{
    public class CourseManager
    {
        private CourseGateway _courseGateway;

        public CourseManager()
        {
            _courseGateway = new CourseGateway();
        }

        public List<Semester> GetSemesters()
        {
            return _courseGateway.GetSemesters();
        }

        public string Save(Course course)
        {
            var result = _courseGateway.Save(course);
            if (result>0)
            {
                return "Data Saved";
            }
            else
            {
                return "Failed";
            }
        }

        public List<CourseView> CourseDataByDepartment(int id)
        {
            return _courseGateway.CourseDataByDepartment(id);
        }

        public List<Course> CoursesByDepartment(int id)
        {
            return _courseGateway.CoursesByDepartment(id);
        }

    }
}