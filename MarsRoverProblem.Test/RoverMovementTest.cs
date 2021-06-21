using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRoverProblem.Test
{
    [TestClass]
    public class RoverMovementTest
    {
        [TestMethod]
        public void Left()
        {
            RoverMovement rover = new RoverMovement("1 2 N");
            rover.RotateLeft();
            Assert.IsTrue(rover.direction == "W");
        }
        [TestMethod]
        public void Right()
        {
            RoverMovement rover = new RoverMovement("1 2 N");
            rover.RotateRight(); 

            Assert.IsTrue(rover.direction == "E");
        }
        [TestMethod]
        public void Forward()
        {
            RoverMovement rover = new RoverMovement("1 2 N");
            rover.MoveForward();
            Assert.IsTrue(rover.y == 3);
        }
        [TestMethod]
        public void Left2()
        {
            RoverMovement rover = new RoverMovement("3 3 E");
            rover.RotateLeft();
            Assert.IsTrue(rover.direction == "N");
        }
        [TestMethod]
        public void Right2()
        {
            RoverMovement rover = new RoverMovement("3 3 E");
            rover.RotateRight();
            Assert.IsTrue(rover.direction == "S");
        }
        [TestMethod]
        public void Forward2()
        {
            RoverMovement rover = new RoverMovement("3 3 E");
            rover.MoveForward();
            Assert.IsTrue(rover.x == 4);
        }

        [TestMethod]
        public void WatchMessage()
        {
            RoverMovement rover = new RoverMovement("1 2 N");
            string limit = "5 5";
            rover.MoveToLocation(limit, "LMLMLMLMM");
            Assert.AreEqual("1 3 N",rover.x + " " + rover.y + " " + rover.direction );
        }

        [TestMethod]
        public void WatchMessage2()
        {
            RoverMovement rover = new RoverMovement("3 3 E");
            string limit = "5 5";
            rover.MoveToLocation(limit, "MMRMMRMRRM");
            Assert.AreEqual("5 1 E", rover.x + " " + rover.y + " " + rover.direction);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "Position is out of limited bounderies (0 , 0) and (5 , 5)")]
        public void WatchMessageOutOfLimit()
        {
            RoverMovement rover = new RoverMovement("3 3 E");
            string limit = "5 5"; // must be the same as the limited boundaries in the exception message
            rover.MoveToLocation(limit, "MMRMMRMRRMM");
        }
    }
}

