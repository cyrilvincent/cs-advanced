using FormationASPNET;
using FormationASPNET.Entities;
using FormationASPNET.Services;
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
            Injections.InjectServices(services);
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
        public void GetMagazineById()
        {
            var magazine = context.Magazines.Where(m => m.Id == 1).FirstOrDefault();
            Assert.That(3, Is.EqualTo(magazine?.Height));
        }


        [Test]
        public void AddMagazine()
        {
            var magazine = new Magazine { Height = 3 };
            context.Magazines.Add(magazine);
            context.SaveChanges();
        }


        [Test]
        public void AddShelfToMagazine()
        {
            var magazine = context.Magazines.Where(m => m.Id == 1).First();
            var shelf = new Shelf { Diameter = 2, Height = 3 };
            /*shelf.Magazine = magazine;
            context.Shelves.Add(shelf);*/
            magazine.Shelves.Add(shelf);
            context.SaveChanges();
        }

        [Test]
        public void ShelfJoin()
        {
            var magazine = context.Magazines.Include(m => m.Shelves).Where(m => m.Shelves.Any(s => s.Diameter == 2)).First();
            
        }

        [Test]
        public void TestIoC()
        {
            var services = new ServiceCollection();
            services.AddScoped<IEntity, Magazine>();
            var serviceProvider = services.BuildServiceProvider();

            var entity = serviceProvider.GetService<IEntity>();
            Assert.That(entity, Is.Not.Null);
            var magazine = (Magazine) entity;


        }

        [Test]
        public void TestDI()
        {
            var services = new ServiceCollection();
            services.AddScoped<IEntity, Magazine>();
            services.AddSingleton<ITourService, TourService>();
            services.AddDbContext<FormationDbContext>();
            var serviceProvider = services.BuildServiceProvider();

            var entity = serviceProvider.GetService<ITourService>();
            Assert.That(entity, Is.Not.Null);
            var tourService = (TourService)entity;


        }

        [Test]
        public void TestDIInject()
        {
            var entity = serviceProvider.GetService<ITourService>();
            Assert.That(entity, Is.Not.Null);
            var tourService = (TourService)entity;


        }
    }
}