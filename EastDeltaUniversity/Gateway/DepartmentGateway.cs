using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Context;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Gateway
{
    public class DepartmentGateway
    {
        private ApplicationDbContext _context;

        public DepartmentGateway()
        {
            _context = new ApplicationDbContext();
        }

        public void Save(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public List<Department> GetDepartmentList()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);
            return department;
        }

        public void Update(Department department)
        {
                _context.Entry(department).State = EntityState.Modified;
                _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = _context.Departments.SingleOrDefault(x => x.Id == id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
    }
}