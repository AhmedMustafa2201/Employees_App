using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee_APP.Data;
using Employee_App.Data.Domain;
using Employee_App.Repository.Repositories;
using Employee_App.Repository.ViewModels;

namespace Employee_App.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _context;

        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public IQueryable<Employee> GetAllEmployees()
        {
            return _context.Employee;
        }

        public void AddEmployee(EmployeeVM empClient, int Department_ID)
        {
            _context.Database.ExecuteSqlCommand("[dbo].[EmployeeC] @Full_Name, @Address, @Email, @Phone, @Salary, @department_id",
                new SqlParameter("@Full_Name", empClient.Full_Name),
                new SqlParameter("@Address", empClient.Address),
                new SqlParameter("@Email", empClient.Email),
                new SqlParameter("@Phone", empClient.Phone),
                new SqlParameter("@Salary", empClient.Salary),
                new SqlParameter("@department_id", Department_ID)
                );
        }

        public IQueryable<Employee> GetByID(int id)
        {
            return _context.Employee.Include(e=>e.Department).Where(e => e.Id == id);
        }

        public DbRawSqlQuery<EmployeeMaxMin> GetMaxMin()
        {
            return _context.Database.SqlQuery<EmployeeMaxMin>("[dbo].[GetMaxMinSalary]");
        }

    }
}