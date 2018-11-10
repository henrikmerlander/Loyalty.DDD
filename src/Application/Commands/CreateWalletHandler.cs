using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.WalletAggregate;
using MediatR;

namespace Application.Commands
{
    public class CreateWalletHandler : IRequestHandler<CreateWallet, bool>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMediator _mediator;

        public CreateWalletHandler(IMediator mediator, IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateWallet request, CancellationToken cancellationToken)
        {
            var wallet = new Wallet(request.UserName);

            _walletRepository.Add(wallet);

            return await _walletRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
