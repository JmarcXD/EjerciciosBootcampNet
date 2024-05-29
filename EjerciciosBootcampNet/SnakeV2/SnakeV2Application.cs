using System;
using System.Threading;

namespace EjerciciosBootcampNet
{
    public class SnakeV2Application
    {
        
        public void SnakeGame()
        {
            Board.InicializePanelSnake();
            Board.GenerateRandomFood();
            Snake.InicializeSnake();
          
            while (true)
            {
                Console.Clear(); // Limpiar la consola

                Input.HandleInput(); // Escuchar el teclado

                Snake.Controls();

                Board.DisplayPanel(); // Mostrar el tablero

                if (Snake.CollisionWalls())
                    return;


                Thread.Sleep(100); // Delay de 100 milisegundos
                
            }
        }
    }
}
