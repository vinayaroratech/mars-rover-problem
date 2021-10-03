using System.ComponentModel;

namespace MarsRoverProblem
{
    public enum DirectionsType
    {
        [Description("North")]
        N = 1,
        [Description("South")]
        S = 2,
        [Description("East")]
        E = 3,
        [Description("West")]
        W = 4
    }

    public enum MovesType
    {
        [Description("Move")]
        M = 1,
        [Description("Left")]
        L = 2,
        [Description("Right")]
        R = 3,
    }
}