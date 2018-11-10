using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Domain.WalletAggregate;
using MediatR;
using Moq;
using NUnit.Framework;

namespace Application.Tests
{
    internal class CreateWalletHandlerTest
    {
        private readonly Mock<IWalletRepository> _walletRepositoryMock;
        private readonly Mock<IMediator> _mediator;

        public CreateWalletHandlerTest()
        {
            _walletRepositoryMock = new Mock<IWalletRepository>();
            _mediator = new Mock<IMediator>();
        }

        [Test]
        public async Task Handle_returns_false_if_wallet_is_not_persisted()
        {
            var createWalletCommand = new CreateWallet(It.IsAny<string>());

            _walletRepositoryMock.Setup(walletRepo => walletRepo.UnitOfWork.SaveEntitiesAsync(default(CancellationToken)))
                .Returns(Task.FromResult(false));

            var handler = new CreateWalletHandler(_mediator.Object, _walletRepositoryMock.Object);
            var cancellationToken = new CancellationToken();
            var result = await handler.Handle(createWalletCommand, cancellationToken);

            Assert.False(result);
        }

        [Test]
        public async Task Handle_returns_true_if_wallet_is_persisted()
        {
            var createWalletCommand = new CreateWallet(It.IsAny<string>());

            _walletRepositoryMock.Setup(walletRepo => walletRepo.UnitOfWork.SaveEntitiesAsync(default(CancellationToken)))
                .Returns(Task.FromResult(true));

            var handler = new CreateWalletHandler(_mediator.Object, _walletRepositoryMock.Object);
            var cancellationToken = new CancellationToken();
            var result = await handler.Handle(createWalletCommand, cancellationToken);

            Assert.True(result);
        }
    }
}
