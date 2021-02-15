using System;
using System.Linq;
using Employee_App.Data.Domain;
using Employee_App.Repository.ViewModels;

namespace Employee_APP.Repository.Repositories
{
    public interface IClientRepository : IDisposable
    {
        IQueryable<Clients> GetAllClients();
        void AddClient(ClientVM client, int Employee_ID);
    }
}