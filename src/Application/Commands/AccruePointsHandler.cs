using System.Threading;
using System.Threading.Tasks;
using Domain.WalletAggregate;
using MediatR;

namespace Application.Commands
{
    public class AccruePointsHandler : IRequestHandler<AccruePoints, bool>
    {
        private readonly IWalletRepository _walletRepository;

        public AccruePointsHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<bool> Handle(AccruePoints request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetAsync(request.Id);

            if (wallet == null)
            {
                return false;
            }

            wallet.Accrue(request.Points);

            return await _walletRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
