using System;
using System.Threading;

namespace EjerciciosBootcampNet
{
    public class TableSnake
    {
        int Width = 30; // Ancho
        int Height = 20;// Altura

        int[] snakeX = new int[50];
        int[] snakeY = new int[50];

        int fruitX;
        int fruitY;

        int parts = 3;

        Random rnd = new Random();

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        public char key = 's';

        public TableSnake()
        {
            snakeX[0] = 5;
            snakeY[0] = 5;
            Console.CursorVisible = false;
        }

        public void InputKey()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }



        public void DrawTable()
        {
            // Limpiar la pantalla de la consola
            Console.Clear();


            // Horizontal superior
            for (int i = 1; i <= (Width+2); i++)
            {
                Console.SetCursorPosition(i, 1); // SetCursorPosition(i, 0); Sirve para establecer la posición en la pantalla de la consola
                Console.Write("#");

            }

            // Horizontal inferior
            for (int i = 1; i <= (Width+2); i++)
            {
                Console.SetCursorPosition(i, (Height+2));
                Console.Write("#");
            }

            // Vertical izquierdo
            for (int i = 1; i <= (Height+1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("#");
            }

            // Vertical derecho
            for (int i = 1; i <= (Height+1); i++)
            {
                Console.SetCursorPosition((Width+2), i);
                Console.Write("#");
            }
        }

        public void WritePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }

        public void Logic()
        {
            if (snakeX[0] == fruitX)
            {
                if (snakeY[0] == fruitY)
                {
                    parts++;
                    fruitX = rnd.Next(2, (Width-2));
                    fruitY = rnd.Next(2, (Height-2));

                }
            }

            for (int i = parts; i > 1; i--)
            {
                snakeX[i -1] = snakeX[i-2];
                snakeY[i -1] = snakeY[i-2];
            }

            switch (key)
            {
                case 'w':
                    snakeY[0]--;
                    break;
                case 's':
                    snakeY[0]++;
                    break;
                case 'd':
                    snakeX[0]++;
                    break;
                case 'a':
                    snakeX[0]--;
                    break;
            }

            for (int i = 0; i <=(parts-1); i++)
            {
                WritePoint(snakeX[0], snakeY[0]);
                WritePoint(fruitX, fruitY);
            }
            Thread.Sleep(100);
        }
    }
}
