using System;
using System.Linq;

namespace MarsRoverProblem
{
    public class RoverMovement
    {
        public int x;
        public int y;
        public string direction;
        public RoverMovement(string coordinate)
        {
            Int32.TryParse(coordinate.Split(' ')[0], out x);
            Int32.TryParse(coordinate.Split(' ')[1], out y);
            direction = coordinate.Split(' ')[2];
        }

        public void RotateLeft() // will return 90 degrees left
        {
            switch (this.direction)
            {
                case "N":
                    this.direction = "W";
                    break;
                case "S":
                    this.direction = "E";
                    break;
                case "E":
                    this.direction = "N";
                    break;
                case "W":
                    this.direction = "S";
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void RotateRight() // will return 90 degrees right
        {
            switch (this.direction)
            {
                case "N":
                    this.direction = "E";
                    break;
                case "S":
                    this.direction = "W";
                    break;
                case "E":
                    this.direction = "S";
                    break;
                case "W":
                    this.direction = "N";
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void MoveForward() // will move forward on the same direction
        {
            switch (this.direction)
            {
                case "N":
                    this.y += 1;
                    break;
                case "S":
                    this.y -= 1;
                    break;
                case "E":
                    this.x += 1;
                    break;
                case "W":
                    this.x -= 1;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void MoveToLocation(string maxPoints, string movementMessage) // will watch the instructions inside the message
        {
            char[] movements = movementMessage.ToCharArray();
            int[] limits = maxPoints.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            for (int m = 0; m < movements.Length; m++)
            {
                switch (movements[m])
                {
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                    case 'M':
                        MoveForward();
                        break;
                    default:
                        break;
                }

                if (this.x < 0 || this.x > limits[0] || this.y < 0 || this.y > limits[1])
                {
                    throw new Exception($"Position is out of limited bounderies (0 , 0) and ({limits[0]} , {limits[1]})");
                }
            }
        }
    }
}
