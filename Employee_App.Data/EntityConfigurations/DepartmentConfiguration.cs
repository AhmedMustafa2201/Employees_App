using System.Data.Entity.ModelConfiguration;
using Employee_App.Data.Domain;

namespace Employee_APP.Data.EntityConfigurations
{
    public class DepartmentConfiguration : EntityTypeConfiguration<Departments>
    {
        public DepartmentConfiguration()
        {
            
        }
    }
}