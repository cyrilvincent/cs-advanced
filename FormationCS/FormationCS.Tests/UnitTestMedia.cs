using FormationCS.Entities;
using FormationCS.Services;
using NUnit.Framework;
using FormationCS.Extensions;
using System.Collections.Generic;
using System.Linq;
using System;
using FormationCS.Contexts;

namespace FormationCS.Tests
{
    public class MediaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(2, 1 + 1);
        }

        [Test]
        public void TestBook()
        {
            Book book = new Book { Id = 1, Price = 10.0, Title = "C#" };
            Assert.IsNotNull(book);
        }

        [Test]
        public void TestBookVATPrice()
        {
            Book book = new Book { Id = 1, Price = 10.0, Title = "C#" };
            Assert.AreEqual(10.55, book.VATPrice,0.001);
        }

        [Test]
        public void TestMediaService()
        {
            IMediaService service = new MediaService();
            /*Book b = service.GetById(1);
            Assert.AreEqual(1, b.Id);*/
        }

        [Test]
        public void TestCAMLCase()
        {
            string s = "cyril";
            Assert.AreEqual("Cyril",s.ToCAMLCase());
        }

        [Test]
        public void TestFirstLINQ()
        {
            IEnumerable<int> ie = new List<int>() { 1, 2, 3, 4 };
            Func<int, bool> lambda = x => x % 2 == 0;
            IEnumerable<int> res = ie.Where(lambda);
            List<int> res2 = ie.Where(lambda).ToList();
            Assert.AreEqual(2, res2[0]);
        }

        [Test]
        public void TestEFSimple()
        {
            FormationContext context = new FormationContext();
            context.Books.Add(new Book { Title = "C#", Price = 10 });
            context.Books.Add(new Book { Title = "EF", Price = 12 });
            context.SaveChanges();
            var res = context.Books.Where(b => b.Price < 11).First();
            Assert.AreEqual("C#", res.Title);
        }


    }
}