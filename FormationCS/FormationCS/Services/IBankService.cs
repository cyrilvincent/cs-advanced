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
        Account CreateAccount(Bank bank, Customer owner);
        Customer CreateCustomer(string firstName, string lastName);

        void Deposit(Account account, double amount); // Security
        double Withdraw(Account account, double amount); // amount <= balance throws Exception
        void Close(Account account);
        void Save();
        IQueryable<Account> GetAccountsByAmountLargerThan(double amount);
        IQueryable<Account> GetAccountsByCustomerId(long id);

    }
}
