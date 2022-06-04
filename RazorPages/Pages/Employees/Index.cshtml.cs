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
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository repo;
        public IndexModel(IEmployeeRepository _repo) 
        {
            this.repo = _repo;
        }
        public IEnumerable<Employee> Employees { get; set; }
        [BindProperty(SupportsGet = true)]
        public string search { get; set; }
        public void OnGet()
        {

            //Employees = repo.GetAllEmployees();
            Employees = repo.Search(search);
        }
    }
}