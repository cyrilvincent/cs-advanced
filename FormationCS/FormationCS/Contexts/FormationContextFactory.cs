using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Contexts
{
    public class FormationContextFactory : IDesignTimeDbContextFactory<FormationContext>
    {
        public FormationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FormationContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=media;Integrated Security=True");
            return new FormationContext(optionsBuilder.Options);
        }

        // dotnet tool install --global dotnet-ef
        // dotnet ef migrations add InitialCreate
        // dotnet ef database update
        // Cyril Vincent
    }
}
