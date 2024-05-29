using System;
using EjerciciosBootcampNet;

namespace EjerciciosBootcampNet
{
    public class Input
    {
        public static void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch(key)
                {
                    case ConsoleKey.UpArrow:
                        if (Snake.currentDirection != eDirection.Down) // Comprobrar que no esta en dirección contraria
                            Snake.currentDirection = eDirection.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        if (Snake.currentDirection != eDirection.Up) // Comprobrar que no esta en dirección contraria
                            Snake.currentDirection = eDirection.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Snake.currentDirection != eDirection.Right) // Comprobrar que no esta en dirección contraria
                            Snake.currentDirection = eDirection.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        if (Snake.currentDirection != eDirection.Left) // Comprobrar que no esta en dirección contraria
                            Snake.currentDirection = eDirection.Right;
                        break;
                }
            }
        }
    }
}
