using MediatR;

namespace Application.Commands
{
    public class RedeemPointsCommand : IRequest<bool>
    {
        public int Id { get; private set; }

        public int Points { get; private set; }

        public RedeemPointsCommand(int id, int points)
        {
            Id = id;
            Points = points;
        }
    }
}
