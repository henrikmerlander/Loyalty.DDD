using MediatR;

namespace Application.Commands
{
    public class AccruePointsCommand : IRequest<bool>
    {
        public int Id { get; private set; }

        public int Points { get; private set; }

        public AccruePointsCommand(int id, int points)
        {
            Id = id;
            Points = points;
        }
    }
}
