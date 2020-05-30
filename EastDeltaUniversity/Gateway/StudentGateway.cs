﻿using System;
using System.Collections.Generic;
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

    }
}