using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library
{
    // nuget EntityFrameworkCore.Design
    public class MediaContextFactory : IDesignTimeDbContextFactory<MediaContext>
    {
        public MediaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MediaContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=media;Integrated Security=True");

            return new MediaContext(optionsBuilder.Options);
        }

        // dotnet tool install --global dotnet-ef
        // dotnet ef migrations add InitialCreate
        // dotnet ef database update
        // Cyril Vincent
    }
}
