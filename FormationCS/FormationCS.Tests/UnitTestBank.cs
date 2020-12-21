using NUnit.Framework;
using FormationCS.Entities;
using FormationCS.Services;
using System.Collections.Generic;
using System.Linq;
using FormationCS.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FormationCS.Tests
{
    public class BankTests
    {

        [Test]
        public void TestBank()
        {
            Bank bank = new Bank { Id = 1, Name = "Banque de France" };
            Client owner = new Client { Id = 1, FirstName = "Cyril", LastName = "Vincent" };
            Account account = new Account { Id = 1, Owner = owner, Bank = bank };
            Assert.IsNotNull(account);
        }

        [Test]
        public void TestCreateAccount()
        {
            IBankService service = new BankService();
            Bank bank = new Bank { Id = 1, Name = "Banque de France" };
            Client owner = new Client { Id = 1, FirstName = "Cyril", LastName = "Vincent" };
            Account account = service.CreateAccount(bank, owner);
            Assert.AreEqual(account.Bank, bank);
            Assert.AreEqual(account.Owner, owner);

        }

        [Test]
        public void TestDeposit()
        {
            IBankService service = new BankService();
            Bank bank = new Bank { Id = 1, Name = "Banque de France" };
            Client owner = new Client { Id = 1, FirstName = "Cyril", LastName = "Vincent" };
            Account account = service.CreateAccount(bank, owner);
            service.Deposit(account, 100);
        }

        [Test]
        public void TestWithdraw()
        {
            IBankService service = new BankService();
            Bank bank = new Bank { Id = 1, Name = "Banque de France" };
            Client owner = new Client { Id = 1, FirstName = "Cyril", LastName = "Vincent" };
            Account account = service.CreateAccount(bank, owner);
            service.Deposit(account, 100);
            service.Withdraw(account, 70);
            Assert.AreEqual(30, account.Balance);
            Assert.Throws<BankException>(() => service.Withdraw(account, 70));
        }

        [Test]
        public void TestLinq()
        {
            IBankService service = new BankService();
            Bank bank = new Bank { Id = 1, Name = "Banque de France" };
            Client owner = new Client { Id = 1, FirstName = "Cyril", LastName = "Vincent" };
            List<Account> accounts = new List<Account>();
            Account account1 = service.CreateAccount(bank, owner);
            Account account2 = service.CreateAccount(bank, new Client { FirstName = "Toto", LastName = "Titi" });
            Account account3 = service.CreateAccount(bank, new Client { FirstName = "Tutu", LastName = "Tata" });
            accounts.Add(account1);
            accounts.Add(account2);
            accounts.Add(account3);
            service.Deposit(account1, 2000);
            IEnumerable<Account> results = accounts.Where(a => a.Balance > 1000).OrderBy(a => a.Balance);
            Assert.AreEqual(account1, results.FirstOrDefault());
            results = accounts.Where(a => a.Balance > 3000);
            Assert.IsNull(results.FirstOrDefault());
            accounts.Where(a => a.Owner.FirstName != null && a.Owner.FirstName == "Cyril");
        }



    }
}