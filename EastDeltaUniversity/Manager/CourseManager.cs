using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Gateway;
using EastDeltaUniversity.Models;

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
    }
}