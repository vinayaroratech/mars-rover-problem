using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarsRoverProblem.App.Models
{
    public class MovingRequestModel
    {
        [Required]
        public IList<int> MaxPoints { get; set; }
        [Required]
        public string Moves { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
        [Required]
        public DirectionsType Direction { get; set; }
    }
}
