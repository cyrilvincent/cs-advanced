using FormationCS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Services
{
    public interface IBankService
    {
        Account CreateAccount(Bank bank, Client owner);

        void Deposit(Account account, double amount); // Security
        double Withdraw(Account account, double amount); // amount <= balance throws Exception
        void Close(Account account); // IsOpen bool ??

        //Transaction CreateTransaction(Account account);
        // Transaction = Id, DateTime.Now(), Amount > 0 si crédit, <0 si débit
        // Créee automatiquement dans deposit et withdraw
        // Account -* Transaction : Account.Transactions : IEnumerable Transaction
        // Tests++
        // Correction à 13h40


    }
}
