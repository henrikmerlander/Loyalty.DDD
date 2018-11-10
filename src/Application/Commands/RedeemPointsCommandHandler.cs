using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.WalletAggregate;
using MediatR;

namespace Application.Commands
{
    public class RedeemPointsCommandHandler : IRequestHandler<RedeemPointsCommand, bool>
    {
        private readonly IWalletRepository _walletRepository;

        public RedeemPointsCommandHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<bool> Handle(RedeemPointsCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetAsync(request.Id);

            if (wallet == null) return false;

            wallet.Redeem(request.Points);

            return await _walletRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
