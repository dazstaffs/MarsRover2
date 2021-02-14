using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover2
{
    public class Rover
    {
        private int xcoordinate;
        private int ycoordinate;
        private Direction compassDirection;

        public Rover(int x, int y, char direction)
        {
            this.xcoordinate = x;
            this.ycoordinate = y;
            this.compassDirection = (Direction)Enum.Parse(typeof(Direction), direction.ToString());
        }

        public string GetPosition()
        {
            return String.Format("The rover's current position is {0},{1},{2}", xcoordinate, ycoordinate, compassDirection);
        }

        public void Spin(char direction)
        {
            int directionDegrees = (int)compassDirection;
            if (direction == 'L')
            {
                directionDegrees = directionDegrees - 90;
            }
            if (direction == 'R')
            {
                directionDegrees = directionDegrees + 90;
            }
            directionDegrees = validateDirection(directionDegrees);
            compassDirection = (Direction)directionDegrees;
        }

        public void Move()
        {
            bool validMove = validateMove();

            if (validMove)
            {
                if (compassDirection == Direction.N)
                {
                    ycoordinate = ycoordinate + 1;
                }
                if (compassDirection == Direction.E)
                {
                    xcoordinate = xcoordinate + 1;
                }
                if (compassDirection == Direction.S)
                {
                    ycoordinate = ycoordinate - 1;
                }
                if (compassDirection == Direction.W)
                {
                    xcoordinate = xcoordinate - 1;
                }
            }
            else
            {
                return;
            }

        }

        public void ProcessInstruction(string characters)
        {
            char[] array = characters.ToCharArray();

            foreach (char character in array)
            {
                if (character != 'M')
                {
                    this.Spin(character);
                }
                else
                {
                    this.Move();
                }
            }
        }

        private bool validateMove()
        {
            if (xcoordinate == 0 && compassDirection == Direction.W)
            {
                return false;
            }
            if (xcoordinate == 5 && compassDirection == Direction.E)
            {
                return false;
            }
            if (ycoordinate == 0 && compassDirection == Direction.S)
            {
                return false;
            }
            if (ycoordinate == 5 && compassDirection == Direction.N)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static int validateDirection(int directionDegrees)
        {
            if (directionDegrees == -90)
            {
                directionDegrees = 270;
            }
            if (directionDegrees == 450)
            {
                directionDegrees = 90;
            }
            if (directionDegrees == 360)
            {
                directionDegrees = 0;
            }

            return directionDegrees;
        }


    }
}
