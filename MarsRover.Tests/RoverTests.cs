using MarsRover2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MarsRover.Tests
{
    [TestClass]
    public class RoverTests
    {

        [TestMethod]
        public void Rover_Returns_Position()
        {
            Rover rover = new Rover(1, 2, 'N');
            string position = rover.GetPosition();
            Assert.AreEqual("The rover's current position is 1,2,N", position);
        }

        [TestMethod]
        [DataRow("LMLMLMLMM", 1, 2, 'N', "The rover's current position is 1,3,N")]
        [DataRow("MMRMMRMRRM", 3, 3, 'E', "The rover's current position is 5,1,E")]
        public void SendInstructions_Returns_NewPosition(string instructions, int x, int y, char direction, string result)
        {
            Rover rover = new Rover(x, y, direction);
            rover.ProcessInstruction(instructions);
            string position = rover.GetPosition();
            Assert.AreEqual(result, position);
        }
    }
}
