using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.DTOs
{
    public class AccountForCreateDTO : IDTO
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long BankId { get; set; }
    }
}
