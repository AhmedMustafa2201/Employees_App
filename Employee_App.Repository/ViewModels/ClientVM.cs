using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee_App.Data.Domain;

namespace Employee_App.Repository.ViewModels
{
    public class ClientVM
    {
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("[0-9]{11}")]
        public string Phone { get; set; }
        [Display(Name = "Employee")]
        public List<Employee> EmployeeList { get; set; }

    }
}
