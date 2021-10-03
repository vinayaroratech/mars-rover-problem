using System.Collections.Generic;
using Xunit;

namespace MarsRoverProblem.Tests
{
    public class MarsRoverProblemTest
    {
        [Fact]
        public void TestScanrio_12N_LMLMLMLMM()
        {
            Position position = new()
            {
                X = 1,
                Y = 2,
                Direction = DirectionsType.N
            };

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "LMLMLMLMM";

            position.StartMoving(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Direction}";
            var expectedOutput = "1 3 N";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void TestScanrio_33E_MRRMMRMRRM()
        {
            Position position = new()
            {
                X = 3,
                Y = 3,
                Direction = DirectionsType.E
            };

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "MRRMMRMRRM";

            position.StartMoving(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Direction}";
            var expectedOutput = "2 3 S";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void TestScanrio_33E_ThrowException()
        {
            Position position = new()
            {
                X = 3,
                Y = 3,
                Direction = DirectionsType.E
            };

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "MRRMMRMRRLMMMM";

            Assert.Throws<MarsRoverException>(() => position.StartMoving(maxPoints, moves));
        }
    }
}