using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Entities
{
    public class Customer
    {
        public long Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Bank> Banks { get; private set; }
        public virtual List<Account> Accounts { get; private set; }
    }
}
