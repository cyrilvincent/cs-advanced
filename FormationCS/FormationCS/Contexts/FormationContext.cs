using FormationCS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Contexts
{
    public class FormationContext : DbContext
    {
        public FormationContext() : base() {
        }
        public FormationContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLoggerFactory(MyLoggerFactory).UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=media;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
