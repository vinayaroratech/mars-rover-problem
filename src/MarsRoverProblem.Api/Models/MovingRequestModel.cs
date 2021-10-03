using System.Collections.Generic;

namespace MarsRoverProblem.Api.Models
{
    public class MovingRequestModel
    {
        public IList<int> MaxPoints { get; set; }
        public string Moves { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionsType Direction { get; set; }
    }
}
