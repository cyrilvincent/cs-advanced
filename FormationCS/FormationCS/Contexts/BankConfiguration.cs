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
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("bank");
            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasColumnName("name").IsRequired();
            builder.HasMany(e => e.Accounts).WithOne();
            builder.HasMany(e => e.Clients).WithMany(c => c.Banks).UsingEntity(j => j.ToTable("bank_client"));
           
        }
    }
}
