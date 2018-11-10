using MediatR;

namespace Application.Commands
{
    public class CreateWallet : IRequest<bool>
    {
        public string UserName { get; private set; }

        public CreateWallet(string userName)
        {
            UserName = userName;
        }
    }
}
