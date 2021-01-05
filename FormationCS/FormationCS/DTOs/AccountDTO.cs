using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.DTOs
{
    public class AccountDTO : IDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } // FirstName + " " + LastName
        public string BankName { get; set; }
        public double Solde { get; set; }
    }
}
