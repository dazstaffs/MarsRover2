using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover2
{
    public class NorthDirectionAction : IDirectionAction
    {
        private int ycoordinate;
        public NorthDirectionAction(int y)
        {
            this.ycoordinate = y;
        }

        public char Spin(char direction)
        {
            if (direction == 'L')
            {
                return 'W';
            }
            if (direction == 'R')
            {
                return 'E';
            }
            else
            {
                throw new Exception(String.Format("direction unknown {0}", direction));
            }
        }

        public int Move()
        {
            bool validMove = validateMove();

            if (validMove)
            {
                ycoordinate = ycoordinate + 1;             
            }
            return ycoordinate;

        }

        private bool validateMove()
        {
            if (ycoordinate == 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
