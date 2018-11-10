using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Domain.WalletAggregate;
using Moq;
using NUnit.Framework;

namespace Application.Tests
{
    internal class RedeemPointsHandlerTest
    {
        private readonly Mock<IWalletRepository> _walletRepositoryMock;

        public RedeemPointsHandlerTest()
        {
            _walletRepositoryMock = new Mock<IWalletRepository>();
        }

        [Test]
        public async Task Handle_returns_false_if_wallet_does_not_exist()
        {
            var redeemPointsCommand = new RedeemPoints(It.IsAny<int>(), It.IsAny<int>());

            _walletRepositoryMock.Setup(walletRepo => walletRepo.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(default(Wallet));

            var handler = new RedeemPointsHandler(_walletRepositoryMock.Object);
            var cancellationToken = new CancellationToken();
            var result = await handler.Handle(redeemPointsCommand, cancellationToken);

            Assert.False(result);
        }

        [Test]
        public async Task Handle_returns_true_if_wallet_is_persisted()
        {
            var redeemPointsCommand = new RedeemPoints(It.IsAny<int>(), It.IsAny<int>());

            _walletRepositoryMock.Setup(walletRepo => walletRepo.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(FakeWallet());

            _walletRepositoryMock.Setup(walletRepo => walletRepo.UnitOfWork.SaveEntitiesAsync(default(CancellationToken)))
                .Returns(Task.FromResult(true));

            var handler = new RedeemPointsHandler(_walletRepositoryMock.Object);
            var cancellationToken = new CancellationToken();
            var result = await handler.Handle(redeemPointsCommand, cancellationToken);

            Assert.True(result);
        }

        private Wallet FakeWallet()
        {
            return new Wallet("Test");
        }
    }
}
