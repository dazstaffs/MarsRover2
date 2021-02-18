using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover2
{
    public class WestDirectionAction : IDirectionAction
    {
        private int xcoordinate;
        public WestDirectionAction(int x)
        {
            this.xcoordinate = x;
        }

        public char Spin(char direction)
        {
            if (direction == 'L')
            {
                return 'S';
            }
            if (direction == 'R')
            {
                return 'N';
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
                xcoordinate = xcoordinate - 1;
            }
            return xcoordinate;

        }

        private bool validateMove()
        {
            if (xcoordinate == 0)
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
