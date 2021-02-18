using MarsRover2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Tests
{
    [TestClass]
    public class EastDirectionActionTests
    {
        private readonly IDirectionAction _directionAction;
        public EastDirectionActionTests()
        {
            int ycoordinate = 3;
            _directionAction = new EastDirectionAction(ycoordinate);
        }

        [TestMethod]
        [DataRow('L', 'N')]
        [DataRow('R', 'S')]
        public void RoverSpin_Returns_NewDirection(char direction, char result)
        {
            char newDirection = _directionAction.Spin(direction);
            Assert.AreEqual(newDirection, result);
        }

        [TestMethod]
        public void RoverMove_Returns_NewPosition()
        {
            int ycoodinate = _directionAction.Move();
            Assert.AreEqual(ycoodinate, 4);
        }

        [TestMethod]
        public void RoverInvalidMove_Returns_SamePosition()
        {
            int ycoordinate = 5;
            IDirectionAction directionAction = new EastDirectionAction(ycoordinate);
            int ycoodinate = directionAction.Move();
            Assert.AreEqual(ycoodinate, 5);
        }
    }
}
