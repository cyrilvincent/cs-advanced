using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Entities
{
    public class Transaction : IEntity
    {
        public long Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public double Amount { get; set; }



    }
}
