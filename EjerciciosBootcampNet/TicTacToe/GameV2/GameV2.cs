using System;

namespace EjerciciosBootcampNet
{
    public class GameV2
    {
        private static char[][] table;
        private static int numberOfMarked = 0;
        public void TicTacToeMatch()
        {
            Console.Write("Introduce las dimensiones de la tabla: ");
            int dimensionNumber = RequestNumber(1, int.MaxValue);


            InicializeTable(dimensionNumber);
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

        private void InicializeTable(int dimensionNumber)
        {
            table = new char[dimensionNumber][];
        }

        private void ResetTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new char[table.Length];
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
                Console.Write($"\nEn que fila quieres marcar? (0-{table.Length-1}): ");
                int rowTable = RequestNumber(0, table.Length-1);

                Console.Write($"En que columna quieres marcar? (0-{table.Length-1}): ");
                int columnTable = RequestNumber(0, table.Length-1);

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

        private int RequestNumber(int minNumber, int maxNumber)
        {
            int number;
            bool numberValid;

            while (true)
            {
                numberValid = int.TryParse(Console.ReadLine(), out number);

                if (number > maxNumber || number < minNumber)
                    Console.Write($"Tiene que ser un numero del {minNumber} - {maxNumber}!! Introduce el numero: ");
                else if (!numberValid)
                    Console.Write("Introduce un numero!! Introduce el numero: ");
                else
                {
                    return number;
                }
            }
        }

        public void RandomMarkMachine()
        {
            Random rnd = new Random();
            int rowNumber;
            int columnNumber;

            while (true)
            {
                rowNumber = rnd.Next(table.Length);
                columnNumber = rnd.Next(table.Length);

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

            if (CheckSymbolPlayer(symbolX))
                return "Enhorabuena has ganado la partida!!";
            else if (CheckSymbolPlayer(symbolO))
                return "Has perdido la partida!!";
            else if (numberOfMarked == numberOfBoxes)
                return "Empateee!!!";
            else
                return null;
        }

        public bool CheckSymbolPlayer(char symbol)
        {
            if (CheckHorizontal(symbol))
                return true;
            else if (CheckVertical(symbol))
                return true;
            else if (CheckDiagonalRight(symbol))
                return true;
            else if (CheckDiagonalLeft(symbol))
                return true;
            else
                return false;
        }

        public bool CheckHorizontal(char symbol)
        {
            bool inLineSymbols = false;

            foreach (char[] row in table)
            {
                int countSymbolsMarked = 0;
                foreach (char mark in row)
                {
                    if (mark == symbol)
                        countSymbolsMarked++;
                }

                if (countSymbolsMarked == table.Length)
                    inLineSymbols = true;
            }

            return inLineSymbols;
        }

        public bool CheckVertical(char symbol)
        {
            bool inLineSymbols = false;

            for (int i = 0; i < table.Length; i++)
            {
                int countSymbolsMarked = 0;
                foreach (char[] row in table)
                {
                    if (row[i] == symbol)
                        countSymbolsMarked++;
                }

                if (countSymbolsMarked == table.Length)
                    inLineSymbols = true;
            }

            return inLineSymbols;
        }

        public bool CheckDiagonalRight(char symbol)
        {
            bool inLineSymbols = false;
            int countSymbolsMarked = 0;

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i][i] == symbol)
                    countSymbolsMarked++;
            }

            if (countSymbolsMarked == table.Length)
                inLineSymbols = true;

            return inLineSymbols;
        }

        public bool CheckDiagonalLeft(char symbol)
        {
            bool inLineSymbols = false;
            int countSymbolsMarked = 0;
            int column = table.Length-1;


            foreach (char[] row in table)
            {
                if (row[column] == symbol)
                {
                    countSymbolsMarked++;
                    column--;
                }
            }

            if (countSymbolsMarked == table.Length)
                inLineSymbols = true;

            return inLineSymbols;
        }
    }
}
