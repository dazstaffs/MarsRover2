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
            Rover rover = new Rover(1,2,'N');
            string position = rover.GetPosition();
            Assert.AreEqual("The rover's current position is 1,2,N", position);
        }

        [TestMethod]
        [DataRow(1, 2, 'N', "The rover's current position is 1,2,W")]
        [DataRow(1, 2, 'W', "The rover's current position is 1,2,S")]
        [DataRow(1, 2, 'S', "The rover's current position is 1,2,E")]
        [DataRow(1, 2, 'E', "The rover's current position is 1,2,N")]
        public void RoverSpinLeft_Returns_NewPosition(int x, int y, char direction, string result)
        {
            Rover rover = new Rover(x, y, direction);
            rover.Spin('L');
            string position = rover.GetPosition();
            Assert.AreEqual(result, position);
        }

        [TestMethod]
        [DataRow(1, 2, 'N', "The rover's current position is 1,2,E")]
        [DataRow(1, 2, 'E', "The rover's current position is 1,2,S")]
        [DataRow(1, 2, 'S', "The rover's current position is 1,2,W")]
        [DataRow(1, 2, 'W', "The rover's current position is 1,2,N")]
        public void RoverSpinRight_Returns_NewPosition(int x, int y, char direction, string result)
        {
            Rover rover = new Rover(x, y, direction);
            rover.Spin('R');
            string position = rover.GetPosition();
            Assert.AreEqual(result, position);
        }

        [TestMethod]
        public void RoverMove_Returns_NewPosition()
        {
            Rover rover = new Rover(1, 2, 'N');
            rover.Move();
            string position = rover.GetPosition();
            Assert.AreEqual("The rover's current position is 1,3,N", position);
        }

        [TestMethod]
        [DataRow(1, 5, 'N', "The rover's current position is 1,5,N")]
        [DataRow(5, 5, 'E', "The rover's current position is 5,5,E")]
        [DataRow(0, 0, 'S', "The rover's current position is 0,0,S")]
        [DataRow(0, 2, 'W', "The rover's current position is 0,2,W")]
        [DataRow(0, 0, 'W', "The rover's current position is 0,0,W")]
        public void RoverMove_Returns_SamePosition(int x, int y, char direction, string result)
        {
            Rover rover = new Rover(x, y, direction);
            rover.Move();
            string position = rover.GetPosition();
            Assert.AreEqual(result, position);
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
