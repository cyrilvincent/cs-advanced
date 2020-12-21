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
        public void Close(Account account)
        {
            account.IsClose = true;
        }

        public Account CreateAccount(Bank bank, Client owner)
        {
            return new Account { Bank = bank, Owner = owner };
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
