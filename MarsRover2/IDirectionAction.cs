namespace MarsRover2
{
    public interface IDirectionAction
    {
        int Move();
        char Spin(char direction);
    }
}