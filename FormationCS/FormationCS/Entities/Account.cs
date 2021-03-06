﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Entities
{
    public class Account
    {
        public long Id { get; init; }

        public virtual Bank Bank { get; set; }
        public virtual Customer Owner { get; set; }

        public double Balance { get; set; }
        public virtual IList<Transaction> Transactions { get; set; } = new List<Transaction>();
        public bool IsClose { get; set; } = true;
        public DateTime? DateTime { get; set; }
    }
}
