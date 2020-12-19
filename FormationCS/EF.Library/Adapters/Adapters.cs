using EF.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.Adapters
{
    public static class Adapters
    {
        public static BookDTO ToDTO(this Book book)
        {
            return new BookDTO { Id = book.Id, Title = book.Title, Price = book.Price };
        }

        public static IEnumerable<BookDTO> ToDTO(this IEnumerable<Book> books)
        {
            return books.Select(b => b.ToDTO());
        }
    }
}
