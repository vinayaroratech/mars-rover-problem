using System.Collections.Generic;

namespace MarsRoverProblem
{
    public interface IInMemoryPositionStore
    {
        IDictionary<string, string> GetHistory();

        string GetHistoryByMoves(string moves);

        void Add(int x, int y, DirectionsType directionsType, string moves, string position);
    }
}