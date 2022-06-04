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
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository repo;
        public DetailsModel(IEmployeeRepository _repo)
        {
            this.repo = _repo;
        }
        public Employee employees { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public IActionResult OnGet()
        {
          
            employees = repo.GetEmployee(Id);
            if (employees == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}