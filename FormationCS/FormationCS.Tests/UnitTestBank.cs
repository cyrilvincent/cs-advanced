using NUnit.Framework;
using FormationCS.Entities;
using FormationCS.Services;
using System.Collections.Generic;
using System.Linq;
using FormationCS.Contexts;
using Microsoft.EntityFrameworkCore;
using FormationCS.DTOs;
using FormationCS.Adapters;

namespace FormationCS.Tests
{
    public class BankTests
    {

        [Test]
        public void TestBank()
        {
            Bank bank = new Bank { Id = 1, Name = "Banque de France" };
            Customer owner = new Customer { Id = 1, FirstName = "Cyril", LastName = "Vincent" };
            Account account = new Account { Id = 1, Owner = owner, Bank = bank };
            Assert.IsNotNull(account);
        }

        /*[Test]
        public void TestCreateAccount()
        {
            IBankService service = new BankService();
            Bank bank = new Bank { Id = 1, Name = "Banque de France" };
            Customer owner = new Customer { Id = 1, FirstName = "Cyril", LastName = "Vincent" };
            Account account = service.CreateAccount(bank, owner);
            Assert.AreEqual(account.Bank, bank);
            Assert.AreEqual(account.Owner, owner);

        }

        [Test]
        public void TestDeposit()
        {
            IBankService service = new BankService();
            Bank bank = new Bank { Id = 1, Name = "Banque de France" };
            Customer owner = new Customer { Id = 1, FirstName = "Cyril", LastName = "Vincent" };
            Account account = service.CreateAccount(bank, owner);
            service.Deposit(account, 100);
        }

        [Test]
        public void TestWithdraw()
        {
            IBankService service = new BankService();
            Bank bank = new Bank { Id = 1, Name = "Banque de France" };
            Customer owner = new Customer { Id = 1, FirstName = "Cyril", LastName = "Vincent" };
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
            Customer owner = new Customer { Id = 1, FirstName = "Cyril", LastName = "Vincent" };
            List<Account> accounts = new List<Account>();
            Account account1 = service.CreateAccount(bank, owner);
            Account account2 = service.CreateAccount(bank, new Customer { FirstName = "Toto", LastName = "Titi" });
            Account account3 = service.CreateAccount(bank, new Customer { FirstName = "Tutu", LastName = "Tata" });
            accounts.Add(account1);
            accounts.Add(account2);
            accounts.Add(account3);
            service.Deposit(account1, 2000);
            IEnumerable<Account> results = accounts.Where(a => a.Balance > 1000).OrderBy(a => a.Balance);
            Assert.AreEqual(account1, results.FirstOrDefault());
            results = accounts.Where(a => a.Balance > 3000);
            Assert.IsNull(results.FirstOrDefault());
            accounts.Where(a => a.Owner.FirstName != null && a.Owner.FirstName == "Cyril");
        }*/

        [Test]
        public void TestEFSimple()
        {
            FormationContext context = new FormationContext();
            Bank bank = new Bank { Name = "CyrilBank" };
            context.Banks.Add(bank);
            context.SaveChanges();
            Bank bank2 = context.Banks.First();
            Assert.AreEqual(bank.Name, "CyrilBank");
        }

        [Test]
        public void CreateUpdateDeleteEF()
        {
            FormationContext context = new FormationContext();
            Bank bank = context.Banks.First();
            Customer customer = context.Customers.First();
            Account account = new Account { Bank = bank, Owner = customer };
            context.Accounts.Add(account);
            context.SaveChanges();
            account = context.Accounts.First();
            account.Balance += 100;
            context.SaveChanges();
            context.Accounts.Remove(account);
            context.SaveChanges();
        }

        public void LazyEf()
        {
            FormationContext context = new FormationContext();
            Bank bank = context.Banks.First();
            Customer customer = context.Customers.First();
            Account account = new Account { Bank = bank, Owner = customer };
            bank.Accounts.Add(account);
            context.SaveChanges();
        }

        public void LazyEf2()
        {
            FormationContext context = new FormationContext();
            Bank bank = context.Banks.First();
            // Pas de jointure
            foreach (Bank b in context.Banks)
            {
                // b.Id
            }
            // Lazy Loading
            Assert.AreEqual(0, bank.Accounts.First().Balance);
            // Include Eagger Loading
            var banks = context.Banks.Include(e => e.Accounts);
            // Lazy Join
            var res = context.Banks.Where(b => b.Accounts.Count == 0).Include(e => e.Accounts);
            foreach (Bank b in res)
            {
            }

            // Bank 1-* Account 1-* Transaction
            // Tester avec 2 Accounts et 2-3 Transactions
        }

        [Test]
        public void TransactionsEF()
        {
            FormationContext context = new FormationContext();
            Bank b = context.Banks.First();
            Account account = b.Accounts.First();
            account.Transactions.Add(new Transaction { Amount = 100 });
            account.Transactions.Add(new Transaction { Amount = -50 });
            account.Balance = 50;
            context.SaveChanges();
        }

        [Test]
        public void ManyToManyEF()
        {
            FormationContext context = new FormationContext();
            Bank b = context.Banks.First();
            Customer c1 = new Customer { FirstName = "Cyril", LastName = "Vincent" };
            b.Customers.Add(c1);
            Customer c2 = new Customer { FirstName = "Toto", LastName = "Titi" };
            b.Customers.Add(c2);
            Bank b2 = new Bank { Name = "NewBank" };
            context.Banks.Add(b2);
            context.SaveChanges();
            c2.Banks.Add(b2);
            context.SaveChanges();
        }

        [Test]
        public void ServiceWithEF()
        {
            FormationContext context = new FormationContext();
            IBankService service = new BankService(context);
            Account account = service.GetAccountById(12);
            Assert.IsNotNull(account);
            service.Deposit(account, 100);
            Transaction t = account.Transactions.Last();
            Assert.AreEqual(100, t.Amount);
            service.Save();
        }

        [Test]
        public void GetAccountsByAmountLargerThan()
        {
            FormationContext context = new FormationContext();
            IBankService service = new BankService(context);
            var accounts = service.GetAccountsByAmountLargerThan(1000);
            Assert.AreEqual(1, accounts.Count());
        }

        [Test]
        public void GetAccountsByCustomerId()
        {
            FormationContext context = new FormationContext();
            IBankService service = new BankService(context);
            var accounts = service.GetAccountsByCustomerId(1);
            Assert.AreEqual(1, accounts.Count());
        }

        [Test]
        public void TestDTO()
        {
            FormationContext context = new FormationContext();
            IBankService service = new BankService(context);
            var accounts = service.GetAccountsByCustomerId(1);
            accounts.Select(a => new AccountDTO
            {
                Id = a.Id,
                BankName = a.Bank.Name

            });

        }

        [Test]
        public void TestAccountDTO()
        {
            FormationContext context = new FormationContext();
            IBankService service = new BankService(context);
            Account account = service.GetAccountById(12);
            AccountDTO dto = account.ToDTO();
            var dtos = service.GetAccountsByCustomerId(1).ToDTOs();
        }

    }
}