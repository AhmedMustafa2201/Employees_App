using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Employee_App.Data.Domain;

namespace Employee_APP.Data.EntityConfigurations
{
    public class ClientConfiguration : EntityTypeConfiguration<Clients>
    {
        public ClientConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(25);

            Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(12);

            Property(c => c.UpdatedAt)
                .IsOptional()
                .HasColumnType("datetime2");

            Property(c => c.CreatedAt)
                .IsOptional()
                .HasColumnType("datetime2");

            HasRequired(e => e.Employee)
                .WithMany(c => c.Client)
                .HasForeignKey(e => e.EmployeeID);
        }
    }
}