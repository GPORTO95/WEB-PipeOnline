using Dev.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Data.Mappings
{
    class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdCompany)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(c => c.IdBranch)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(c => c.NameCompany)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.NameBranch)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(p => p.Prospects)
                .WithOne(c => c.Company)
                .HasForeignKey(p => p.CompanyId);

            builder.ToTable("Companies");
        }
    }
}
