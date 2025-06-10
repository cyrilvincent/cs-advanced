using FormationASPNET.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormationASPNET.Configurations
{
    public class MagazineConfiguration : IEntityTypeConfiguration<Magazine>
    {
        public void Configure(EntityTypeBuilder<Magazine> builder)
        {
            builder.ToTable("magazine");

            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(entity => entity.Height).HasColumnName("height").IsRequired();
            builder.Property(entity => entity.Stack).HasColumnName("stack");
        }
    }
}
