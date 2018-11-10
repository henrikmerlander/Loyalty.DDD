using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.WalletAggregate;
using MediatR;

namespace Application.Commands
{
    public class RedeemPointsHandler : IRequestHandler<RedeemPoints, bool>
    {
        private readonly IWalletRepository _walletRepository;

        public RedeemPointsHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<bool> Handle(RedeemPoints request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetAsync(request.Id);

            if (wallet == null) return false;

            wallet.Redeem(request.Points);

            return await _walletRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
