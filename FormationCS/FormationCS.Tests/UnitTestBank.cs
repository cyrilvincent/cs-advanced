using NUnit.Framework;
using FormationCS.Entities;
using FormationCS.Services;

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


    }
}