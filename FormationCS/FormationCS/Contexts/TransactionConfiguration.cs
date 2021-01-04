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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transaction");
            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Date).HasColumnName("date").IsRequired();
            builder.Property(e => e.Amount).HasColumnName("amount").IsRequired();
            builder.HasOne(e => e.Account).WithMany(t => t.Transactions).HasForeignKey("accountId").IsRequired();
        }
    }
}
