using FormationASPNET.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormationASPNET.Configurations
{
    public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            builder.ToTable("shelf");

            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(entity => entity.Height).HasColumnName("height").IsRequired();
            builder.Property(entity => entity.Diameter).HasColumnName("diameter").IsRequired();

            builder.Property(entity => entity.MagazineId).HasColumnName("magazine_id").IsRequired();

            builder.HasOne(entity => entity.Magazine)
                .WithMany(entity => entity.Shelves)
                .HasForeignKey(entity => entity.MagazineId);
        }
    }
}
