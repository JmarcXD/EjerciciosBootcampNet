using System;

namespace EjerciciosBootcampNet
{
    public class Aplication
    {
        public void ApplicationMenu()
        {
            Game game = new Game();
            GameV2 gameV2 = new GameV2();
            Game3D game3D = new Game3D();
            Ahorcado ahorcado = new Ahorcado();
            TraductorMorse tr = new TraductorMorse();
            SnakeApplication snk = new SnakeApplication();
            SnakeV2Application snkV2 = new SnakeV2Application();

            while (true)
            {
                int option = Menu(); // Pedir al usuario que desea hacer

                switch (option)
                {
                    case 1:
                        game.TicTacToeMatch();
                        break;
                    case 2:
                        gameV2.TicTacToeMatch();
                        break;
                    case 3:
                        game3D.TicTacToeMatch();
                        break;
                    case 4:
                        ahorcado.HangManGame();
                        break;
                    case 5:
                        tr.MorseCodeTraductor();
                        break;
                    case 6:
                        snkV2.SnakeGame();
                        break;
                    default:
                        return;
                }
            }

        }

        public int Menu()
        {
            int maxNumber = 6;

            int optionNumber;
            bool numberValid;


            do
            {
                Console.Write(@"
(1) Jugar 3 en raya
(2) Jugar N en raya
(3) Jugar N en raya en 3D
(4) Jugar Ahorcado
(5) Traductor Morse
(6) Jugar Snake
(0) Salir
Introduce el numero: ");
                numberValid = int.TryParse(Console.ReadLine(), out optionNumber);

                if (optionNumber > maxNumber || optionNumber < 0)
                    Console.WriteLine($"\nTiene que ser un numero del 0 - {maxNumber}!!");
                else if (!numberValid)
                    Console.WriteLine("\nIntroduce un numero!!");

            } while (!numberValid || optionNumber > maxNumber || optionNumber < 0);

            return optionNumber;
        }
    }
}
