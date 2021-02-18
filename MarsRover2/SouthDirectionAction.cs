using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover2
{
    public class SouthDirectionAction : IDirectionAction
    {
        private int ycoordinate;
        public SouthDirectionAction(int y)
        {
            this.ycoordinate = y;
        }

        public char Spin(char direction)
        {
            if (direction == 'L')
            {
                return 'E';
            }
            if (direction == 'R')
            {
                return 'W';
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
                ycoordinate = ycoordinate - 1;             
            }
            return ycoordinate;
        }

        private bool validateMove()
        {
            if (ycoordinate == 0)
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
