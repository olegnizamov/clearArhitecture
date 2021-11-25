using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace clearArhitecture
{
    public class Robot
    {
        private double X;
        private double Y;
        private int currentAngleInDegrees;
        private string currentTools;


        public Robot()
        {
            //Устанавливаем текущее положение
            this.X = 0;
            this.Y = 0;
            this.currentAngleInDegrees = 0;
            this.currentTools = Tools.water;
        }


        //Парсим данные и вызываем ExectuteTask
        public void StartWork(string fileName)
        {
            List<string> commandsList = File.ReadAllLines(fileName).ToList();
            this.ExectuteTask(commandsList);
        }

        public void ExectuteTask(List<string> commands)
        {
            foreach (String command in commands)
            {
                string[] actionCommand = command.Split(' ');

                string operation = actionCommand[0];

                switch (operation)
                {
                    case "move":
                        this.Move(Convert.ToInt32(actionCommand[1]));
                        break;
                    case "turn":
                        this.Turn(Convert.ToInt32(actionCommand[1]));
                        break;
                    case "set":
                        this.Set(actionCommand[1]);
                        break;
                    case "start":
                        this.Start();
                        break;
                    case "stop":
                        this.Stop();
                        break;
                    default:
                        throw new Exception($"Action {operation} not supported");
                }
            }
        }

        public void Move(int meters)
        {
            var angleInRadian = Math.PI * this.currentAngleInDegrees / 180.0;
            this.X += meters * Math.Cos(angleInRadian);
            this.Y += meters * Math.Sin(angleInRadian);
            Console.WriteLine($"POS {this.X},{this.Y}");
        }

        public void Turn(int angelInDegrees)
        {
            this.currentAngleInDegrees += angelInDegrees;
            Console.WriteLine($"ANGLE {angelInDegrees}");
        }

        public void Set(string tool)
        {
            this.currentTools = tool;
            Console.WriteLine($"STATE {tool}");
        }

        public void Start()
        {
            Console.WriteLine($"START WITH {this.currentTools}");
        }

        public void Stop()
        {
            Console.WriteLine("STOP");
        }
    }
}