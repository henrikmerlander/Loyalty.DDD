namespace Domain.Wallet.Events
{
    public class WalletCreated : WalletEventBase
    {
        public WalletCreated(WalletAggregate wallet) : base(wallet)
        {
        }
    }
}
