using System;
using System.Threading.Tasks;
using Domain.Seedwork;
using Domain.WalletAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public WalletRepository(WalletContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Wallet Add(Wallet wallet)
        {
            return _context.Wallets.Add(wallet).Entity;
        }

        public async Task<Wallet> GetAsync(int walletId)
        {
            return await _context.Wallets.FindAsync(walletId);
        }

        public void Update(Wallet wallet)
        {
            _context.Entry(wallet).State = EntityState.Modified;
        }
    }
}
