using Dev.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Data.Mappings
{
    class SegmentMapping : IEntityTypeConfiguration<Segment>
    {
        public void Configure(EntityTypeBuilder<Segment> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : N => Segmento : Clientes
            builder.HasMany(p => p.Customers)
                .WithOne(c => c.Segment)
                .HasForeignKey(c => c.SegmentId);

            builder.ToTable("Segments");
        }
    }
}
