using FormationASPNET;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace FormationTest
{
    public class Tests
    {
        private FormationDbContext context;
        private ServiceProvider serviceProvider;


        [SetUp]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var services = new ServiceCollection();
            Injections.InjectDbContext(services, configuration.GetConnectionString("FormationDb")!);
            var builder = new DbContextOptionsBuilder<FormationDbContext>();
            serviceProvider = services.AddEntityFrameworkSqlServer().BuildServiceProvider();
            builder.UseSqlServer(configuration.GetConnectionString("FormationDb")).UseInternalServiceProvider(serviceProvider);
            this.context = new FormationDbContext(builder.Options);
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Dispose();
            this.serviceProvider.Dispose();
        }

        [Test]
        public void Test1()
        {
            var i = 0;
            i++;
            Assert.That(1, Is.EqualTo(i));
        }

        [Test]
        public void GetMagazines()
        {
            var magazines = context.Magazines.ToList();
            Assert.That(0, Is.EqualTo(magazines.Count));
        }
    }
}