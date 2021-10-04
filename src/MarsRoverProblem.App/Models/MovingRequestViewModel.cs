using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarsRoverProblem.Api.Models
{
    public class MovingRequestViewModel
    {
        [Required]
        public string Moves { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int MaxX { get; set; }
        [Required]
        public int Y { get; set; }
        [Required]
        public int MaxY { get; set; }
        [Required]
        public DirectionsType Direction { get; set; }
    }
}
