using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Entities
{
    public class Account
    {
        public int Id { get; init; }

        public Bank Bank { get; set; }
        public Client Owner { get; set; }

        public double Balance { get; set; }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public double Withdraw(double amount)
        {
            Balance -= amount;
            return amount;
        }
    }
}
