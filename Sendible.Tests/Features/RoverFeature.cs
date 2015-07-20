using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sendible.Models;

namespace Sendible.Tests.Features
{
    [TestClass]
    public class RoverFeature
    {
        private Rover GivenARover(int x, int y, CardinalCompass cardinal)
        {
            return new Rover(x, y, cardinal);
        }

        private void WhenACommandIsExecuted(Rover rover, string command)
        {
            rover.SetCommands(command, PlateauFeature.GivenAPlateau(5, 5));
        }

        private void ThenIExpectARoverOnThePosition(Rover rover, int x, int y, CardinalCompass cardinal)
        {
            Assert.AreEqual(rover.PointX, x);
            Assert.AreEqual(rover.PointY, y);
            Assert.AreEqual(rover.CardinalCompass, cardinal);
        }

        private void ThenIExpectARover(Rover rover, int expectedX, int expectedY, CardinalCompass expectedCardinalCompass)
        {
            Assert.IsNotNull(rover);
            Assert.AreEqual(rover.PointX, expectedX);
            Assert.AreEqual(rover.PointY, expectedY);
            Assert.AreEqual(rover.CardinalCompass, expectedCardinalCompass);
        }

        [TestMethod]
        public void GivenAValidRover_ThenIExpectARover()
        {
            Rover rover = GivenARover(1, 2, CardinalCompass.North);
            ThenIExpectARover(rover, 1, 2, CardinalCompass.North);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenAnInvalidRover_ThenIExpectAnError()
        {
            GivenARover(-2, -1, CardinalCompass.North);
        }

        [TestMethod]
        public void GivenAValidCommandToTurnRight_WhenTheCommandIsExecuted_ThenRoverShouldTurnRight()
        {
            Rover rover = GivenARover(1, 1, CardinalCompass.North);
            WhenACommandIsExecuted(rover, "R");
            ThenIExpectARoverOnThePosition(rover, 1, 1, CardinalCompass.East);

            rover = GivenARover(1, 1, CardinalCompass.East);
            WhenACommandIsExecuted(rover, "R");
            ThenIExpectARoverOnThePosition(rover, 1, 1, CardinalCompass.South);

            rover = GivenARover(1, 1, CardinalCompass.South);
            WhenACommandIsExecuted(rover, "R");
            ThenIExpectARoverOnThePosition(rover, 1, 1, CardinalCompass.West);

            rover = GivenARover(1, 1, CardinalCompass.West);
            WhenACommandIsExecuted(rover, "R");
            ThenIExpectARoverOnThePosition(rover, 1, 1, CardinalCompass.North);
        }

        [TestMethod]
        public void GivenAValidCommandToTurnLeft_WhenTheCommandIsExecuted_ThenRoverShouldTurnLeft()
        {
            Rover rover = GivenARover(1, 1, CardinalCompass.North);
            WhenACommandIsExecuted(rover, "L");
            ThenIExpectARoverOnThePosition(rover, 1, 1, CardinalCompass.West);

            rover = GivenARover(1, 1, CardinalCompass.West);
            WhenACommandIsExecuted(rover, "L");
            ThenIExpectARoverOnThePosition(rover, 1, 1, CardinalCompass.South);

            rover = GivenARover(1, 1, CardinalCompass.South);
            WhenACommandIsExecuted(rover, "L");
            ThenIExpectARoverOnThePosition(rover, 1, 1, CardinalCompass.East);

            rover = GivenARover(1, 1, CardinalCompass.East);
            WhenACommandIsExecuted(rover, "L");
            ThenIExpectARoverOnThePosition(rover, 1, 1, CardinalCompass.North);
        }

        [TestMethod]
        public void GivenAValidCommandToMove_WhenTheCommandIsExecuted_ThenRoverShouldMove()
        {
            Rover rover = GivenARover(1, 1, CardinalCompass.North);
            WhenACommandIsExecuted(rover, "M");
            ThenIExpectARoverOnThePosition(rover, 1, 2, CardinalCompass.North);

            rover = GivenARover(1, 1, CardinalCompass.West);
            WhenACommandIsExecuted(rover, "M");
            ThenIExpectARoverOnThePosition(rover, 0, 1, CardinalCompass.West);

            rover = GivenARover(1, 1, CardinalCompass.South);
            WhenACommandIsExecuted(rover, "M");
            ThenIExpectARoverOnThePosition(rover, 1, 0, CardinalCompass.South);

            rover = GivenARover(1, 1, CardinalCompass.East);
            WhenACommandIsExecuted(rover, "M");
            ThenIExpectARoverOnThePosition(rover, 2, 1, CardinalCompass.East);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenAnInvalidCommand_WhenTheCommandIsExecuted_ThenIExpectAnError()
        {
            Rover rover = GivenARover(1, 1, CardinalCompass.North);
            WhenACommandIsExecuted(rover, "O873k2");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenACommand_WhenItLeadsTheRoverToOutsideThePlateau_ThenIExpectAnError()
        {
            Rover rover = GivenARover(5, 5, CardinalCompass.North);
            WhenACommandIsExecuted(rover, "RMMLM");
        }
    }
}
