using System.Collections.Generic;

namespace MarsRoverProblem
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
        DirectionsType Direction { get; set; }
        void StartMoving(IList<int> maxPoints, string moves);
    }
}