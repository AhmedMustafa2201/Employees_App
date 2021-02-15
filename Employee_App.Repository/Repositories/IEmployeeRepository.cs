using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee_App.Data.Domain;
using Employee_App.Repository.ViewModels;

namespace Employee_App.Repository.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAllEmployees();
        void AddEmployee(EmployeeVM empClient, int Department_ID);
        IQueryable<Employee> GetByID(int id);
        DbRawSqlQuery<EmployeeMaxMin> GetMaxMin();
    }
}
