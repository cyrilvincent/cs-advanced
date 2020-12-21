using NUnit.Framework;
using FormationCS.Entities;

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
            Assert.AreEqual(0, account.Balance);
            account.Deposit(100);
            Assert.AreEqual(100, account.Balance);
            account.Withdraw(30);
            Assert.AreEqual(70, account.Balance);
        }

       
    }
}