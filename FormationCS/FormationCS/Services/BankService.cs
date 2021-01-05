using FormationCS.Contexts;
using Microsoft.EntityFrameworkCore;
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

        public Account CreateAccount(Bank bank, Customer owner)
        {
            Account a = new Account { Bank = bank, Owner = owner, IsClose = false };
            bank.Accounts.Add(a);
            return a;
        }

        public Bank CreateBank(string name)
        {
            Bank b = new Bank { Name = name };
            Context.Banks.Add(b);
            return b;
        }

        public Customer CreateCustomer(string firstName, string lastName)
        {
            Customer c = new Customer { FirstName = firstName, LastName = lastName };
            Context.Customers.Add(c);
            return c;
        }

        public void Deposit(Account account, double amount)
        {
            if(account.IsClose)
            {
                throw new BankException($"Error account is closed");
            }
            else if(amount>0)
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
            return Context.Accounts.Include(e => e.Bank).Include(e => e.Owner).Where(a => a.Id == id).FirstOrDefault();
        }

        public Bank GetBankById(long id)
        {
            return Context.Banks.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public double Withdraw(Account account, double amount)
        {
            if (account.IsClose)
            {
                throw new BankException($"Error account is closed");
            }
            else if (amount > 0)
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

        public IQueryable<Account> GetAccountsByAmountLargerThan(double amount)
        {
            return Context.Accounts.Include(e => e.Bank).Include(e => e.Owner).Where(a => a.Transactions.Any(t => t.Amount > amount));
            //return Context.Transactions.Where(t => t.Amount > amount).Select(t => t.Account).Distinct();
        }

        public IQueryable<Account> GetAccountsByCustomerId(long id)
        {
            return Context.Accounts.Include(e => e.Bank).Include(e => e.Owner).Where(a => a.Owner.Id == id);
        }

        public Customer GetCustomerById(long id)
        {
            return Context.Customers.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool DeleteAccountById(long id)
        {
            Account account = GetAccountById(id);
            Context.Accounts.Remove(account);
            return true;
        }
    }
}
