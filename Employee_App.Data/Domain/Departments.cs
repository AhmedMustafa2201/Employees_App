using System.Collections.Generic;

namespace Employee_App.Data.Domain
{
    public class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}