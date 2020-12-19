using EF.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.Services
{
    public class MainServiceMock : IMainService
    {

        public IEnumerable<Book> GetAll()
        {
            return new List<Book>()
            {
                new Book{Id=1, Title="C#", Price=99.0}
            };
         }
    }
}
