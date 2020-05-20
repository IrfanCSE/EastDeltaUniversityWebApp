using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Gateway
{
    public class CourseGateway
    {
        private ApplicationDbContext _context;
        public CourseGateway()
        {
            _context = new ApplicationDbContext();
        }

        public List<Semester> GetSemesters()
        {
            return _context.Semesters.ToList();
        }

        public int Save(Course course)
        {
            _context.Courses.Add(course);
            return _context.SaveChanges();
        }
    }
}