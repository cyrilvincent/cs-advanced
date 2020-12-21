using FormationCS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Contexts
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");
            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).HasColumnName("title").IsRequired();
            builder.Property(e => e.Price).HasColumnName("price").IsRequired();
            builder.Ignore(e => e.VATPrice);
        }
    }
}
