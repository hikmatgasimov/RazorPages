using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RazorPages.Services
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee addemployee)
        {
            //context.Employees.Add(addemployee);
            //context.SaveChanges();

            context.Database.ExecuteSqlRaw("spInsertEmployee {0}, {1}, {2}", addemployee.Name, addemployee.Email, addemployee.Department);
            return addemployee;
        }

        public Employee Delete(int Id)
        {
            Employee emp = context.Employees.Find(Id);
            if (emp != null)
            {
                context.Remove(emp);
                context.SaveChanges();
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
            // return context.Employees.FromSqlRaw<Employee>("select * from employees").ToList();
        }

        public Employee GetEmployee(int id)
        {
            ///return context.Employees.Find(id);
            return context.Employees.FromSqlRaw<Employee>("spGetEmployeeById {0}", id).ToList().FirstOrDefault();
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Employees;
            }
            return context.Employees.Where(e => e.Name.Contains(searchTerm) || e.Email.Contains(searchTerm));
        }

        public Employee Update(Employee updateemployee)
        {
            var emp = context.Attach(updateemployee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateemployee;
        }
    }
}
