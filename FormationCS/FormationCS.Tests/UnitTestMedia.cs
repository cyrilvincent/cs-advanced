using FormationCS.Entities;
using FormationCS.Services;
using NUnit.Framework;

namespace FormationCS.Tests
{
    public class Tests
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
            Book b = service.GetById(1);
            Assert.AreEqual(1, b.Id);
        }
    }
}