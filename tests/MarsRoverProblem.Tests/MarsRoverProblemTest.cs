using System.Collections.Generic;
using Xunit;

namespace MarsRoverProblem.Tests
{
    public class MarsRoverProblemTest
    {
        [Fact]
        public void StartMoving_12N_LMLMLMLMM()
        {
            IPosition position = new Position();
            position.SetPosition(x: 1, y: 2, DirectionsType.N);

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "LMLMLMLMM";

            position.StartMoving(maxPoints, moves);

            var expectedOutput = "1 3 N";

            Assert.Equal(expectedOutput, position.ToString());
        }

        [Fact]
        public void StartMoving_33E_MRRMMRMRRM()
        {
            IPosition position = new Position();
            position.SetPosition(x: 3, y: 3, DirectionsType.E);

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "MRRMMRMRRM";

            position.StartMoving(maxPoints, moves);

            var expectedOutput = "2 3 S";
            var expectedHistory = 1;
            Assert.Equal(expectedHistory, position.GetHistory().Count);
            Assert.Equal(expectedOutput, position.ToString());
        }

        [Fact]
        public void GetHistory_33E_HistoryCount()
        {
            IPosition position = new Position();
            position.SetPosition(x: 3, y: 3, DirectionsType.E);

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "MRRMMRMRRM";

            position.StartMoving(maxPoints, moves);

            var expectedOutput = "2 3 S";
            var expectedHistory = 1;
            Assert.Equal(expectedHistory, position.GetHistory().Count);
            Assert.Equal(expectedOutput, position.ToString());

            position.SetPosition(x: 1, y: 2, DirectionsType.N);

            moves = "LMLMLMLMM";

            position.StartMoving(maxPoints, moves);

            expectedOutput = "1 3 N";

            expectedHistory = 2;
            Assert.Equal(expectedHistory, position.GetHistory().Count);
            Assert.Equal(expectedOutput, position.ToString());
        }

        [Fact]
        public void GetHistoryByMoves_33E_Sucess()
        {
            IPosition position = new Position();
            position.SetPosition(x: 3, y: 3, DirectionsType.E);

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "MRRMMRMRRM";

            position.StartMoving(maxPoints, moves);

            var expectedOutput = "2 3 S";
            Assert.Equal(expectedOutput, position.GetHistoryByMoves(moves));
            Assert.Equal(expectedOutput, position.ToString());

            position.SetPosition(x: 1, y: 2, DirectionsType.N);

            moves = "LMLMLMLMM";

            position.StartMoving(maxPoints, moves);

            expectedOutput = "1 3 N";

            Assert.Equal(expectedOutput, position.GetHistoryByMoves(moves));
            Assert.Equal(expectedOutput, position.ToString());
        }

        [Fact]
        public void StartMoving_33E_ThrowException()
        {
            IPosition position = new Position();
            position.SetPosition(x: 3, y: 3, DirectionsType.E);

            var maxPoints = new List<int>() { 5, 5 };
            var moves = "MRRMMRMRRLMMMM";

            Assert.Throws<MarsRoverException>(() => position.StartMoving(maxPoints, moves));
        }
    }
}