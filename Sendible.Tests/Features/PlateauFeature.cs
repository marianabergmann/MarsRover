using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sendible.Models;

namespace Sendible.Tests.Features
{
    [TestClass]
    public class PlateauFeature
    {
        public static Plateau GivenAPlateau(int x, int y)
        { 
            return new Plateau(x,y);
        }

        private void ThenIExpectAPlateau(Plateau plateau, int expectedUpperX, int expectedUpperY) {
            Assert.IsNotNull(plateau);
            Assert.AreEqual(plateau.UpperRightX, expectedUpperX);
            Assert.AreEqual(plateau.UpperRightY, expectedUpperY);
            Assert.AreEqual(plateau.LowerLeftX, 0);
            Assert.AreEqual(plateau.LowerLeftY, 0);
        }

        [TestMethod]
        public void GivenAValidPlateau_ThenIExpectAPlateau()
        {
            Plateau plateau = GivenAPlateau(5, 6);
            ThenIExpectAPlateau(plateau, 5, 6);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenAnInvalidPlateau_ThenIExpectAnError()
        {
            GivenAPlateau(-1, -5);            
        }
    }
}
