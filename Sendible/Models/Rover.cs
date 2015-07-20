using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sendible.Models
{
    public enum CardinalCompass {
        North = 'N',
        South = 'S',
        East = 'E',
        West = 'W'
    }

    public class Rover
    {
        public int PointX { get; set; }
        public int PointY { get; set; }
        public CardinalCompass CardinalCompass { get; set; }

        public Rover(int pointX, int pointY, CardinalCompass cardinalCompass)
        {
            if (pointX < 0 || pointY < 0)
                throw new Exception("X and Y co-ordinates must be positive numbers!");

            PointX = pointX;
            PointY = pointY;
            CardinalCompass = cardinalCompass;
        }

        public string getPosition()
        {
            return PointX + " " + PointY + " " + CardinalCompass;
        }

        public string SetCommands(string command, Plateau plateau)
        {
            foreach (char letter in command)
            {
                switch (letter)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        Move(plateau);
                        break;
                    default:
                        throw new Exception("Invalid command!");
                }
            }
            return getPosition();
        }

        public bool isRoverInsidePlateau(Plateau plateau)
        {
            switch (CardinalCompass)
            {
                case CardinalCompass.North:
                    if (PointY != plateau.UpperRightY)
                        return true;
                    else return false;
                case CardinalCompass.South:
                    if (PointY != plateau.LowerLeftY)
                        return true;
                    else return false;
                case CardinalCompass.East:
                    if (PointX != plateau.UpperRightX)
                        return true;
                    else return false;
                case CardinalCompass.West:
                    if (PointX != plateau.LowerLeftX)
                        return true;
                    else return false;
            }
            return false;
        }

        private void Move(Plateau plateau)
        {
            if (!isRoverInsidePlateau(plateau))
            {
                throw new Exception("Rover cannot go outside the plateau!");
            }
            switch (CardinalCompass)
            {
                case CardinalCompass.North:
                    PointY++;
                    break;
                case CardinalCompass.South:
                    PointY--;
                    break;
                case CardinalCompass.East:
                    PointX++;
                    break;
                case CardinalCompass.West:
                    PointX--;
                    break;
            }
        }

        private void TurnLeft()
        {
            switch(CardinalCompass){
                case CardinalCompass.North:
                    CardinalCompass = CardinalCompass.West;
                    break;
                case CardinalCompass.South:
                    CardinalCompass = CardinalCompass.East;                    
                    break;
                case CardinalCompass.East:
                    CardinalCompass = CardinalCompass.North;                    
                    break;
                case CardinalCompass.West:
                    CardinalCompass = CardinalCompass.South;                    
                    break;            
            }
        }

        private void TurnRight()
        {
            switch (CardinalCompass)
            {
                case CardinalCompass.North:
                    CardinalCompass = CardinalCompass.East;
                    break;
                case CardinalCompass.South:
                    CardinalCompass = CardinalCompass.West;
                    break;
                case CardinalCompass.East:
                    CardinalCompass = CardinalCompass.South;
                    break;
                case CardinalCompass.West:
                    CardinalCompass = CardinalCompass.North;
                    break;
            }
        }
    }
}