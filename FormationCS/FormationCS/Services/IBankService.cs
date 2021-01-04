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
        Bank CreateBank(string name);
        Bank GetBankById(long id);
        Account GetAccountById(long id);
        Account CreateAccount(Bank bank, Client owner);
        Client CreateClient(string firstName, string lastName);

        void Deposit(Account account, double amount); // Security
        double Withdraw(Account account, double amount); // amount <= balance throws Exception
        void Close(Account account); // IsOpen bool ??
        void Save();

        // Implémenter cette interface au complet
        // Tester
        // Gérer le IsClose
        // Gérer Account *-1 Client
        // GetAccountsByClientLastName(lastName) => IEnumerable<Account>
        // GetAccountsByAmountLargerThan(amount) => IEnumerable<Account>
    }
}
