using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Entities
{
    public class Bank
    {
        public long Id { get; init; }
        public string Name { get; set; }

        public virtual List<Account> Accounts { get; private set; }
    }
}
