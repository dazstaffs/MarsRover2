using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover2
{
    public class Rover
    {
        private int _xcoordinate;
        private int _ycoordinate;
        private char _compassDirection;
        private IDirectionAction _directionAction;

        public Rover(int x, int y, char direction)
        {
            this._xcoordinate = x;
            this._ycoordinate = y;
            this._compassDirection = direction;
        }

        public string GetPosition()
        {
            return String.Format("The rover's current position is {0},{1},{2}", _xcoordinate, _ycoordinate, _compassDirection);
        }

        public void ProcessInstruction(string characters)
        {
            char[] array = characters.ToCharArray();

            foreach (char character in array)
            {
                setDirectionAction();
                if (character != 'M')
                {
                    this._compassDirection = _directionAction.Spin(character);
                }
                else
                {
                    if (this._compassDirection == 'N' || this._compassDirection == 'S')
                    {
                        this._ycoordinate = _directionAction.Move();
                    }
                    if (this._compassDirection == 'E' || this._compassDirection == 'W')
                    {
                        this._xcoordinate = _directionAction.Move();
                    }
                }
            }
        }

        private void setDirectionAction()
        {
            if (_compassDirection == 'N')
            {
                _directionAction = new NorthDirectionAction(_ycoordinate);
                return;
            }
            if (_compassDirection == 'E')
            {
                _directionAction = new EastDirectionAction(_xcoordinate);
                return;
            }
            if (_compassDirection == 'S')
            {
                _directionAction = new SouthDirectionAction(_ycoordinate);
                return;
            }
            if (_compassDirection == 'W')
            {
                _directionAction = new WestDirectionAction(_xcoordinate);
                return;
            }
            else
            {
                throw new Exception("Direction Unknown");
            }
        }
    }
}
