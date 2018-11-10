namespace Domain.WalletAggregate.Events
{
    public class WalletCreated : WalletEventBase
    {
        public WalletCreated(Wallet wallet) : base(wallet)
        {
        }
    }
}
