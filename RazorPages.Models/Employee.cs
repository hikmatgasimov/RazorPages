using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPages.Models
{
    public  class Employee
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Email { get; set; }
        //public string name  { get; set; }
        public Dept? Department { get; set; }
    }
}
