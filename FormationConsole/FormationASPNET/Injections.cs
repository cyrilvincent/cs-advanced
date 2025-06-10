using Microsoft.EntityFrameworkCore;

namespace FormationASPNET
{
    public static class Injections
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FormationDbContext>(options =>
            {
                options.UseSqlServer(connectionString)
                       .LogTo(Console.WriteLine);
            });
        }
    }
}
