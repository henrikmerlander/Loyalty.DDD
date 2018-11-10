using MediatR;

namespace Application.Commands
{
    public class RedeemPoints : IRequest<bool>
    {
        public int Id { get; private set; }

        public int Points { get; private set; }

        public RedeemPoints(int id, int points)
        {
            Id = id;
            Points = points;
        }
    }
}
