using EF.Library.Configurations;
using EF.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library
{
    public class MediaContext : DbContext
    {
        public MediaContext(DbContextOptions options) : base(options)
        {
        }

        public MediaContext() : base()
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        // nuget Microsoft.Extensions.Logging.Console 
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                // nuget EntityFrameworkCore.Proxies
                // nuget EntityFrameworkCore.SqlServer
                optionsBuilder.UseLoggerFactory(MyLoggerFactory).UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=media;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
