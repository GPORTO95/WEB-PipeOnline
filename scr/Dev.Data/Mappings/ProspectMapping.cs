using Dev.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Data.Mappings
{
    public class ProspectMapping : IEntityTypeConfiguration<Prospect>
    {
        public void Configure(EntityTypeBuilder<Prospect> builder)
        {
            //Cadastro
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.IdPsp)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.ProActive)
                .IsRequired()
                .HasColumnType("varchar(1)");

            builder.Property(p => p.Competition)
                .IsRequired()
                .HasColumnType("varchar(1)");

            builder.Property(p => p.NameCompetitors)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.International)
                .IsRequired()
                .HasColumnType("varchar(1)");

            builder.Property(p => p.ReasonText)
                .HasColumnType("varchar(30)");

            //Fase

            builder.Property(p => p.PhaseProspect)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired()
                .HasColumnType("varchar(3)");

            builder.Property(p => p.AutomaticPhase)
                .HasColumnType("varchar(2)");

            builder.Property(p => p.AutomaticStatus)
                .HasColumnType("varchar(2)");

            //Team

            builder.Property(p => p.Interlocutor)
                .HasColumnType("varchar(200)");
            
            builder.Property(p => p.Decision)
                .HasColumnType("varchar(200)");

            builder.ToTable("Prospects");
        }
    }
}
