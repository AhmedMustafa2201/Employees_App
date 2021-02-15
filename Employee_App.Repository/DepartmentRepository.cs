using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using Employee_App.Data.Domain;
using Employee_APP.Repository.Repositories;
using Employee_App.Repository.ViewModels;

namespace Employee_APP.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBContext _context;
        public DepartmentRepository(ApplicationDBContext context)
        {
            _context = context;
        }


        public DbRawSqlQuery<JoinVM> GetAllDepartments()
        {
            //return _context.Departments;
            return _context.Database.SqlQuery<JoinVM>("[dbo].[GetAllDepartmentsWithEmployees]");
        }

        public DbRawSqlQuery<Count_Result> GetDepartmentClientCount()
        {
            return _context.Database.SqlQuery<Count_Result>("[dbo].[GetDepartmentClientCount]");
        }

        public DbRawSqlQuery<DepartmentVM> GetDetailedDepartment(int id)
        {
            return _context.Database.SqlQuery<DepartmentVM>("[dbo].[GetEmployeesForDepartment] @id",
                new SqlParameter("@id", id));
        }

        public IQueryable<Departments> GetSelectListDepartmants()
        {
            return _context.Departments;
        }

        #region Disposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }



        #endregion

    }
}