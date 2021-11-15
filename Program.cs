using System;

namespace clearArhitecture
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("RobotStartWork");
            var robot = new Robot();
            robot.StartWork(@"F:\Высшая Школа Программирования Сергея Бобровского\Ясная Архитектура\code\clearArhitecture\inputCommands.txt");
            Console.WriteLine("RobotEndWork");
        }
    }
}