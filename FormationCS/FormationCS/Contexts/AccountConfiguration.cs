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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");
            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Bank).WithMany(b => b.Accounts).HasForeignKey("bankid").IsRequired();
            builder.HasOne(e => e.Owner).WithMany(c => c.Accounts).HasForeignKey("customerid").IsRequired();
            builder.Property(e => e.Balance).HasColumnName("balance").IsRequired();
            builder.Property(e => e.IsClose).HasColumnName("isclose").IsRequired();
            builder.HasMany(e => e.Transactions).WithOne();
            builder.Property(e => e.DateTime).HasColumnName("datetime");
        }
    }
}
