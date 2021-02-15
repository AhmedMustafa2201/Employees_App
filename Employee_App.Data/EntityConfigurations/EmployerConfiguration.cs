using System.Data.Entity.ModelConfiguration;
using Employee_App.Data.Domain;

namespace Employee_APP.Data.EntityConfigurations
{
    public class EmployerConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployerConfiguration()
        {

            Property(c => c.Full_Name)
               .IsRequired()
               .HasMaxLength(20);

            Property(c => c.UpdatedAt)
                .IsOptional()
                .HasColumnType("datetime2");

            Property(c => c.CreatedAt)
                .IsOptional()
                .HasColumnType("datetime2");

            Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(25);

            Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(12);

            HasRequired(d => d.Department)
                .WithMany(e => e.Employee)
                .HasForeignKey(e => e.DepartmentId);
        }
    }
}