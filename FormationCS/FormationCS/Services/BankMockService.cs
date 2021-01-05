using FormationCS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Services
{
    public class BankMockService : IBankService
    {
        private List<Bank> context = new List<Bank>
        {
            new Bank{
                Id = 1,
                Name="CyrilBank", 
                Customers=new List<Customer>
                {
                    new Customer {Id=1, FirstName="Cyril", LastName="Vincent"}
                }
            },
            new Bank{Id = 2, Name="TotoBank"},
        };

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
            Bank bank = new Bank { Name = name };
            context.Add(bank);
            return bank;
        }

        public Customer CreateCustomer(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public void Deposit(Account account, double amount)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountById(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Account> GetAccountsByAmountLargerThan(double amount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Account> GetAccountsByCustomerId(long id)
        {
            throw new NotImplementedException();
        }

        public Bank GetBankById(long id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public double Withdraw(Account account, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
