using FormationCS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Services
{
    public class MediaService : IMediaService
    {
        private IEnumerable<Book> books = new List<Book>()
        {
            new Book {Id=1, Price=10, Title="C#" }
        };

        public Cart AddToCart(Book book)
        {
            throw new NotImplementedException();
        }

        public bool Buy(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Book GetById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Book> Search(string term)
        {
            throw new NotImplementedException();
        }

        public bool ValidateCart(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
