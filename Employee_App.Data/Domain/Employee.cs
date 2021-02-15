using System;
using System.Collections.Generic;

namespace Employee_App.Data.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int DepartmentId { get; set; }
        public Departments Department { get; set; }

        public ICollection<Clients> Client { get; set; }
    }
}