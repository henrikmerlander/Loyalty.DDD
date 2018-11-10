namespace Domain.Wallet.Events
{
    public class PointsAccrued : WalletEventBase
    {
        public PointsAccrued(WalletAggregate wallet) : base(wallet)
        {
        }
    }
}
