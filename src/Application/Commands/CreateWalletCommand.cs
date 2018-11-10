using MediatR;

namespace Application.Commands
{
    public class CreateWalletCommand : IRequest<bool>
    {
        public string UserName { get; private set; }

        public CreateWalletCommand(string userName)
        {
            UserName = userName;
        }
    }
}
