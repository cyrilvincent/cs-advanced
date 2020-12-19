using EF.Library;
using EF.Library.Adapters;
using EF.Library.Entities;
using EF.Library.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Unit.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEF()
        {
            MediaContext context = new MediaContext();
            Book b = new Book { Title = "C#", Price = 10.0 };
            //context.Books.Add(b);
            //context.SaveChanges();
            var books = context.Books.ToList();
            Assert.IsNotNull(books);
        }

        [TestMethod]
        public void TestService()
        {
            MediaContext context = new MediaContext();
            MainService service = new MainService(context);
            var books = service.GetAll().ToList();
            Assert.IsTrue(books.Count > 0);
        }

        [TestMethod]
        public void TestDTO()
        {
            MediaContext context = new MediaContext();
            MainService service = new MainService(context);
            var dtos = service.GetAll().ToDTO().ToList();
            Assert.IsTrue(dtos.Count > 0);
        }
    }
}
