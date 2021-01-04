using FormationCS.Contexts;
using FormationCS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Services
{
    public class BankService : IBankService
    {
        public FormationContext Context { get; private set; }
        public BankService(FormationContext context)
        {
            Context = context;
        }

        public void Close(Account account)
        {
            account.IsClose = true;
        }

        public Account CreateAccount(Bank bank, Client owner)
        {
            Account a = new Account { Bank = bank, Owner = owner };
            bank.Accounts.Add(a);
            return a;
        }

        public Bank CreateBank(string name)
        {
            Bank b = new Bank { Name = name };
            Context.Banks.Add(b);
            return b;
        }

        public Client CreateClient(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public void Deposit(Account account, double amount)
        {
            if(amount>0)
            {
                Transaction transaction = new Transaction { Amount = amount };
                account.Transactions.Add(transaction);
                account.Balance += amount;
            }
            else
            {
                throw new BankException($"Error in deposit amount < 0: {amount}");
            }
        }

        public Account GetAccountById(long id)
        {
            return Context.Accounts.Where(a => a.Id == id).FirstOrDefault();
        }

        public Bank GetBankById(long id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public double Withdraw(Account account, double amount)
        {
            if (amount > 0)
            {
                if (amount <= account.Balance)
                {
                    Transaction transaction = new Transaction { Amount = -amount };
                    account.Transactions.Add(transaction);
                    account.Balance -= amount;
                    return amount;
                }
                else
                {
                    throw new BankException($"Error in withdraw amount > Balance: {amount}");
                }
            }
            else
            {
                throw new BankException($"Error in withdraw amount < 0: {amount}");
            }
        }
    }
}
