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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");
            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Accounts);
            builder.Property(e => e.FirstName).HasColumnName("firstname");
            builder.Property(e => e.LastName).HasColumnName("lastname").IsRequired();
        }
    }
}
