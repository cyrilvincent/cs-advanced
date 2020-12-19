using EF.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.Services
{
    public class MainService : IMainService
    {
        private readonly MediaContext _context;

        public MainService(MediaContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }
    }
}
