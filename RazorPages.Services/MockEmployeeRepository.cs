using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RazorPages.Services
{
   public  class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> LE;
        public MockEmployeeRepository()
        {
            LE = new List<Employee>()
           {
               new Employee{Id=1,Name="Hikmet",Email="hikmet@mail.ru",Department=Dept.IT},
               new Employee{Id=2,Name="Fikret",Email="fikret@mail.ru",Department=Dept.Payroll},
               new Employee{Id=3,Name="Serxan",Email="Serxan@mail.ru",Department=Dept.HR},
               new Employee{Id=4,Name="Emil",Email="Emil@mail.ru",Department=Dept.None},
           };
        }

        public Employee Add(Employee addemployee)
        {
            addemployee.Id = LE.Max(e => e.Id) + 1;
            LE.Add(addemployee);
            return addemployee;

        }

        public Employee Delete(int Id)
        {
            Employee emp = LE.FirstOrDefault(e => e.Id == Id);
            if (emp != null)
            {
                LE.Remove(emp);
            }
            return emp;
        }

        //public IEnumerable<DeptHeadCount> EmployeeCountByDept()
        //{
        //    return LE.GroupBy(e => e.Department)
        //         .Select(g => new DeptHeadCount()
        //         {
        //             Department = g.Key.Value,
        //             count = g.Count()
        //         }); ; ;
        //}

        public IEnumerable<Employee> GetAllEmployees()
        {
            return LE;
        }

        public Employee GetEmployee(int id)
        {
            return LE.Find(e => e.Id == id);
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return LE;
            }
            else
            {
                return LE.Where(e => e.Name.Contains(searchTerm) || e.Email.Contains(searchTerm));
            }
        }

        public Employee Update(Employee updateemployee)
        {
            Employee emp = LE.Find(e => e.Id == updateemployee.Id);

            if (emp != null)
            {
                emp.Name = updateemployee.Name;
                emp.Email = updateemployee.Email;
                emp.Department = updateemployee.Department;
            }
            return emp;
        }
    }
}
