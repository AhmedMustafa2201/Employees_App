using System;
using System.Collections.Generic;

namespace Employee_App.Data.Domain
{
    public class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}