using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Entities
{
    public class Account
    {
        public long Id { get; init; }

        public Bank Bank { get; set; }
        public Client Owner { get; set; }

        public double Balance { get; set; }
        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();
        public bool IsClose { get; set; } = true;
    }
}
