using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Employee_App.Data.Domain;
using Employee_APP.Repository.Repositories;
using Employee_App.Repository.ViewModels;

namespace Employee_APP.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDBContext _context;
        public ClientRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IQueryable<Clients> GetAllClients()
        {
            return _context.Clients;
        }
        
        public void AddClient(ClientVM client, int Employee_ID)
        {
            _context.Database.ExecuteSqlCommand("[dbo].[ClientC] @Full_Name, @Email, @Phone, @employee_id",
                new SqlParameter("@Full_Name", client.Name),
                new SqlParameter("@Email", client.Email),
                new SqlParameter("@Phone", client.Phone),
                new SqlParameter("@employee_id", Employee_ID)
            );
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