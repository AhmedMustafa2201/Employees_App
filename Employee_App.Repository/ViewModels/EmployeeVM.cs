using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee_App.Data.Domain;

namespace Employee_App.Repository.ViewModels
{
    public class EmployeeVM
    {
        [Display(Name = "Name")]
        [Required]
        public string Full_Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("[0-9]{11}")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression("[0-9]{3,4}")]
        public int Salary { get; set; }

        [Display(Name = "Department")]
        public List<Departments> DepartmentsList { get; set; }
        
    }

    public class EmployeeDetailsVM
    {
        [Display(Name = "Name")]
        [Required]
        public string Full_Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("[0-9]{11}")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression("[0-9]{3,4}")]
        public int Salary { get; set; }

        [Display(Name = "Department")]
        public Departments Department { get; set; }

    }

    public class EmployeeMaxMin
    {
        public int salary_max { get; set; }
        public int salary_min { get; set; }
    }

}
