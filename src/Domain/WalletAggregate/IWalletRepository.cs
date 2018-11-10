using System.Threading.Tasks;
using Domain.Seedwork;

namespace Domain.WalletAggregate
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        Wallet Add(Wallet wallet);

        void Update(Wallet wallet);

        Task<Wallet> GetAsync(int walletId);
    }
}
