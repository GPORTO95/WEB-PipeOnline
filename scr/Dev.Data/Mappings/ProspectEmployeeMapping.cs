using Dev.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Data.Mappings
{
    public class ProspectEmployeeMapping : IEntityTypeConfiguration<ProspectEmployee>
    {
        public void Configure(EntityTypeBuilder<ProspectEmployee> builder)
        {
            builder.HasKey(pe => new { pe.ProspectId, pe.EmployeeId });

            builder.HasOne(pe => pe.Prospect)
                .WithMany(pe => pe.ProspectEmployees)
                .HasForeignKey(pe => pe.ProspectId);

            builder.HasOne(pe => pe.Employee)
                .WithMany(pe => pe.ProspectEmployees)
                .HasForeignKey(pe => pe.EmployeeId);

            builder.ToTable("ProspectEmployees");
        }
    }
}
