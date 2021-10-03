using System.Collections.Generic;

namespace MarsRoverProblem
{
    public class InMemoryPositionStore : IInMemoryPositionStore
    {
        private IDictionary<string, string> _history = new Dictionary<string, string>();

        public IDictionary<string, string> GetHistory()
        {
            return _history;
        }

        public string GetHistoryByMoves(string moves)
        {
            if (_history.ContainsKey(moves))
                return _history[moves];
            else
                return string.Empty;
        }

        public void Add(int x, int y, DirectionsType directionsType, string moves, string position)
        {
            var key = $"{x}_{y}_{directionsType}_{moves }";
            if (!_history.ContainsKey(key))
                _history.Add(key, position);
        }
    }
}