using Domain.Seedwork;

namespace Domain.WalletAggregate.Events
{
    public abstract class WalletEventBase : DomainEvent
    {
        public Wallet Wallet { get; }

        public WalletEventBase(Wallet wallet)
        {
            Wallet = wallet;
        }
    }
}
