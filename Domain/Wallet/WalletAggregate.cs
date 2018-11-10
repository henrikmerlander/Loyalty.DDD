using Domain.Seedwork;
using Domain.Wallet.Events;
using Domain.Wallet.Exceptions;

namespace Domain.Wallet
{
    public class WalletAggregate : Entity, IAggregateRoot
    {
        public int Balance { get; private set; }

        public WalletAggregate()
        {
            AddWalletCreatedDomainEvent();
        }

        public void Accrue(int points)
        {
            Balance += points;

            AddPointsAccruedDomainEvent();
        }

        public void Redeem(int points)
        {
            if (points > Balance) throw new InsufficientFunds();

            Balance -= points;

            AddPointsRedeemedDomainEvent();
        }

        private void AddWalletCreatedDomainEvent()
        {
            var walletCreatedDomainEvent = new WalletCreated(this);

            AddDomainEvent(walletCreatedDomainEvent);
        }

        private void AddPointsAccruedDomainEvent()
        {
            var pointsAccruedDomainEvent = new PointsAccrued(this);

            AddDomainEvent(pointsAccruedDomainEvent);
        }

        private void AddPointsRedeemedDomainEvent()
        {
            var pointsRedeemedDomainEvent = new PointsRedeemed(this);

            AddDomainEvent(pointsRedeemedDomainEvent);
        }
    }
}
