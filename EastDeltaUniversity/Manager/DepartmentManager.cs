using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EastDeltaUniversity.Gateway;
using EastDeltaUniversity.Models;

namespace EastDeltaUniversity.Manager
{
    public class DepartmentManager
    {
        readonly DepartmentGateway _departmentGateway;
        public DepartmentManager()
        {
            _departmentGateway = new DepartmentGateway();
        }

        public void Save(Department department)
        {
            _departmentGateway.Save(department);
        }
        public List<Department> GetDepartmentList()
        {
            return _departmentGateway.GetDepartmentList();
        }
        public Department GetDepartment(int id)
        {
            return _departmentGateway.GetDepartment(id);
        }

        public void Update(Department department)
        {
            _departmentGateway.Update(department);
        }

        public void Delete(int id)
        {
            _departmentGateway.Delete(id);
        }
    }
}