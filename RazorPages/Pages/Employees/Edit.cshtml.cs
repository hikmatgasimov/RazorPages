using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository repo;
        public EditModel(IEmployeeRepository _repo)
        {
            this.repo = _repo;
        }
        [BindProperty]
        public Employee employees { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                employees = repo.GetEmployee(id.Value);
            }
            else
            {
                employees = new Employee();
            }
            //employees = repo.GetEmployee(Id);
        }
        public IActionResult OnPost()
        {
            if (employees.Id > 0)
            {
                employees = repo.Update(employees);
            }
            else
            {
                employees = repo.Add(employees);
            }
            return RedirectToPage("Index");
        }
    }
}