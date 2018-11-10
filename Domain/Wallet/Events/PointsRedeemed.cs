namespace Domain.Wallet.Events
{
    public class PointsRedeemed : WalletEventBase
    {
        public PointsRedeemed(WalletAggregate wallet) : base(wallet)
        {
        }
    }
}
