using Dev.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Data.Mappings
{
    class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.CNPJ)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(c => c.Email)
                 .IsRequired()
                 .HasColumnType("varchar(100)");

            // 1 : N => Cliente : Projetos
            builder.HasMany(p => p.Prospects)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);

            builder.ToTable("Customers");
        }
    }
}
