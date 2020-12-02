using Dev.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Data.Mappings
{
    class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : N => Funcionario : Projetos
            builder.HasMany(p => p.Prospects)
                .WithOne(c => c.Employee)
                .HasForeignKey(c => c.EmployeeId);

            builder.ToTable("Employee");
        }
    }
}
