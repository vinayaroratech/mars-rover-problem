using System.Collections.Generic;

namespace MarsRoverProblem
{
    public interface IPosition
    {
        int X { get; }
        int Y { get; }
        DirectionsType Direction { get; set; }
        void StartMoving(IList<int> maxPoints, string moves);
        void SetPosition(int x, int y, DirectionsType direction);
        IDictionary<string, string> GetHistory();
        string GetHistoryByMoves(string moves);
    }
}