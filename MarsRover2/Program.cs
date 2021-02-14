using System;

namespace MarsRover2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sending instructions to Rover 1");
            string roverOneInstructions = "LMLMLMLMM";
            Rover rover1 = new Rover(1 ,2, 'N');
            rover1.ProcessInstruction(roverOneInstructions);
            Console.WriteLine(rover1.GetPosition());

            Console.WriteLine("Sending instructions to Rover 2");
            string roverTwoInstructions = "MMRMMRMRRM";
            Rover rover2 = new Rover(3, 3, 'E');
            rover2.ProcessInstruction(roverTwoInstructions);
            Console.WriteLine(rover2.GetPosition());

            Console.ReadLine();
        }
    }
}
