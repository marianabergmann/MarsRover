using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sendible.Models
{
    public class Plateau
    {
        public int UpperRightX { get; private set; }
        public int UpperRightY { get; private set; }
        public int LowerLeftX { get; private set; }
        public int LowerLeftY { get; private set; }

        public Plateau(int upperRightX, int upperRightY)
        {
            if (upperRightX < 0 || upperRightY < 0)
                throw new Exception("Upper right and left of the plateau must be positive numbers!");

            UpperRightX = upperRightX;
            UpperRightY = upperRightY;
            LowerLeftX = 0;
            LowerLeftY = 0;
        }
    }
}