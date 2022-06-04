using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPages.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Search(string searchTerm);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Update(Employee updateemployee);
        Employee Add(Employee addemployee);
        Employee Delete(int Id);
        //IEnumerable<DeptHeadCount> EmployeeCountByDept();
    }
}
