using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Employee_App.Data.Domain;
using Employee_App.Repository.ViewModels;

namespace Employee_APP.Repository.Repositories
{
    public interface IDepartmentRepository : IDisposable
    {
        DbRawSqlQuery<JoinVM> GetAllDepartments();
        DbRawSqlQuery<Count_Result> GetDepartmentClientCount();
        DbRawSqlQuery<DepartmentVM> GetDetailedDepartment(int id);
        IQueryable<Departments> GetSelectListDepartmants();
    }
}