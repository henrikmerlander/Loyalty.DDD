namespace Domain.WalletAggregate.Events
{
    public class PointsRedeemed : WalletEventBase
    {
        public PointsRedeemed(Wallet wallet) : base(wallet)
        {
        }
    }
}
