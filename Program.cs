using System;

namespace clearArhitecture
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("RobotStartWork");
            var robot = new Robot();
            robot.StartWork(@"F:\C#\clear_arhitecture\clearArhitecture\inputCommands.txt");
            Console.WriteLine("RobotEndWork");
        }
    }
}