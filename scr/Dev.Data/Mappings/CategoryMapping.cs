using Dev.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Data.Mappings
{
    class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : N => Categoria : Projetos
            builder.HasMany(p => p.Prospects)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            builder.ToTable("Category");
        }
    }
}
