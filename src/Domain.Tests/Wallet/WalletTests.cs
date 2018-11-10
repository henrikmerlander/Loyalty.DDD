
using Domain.Wallet;
using Domain.Wallet.Exceptions;
using FakeItEasy;
using NUnit.Framework;

namespace Domain.Tests.Wallet
{
    public class WalletTests
    {
        [Test]
        public void Create_wallet_raises_new_event()
        {
            var expectedResult = 1;

            var wallet = new WalletAggregate();

            Assert.AreEqual(expectedResult, wallet.DomainEvents.Count);
        }

        [Test]
        public void Accrue_points_raises_new_event()
        {
            var expectedResult = 2;

            var wallet = new WalletAggregate();
            wallet.Accrue(A.Dummy<int>());

            Assert.AreEqual(expectedResult, wallet.DomainEvents.Count);
        }

        [Test]
        public void Accrue_points_increases_balance()
        {
            var expectedResult = 100;

            var wallet = new WalletAggregate();
            wallet.Accrue(100);

            Assert.AreEqual(expectedResult, wallet.Balance);
        }

        [Test]
        public void Redeem_points_decreases_balance()
        {
            var expectedResult = 80;

            var wallet = new WalletAggregate();
            wallet.Accrue(100);
            wallet.Redeem(20);

            Assert.AreEqual(expectedResult, wallet.Balance);
        }

        [Test]
        public void Redeem_points_raises_new_event()
        {
            var expectedResult = 3;

            var wallet = new WalletAggregate();
            wallet.Accrue(A.Dummy<int>());
            wallet.Redeem(A.Dummy<int>());

            Assert.AreEqual(expectedResult, wallet.DomainEvents.Count);
        }

        [Test]
        public void Redeem_points_exceeding_balance_throws_insufficient_funds()
        {
            var wallet = new WalletAggregate();
            wallet.Accrue(100);

            Assert.Throws<InsufficientFunds>(() => wallet.Redeem(101));
        }
    }
}
