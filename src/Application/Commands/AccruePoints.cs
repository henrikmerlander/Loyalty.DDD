using MediatR;

namespace Application.Commands
{
    public class AccruePoints : IRequest<bool>
    {
        public int Id { get; private set; }

        public int Points { get; private set; }

        public AccruePoints(int id, int points)
        {
            Id = id;
            Points = points;
        }
    }
}
