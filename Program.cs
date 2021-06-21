using System;
using System.Linq;

namespace MarsRoverProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxLength = Console.ReadLine();
            var startPositions = Console.ReadLine().ToUpper();
            //var startPositionsLength = startPositions.ToCharArray();

            var moves = Console.ReadLine().ToUpper();

            RoverMovement rover = new RoverMovement(startPositions);
            try
            {
                rover.MoveToLocation(maxLength, moves);
                Console.WriteLine($"{rover.x} {rover.y} {rover.direction.ToString()}");
                Console.ReadLine();
            }
            catch
            {
                throw new NotImplementedException();
            }

        }
    }
}
