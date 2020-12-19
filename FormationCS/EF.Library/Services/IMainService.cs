using EF.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.Services
{
    public interface IMainService
    {
        IEnumerable<Book> GetAll();
    }
}
