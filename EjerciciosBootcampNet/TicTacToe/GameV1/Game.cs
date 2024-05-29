using System;

namespace EjerciciosBootcampNet
{
    public class Game
    {
        private static char[][] table = new char[3][];
        private static int numberOfMarked = 0;
        public void TicTacToeMatch()
        {
            ResetTable();

            Console.WriteLine("Empiezas tu!! Con X\n");
            while (true)
            {
                DisplayTable();                                 // Mostrar la tabla
                RequestMarkPosition();                          // Preguntar al usuario la posición donde marcar

                if (CheckTableWinner() != null)                 // Comprobar si hay algun ganador o se termino la partida
                {
                    Console.WriteLine(CheckTableWinner());      // Mostrar mensaje final de la partida
                    return;
                }
            }

        }

        private void ResetTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new char[3];
                for (int j = 0; j < table[i].Length; j++)
                {
                    table[i][j] = '-';
                }
            }
        }

        private void DisplayTable()
        {
            foreach (var row in table)
            {
                foreach (var mark in row)
                {
                    Console.Write($" {mark} ");
                }
                Console.WriteLine();
            }
        }

        private void RequestMarkPosition()
        {
            while (true)
            {
                Console.Write("\nEn que fila quieres marcar? (0-2): ");
                int rowTable = RequestNumber();

                Console.Write("En que columna quieres marcar? (0-2): ");
                int columnTable = RequestNumber();

                if (CheckTheBox(rowTable, columnTable))
                {
                    table[rowTable][columnTable] = 'X'; // Marcar en la posición
                    numberOfMarked++;
                    return;
                }
                else
                {
                    Console.Write($"\nLa Casilla {rowTable}-{columnTable} esta ocupada!\n\n");
                    DisplayTable();
                }
            }
        }

        private int RequestNumber()
        {
            int number;
            bool numberValid;

            do
            {
                numberValid = int.TryParse(Console.ReadLine(), out number);

                if (number > 2 || number < 0)
                    Console.WriteLine("\nTiene que ser un numero del 0 - 2!!");
                else if (!numberValid)
                    Console.WriteLine("\nIntroduce un numero!!");

            } while (!numberValid);

            return number;
        }

        public void RandomMarkMachine()
        {
            Random rnd = new Random();
            int rowNumber;
            int columnNumber;

            while (true)
            {
                rowNumber = rnd.Next(3);
                columnNumber = rnd.Next(3);

                if (CheckTheBox(rowNumber, columnNumber))
                {
                    table[rowNumber][columnNumber] = 'O';
                    numberOfMarked++;
                    return;
                }
            }

        }

        public bool CheckTheBox(int row, int column)
        {
            if (table[row][column] == '-')
                return true;
            else
                return false;
        }

        public string CheckTableWinner()
        {
            int numberOfBoxes = table.Length*table.Length; // Numero de casillas de la tabla

            char symbolO = 'O';
            char symbolX = 'X';

            if (numberOfMarked != numberOfBoxes) // Si aun no esta todo marcado, seguir jugando
                RandomMarkMachine();

            if (CheckSymbolPlayer(symbolO))
                return "Has perdido la partida!!";
            else if (CheckSymbolPlayer(symbolX))
                return "Enhorabuena has ganado la partida!!";
            else if (numberOfMarked == numberOfBoxes)
                return "Empateee!!!";
            else
                return null;
        }

        public bool CheckSymbolPlayer(char symbol)
        {
            if (table[0][0] == symbol && table[0][1] == symbol && table[0][2] == symbol) // Primer fila
                return true;
            else if (table[1][0] == symbol && table[1][1] == symbol && table[1][2] == symbol) // Segunda fila
                return true;
            else if (table[2][0] == symbol && table[2][1] == symbol && table[2][2] == symbol) // Tercera fila
                return true;
            else if (table[0][0] == symbol && table[1][0] == symbol && table[2][0] == symbol) // Primer columna
                return true;
            else if (table[0][1] == symbol && table[1][1] == symbol && table[2][1] == symbol) // Segunda columna
                return true;
            else if (table[0][2] == symbol && table[1][2] == symbol && table[2][2] == symbol) // Tercera columna
                return true;
            else if (table[0][0] == symbol && table[1][1] == symbol && table[2][2] == symbol) // Primera diagonal
                return true;
            else if (table[0][2] == symbol && table[1][1] == symbol && table[2][0] == symbol) // Primera diagonal
                return true;
            else
                return false;
        }
    }
}
