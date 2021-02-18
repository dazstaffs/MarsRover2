using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover2
{
    public class EastDirectionAction : IDirectionAction
    {
        private int xcoordinate;
        public EastDirectionAction(int x)
        {
            this.xcoordinate = x;
        }

        public char Spin(char direction)
        {
            if (direction == 'L')
            {
                return 'N';
            }
            if (direction == 'R')
            {
                return 'S';
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
                xcoordinate = xcoordinate + 1;             
            }
            return xcoordinate;
        }

        private bool validateMove()
        {
            if (xcoordinate == 5)
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
