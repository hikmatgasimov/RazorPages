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
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository repo;
        public DeleteModel(IEmployeeRepository _repo)
        {
            this.repo = _repo;
        }
        [BindProperty]
        public Employee employees { get; set; }
        public IActionResult OnGet(int id)
        {
            employees = repo.GetEmployee(id);

            return Page();
        }
        public IActionResult OnPost()
        {
            employees = repo.Delete(employees.Id);

            return RedirectToPage("Index");
        }
    }
}