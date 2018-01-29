using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SnakeClassLibrary;

namespace SnakeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 100;
            Console.WindowHeight = 50;
            Console.CursorVisible = false;

            Snake snake = new Snake(new Coords(20, 20), Snake.Direction.N, 5);

            bool N = false;
            bool E = false;
            bool S = false;
            bool W = false;
            bool GROW = false;

            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    if (N) snake.CurrentDirection = Snake.Direction.N;
                    if (E) snake.CurrentDirection = Snake.Direction.E;
                    if (S) snake.CurrentDirection = Snake.Direction.S;
                    if (W) snake.CurrentDirection = Snake.Direction.W;
                    if (GROW)
                    {
                        snake.Grow();
                        GROW = false;
                    }

                    snake.Move();
                    
                    Console.Clear();

                    foreach (Snake.Segment segment in snake.Segments)
                    {
                        if (segment.Coords.X >= 0 && segment.Coords.X <= Console.WindowWidth && segment.Coords.Y >= 0 && segment.Coords.Y <= Console.WindowHeight)
                        {
                            Console.CursorLeft = segment.Coords.X;
                            Console.CursorTop = segment.Coords.Y;

                            Console.Write(snake.Character[(int)segment.Type, (int)segment.Direction]);
                        }
                    }

                    Thread.Sleep(250);
                };

                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                N = keyPressed == ConsoleKey.W;
                E = keyPressed == ConsoleKey.D;
                S = keyPressed == ConsoleKey.S;
                W = keyPressed == ConsoleKey.A;
                GROW = keyPressed == ConsoleKey.Spacebar;
            }
        }
    }
}
