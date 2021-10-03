using System;
using System.Collections.Generic;

namespace MarsRoverProblem
{
    public class Position : IPosition
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public DirectionsType Direction { get; set; }

        public Position()
        {
            X = Y = 0;
            Direction = DirectionsType.N;
        }

        public void SetPosition(int x, int y, DirectionsType direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        private void Rotate90Left()
        {
            Direction = Direction switch
            {
                DirectionsType.N => DirectionsType.W,
                DirectionsType.S => DirectionsType.E,
                DirectionsType.E => DirectionsType.N,
                DirectionsType.W => DirectionsType.S,
                _ => throw new MarsRoverException($"Invalid Direction {Direction}"),
            };
        }

        private void Rotate90Right()
        {
            Direction = Direction switch
            {
                DirectionsType.N => DirectionsType.E,
                DirectionsType.S => DirectionsType.W,
                DirectionsType.E => DirectionsType.S,
                DirectionsType.W => DirectionsType.N,
                _ => throw new MarsRoverException($"Invalid Direction {Direction}"),
            };
        }

        private void MoveInSameDirection()
        {
            switch (Direction)
            {
                case DirectionsType.N:
                    Y += 1;
                    break;
                case DirectionsType.S:
                    Y -= 1;
                    break;
                case DirectionsType.E:
                    X += 1;
                    break;
                case DirectionsType.W:
                    X -= 1;
                    break;
                default:
                    throw new MarsRoverException($"Invalid Direction {Direction}");
            }
        }

        public void StartMoving(IList<int> maxPoints, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        MoveInSameDirection();
                        break;
                    case 'L':
                        Rotate90Left();
                        break;
                    case 'R':
                        Rotate90Right();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        throw new MarsRoverException($"Invalid Character {move}");
                }

                if (X < 0 || X > maxPoints[0] || Y < 0 || Y > maxPoints[1])
                    throw new MarsRoverException($"Oops! Position can not be beyond bounderies (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
            }
        }

        public override string ToString() => $"{X} {Y} {Direction}";
    }
}