using FormationCS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Services
{
    public interface IMediaService
    {
        List<Book> Search(string term);
        Book GetById(long id);

        Cart AddToCart(Book book);

        bool ValidateCart(Cart cart);
        bool Buy(Cart cart);
    }
}
