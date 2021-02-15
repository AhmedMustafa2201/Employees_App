using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Employee_App.Data.Domain;
using Employee_APP.Data.EntityConfigurations;

namespace Employee_APP.Data
{
    public class ApplicationDBContext : DbContext
    {

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Departments> Departments { get; set; }

        public ApplicationDBContext() : base("name=DefaultConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployerConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            //modelBuilder.Configurations.Add(new DepartmentConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
