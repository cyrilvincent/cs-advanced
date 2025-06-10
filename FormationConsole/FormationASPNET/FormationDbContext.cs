using FormationASPNET.Configurations;
using FormationASPNET.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FormationASPNET
{
    public class FormationDbContext : DbContext
    {
        public FormationDbContext(DbContextOptions<FormationDbContext> options) : base(options)
        {
        }

        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Shelf> Shelves { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(MagazineConfiguration))!);
        }
    }
}
