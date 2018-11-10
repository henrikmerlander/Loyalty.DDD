namespace Domain.WalletAggregate.Events
{
    public class PointsAccrued : WalletEventBase
    {
        public PointsAccrued(Wallet wallet) : base(wallet)
        {
        }
    }
}
