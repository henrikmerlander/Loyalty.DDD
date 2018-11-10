using Domain.Seedwork;

namespace Domain.Wallet.Events
{
    public abstract class WalletEventBase : DomainEvent
    {
        public WalletAggregate Wallet { get; }

        public WalletEventBase(WalletAggregate wallet)
        {
            Wallet = wallet;
        }
    }
}
