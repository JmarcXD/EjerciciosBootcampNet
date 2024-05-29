using System;

namespace EjerciciosBootcampNet
{
    internal class Board
    {
        public static char[,] panelSnake = new char[20, 80];

        public static void InicializePanelSnake()
        {
            for (int i = 0; i < panelSnake.GetLength(0); i++) // Itera sobre las filas
            {
                for (int j = 0; j < panelSnake.GetLength(1); j++) // Itera sobre las columnas
                {
                    if (i == 0)
                        panelSnake[i, j] = '#';
                    else if (j == 0)
                        panelSnake[i, j] = '#';
                    else if (i == panelSnake.GetLength(0) - 1)
                        panelSnake[i, j] = '#';
                    else if (j == panelSnake.GetLength(1) - 1)
                        panelSnake[i, j] = '#';
                    else
                        panelSnake[i, j] = ' ';
                }
                Console.WriteLine(); // Salto de línea 
            }
        }

        public static void DisplayPanel()
        {
            for (int i = 0; i < panelSnake.GetLength(0); i++) // Itera sobre las filas
            {
                for (int j = 0; j < panelSnake.GetLength(1); j++) // Itera sobre las columnas
                {
                    Console.Write(panelSnake[i, j]); // Imprime el carácter seguido de un espacio
                }
                Console.WriteLine(); // Salto de línea a
            }
        }

        public static void GenerateRandomFood()
        {
            Random random = new Random();

            int y = random.Next(panelSnake.GetLength(0)-1);
            int x = random.Next(panelSnake.GetLength(1)-1);

            panelSnake[y, x] = '8';
        }

        public static void GenerateRandomPoison()
        {
            Random rnd = new Random();

            int y = rnd.Next(panelSnake.GetLength(0) - 1);
            int x = rnd.Next(panelSnake.GetLength(1) - 1);

            panelSnake[y, x] = 'X';
        }
    }
}
