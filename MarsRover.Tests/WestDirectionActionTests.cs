using MarsRover2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Tests
{
    [TestClass]
    public class WestDirectionActionTests
    {
        private readonly IDirectionAction _directionAction;
        public WestDirectionActionTests()
        {
            int xcoordinate = 3;
            _directionAction = new WestDirectionAction(xcoordinate);
        }

        [TestMethod]
        [DataRow('L', 'S')]
        [DataRow('R', 'N')]
        public void RoverSpin_Returns_NewDirection(char direction, char result)
        {
            char newDirection = _directionAction.Spin(direction);
            Assert.AreEqual(newDirection, result);
        }

        [TestMethod]
        public void RoverMove_Returns_NewPosition()
        {
            int ycoodinate = _directionAction.Move();
            Assert.AreEqual(ycoodinate, 2);
        }

        [TestMethod]
        public void RoverInvalidMove_Returns_SamePosition()
        {
            int ycoordinate = 0;
            IDirectionAction directionAction = new WestDirectionAction(ycoordinate);
            int ycoodinate = directionAction.Move();
            Assert.AreEqual(ycoodinate, 0);
        }
    }
}
