using System;

namespace EjerciciosBootcampNet
{
    public class Ahorcado
    {
        public void HangManGame()
        {
            // Player
            int mistakes = 0;
            int numberOfLettersGuessed = 0;
            bool game = false;

            string wordToGuess = "ZAPATOS";
            char[] charactersWord = separateWordToCharacters(wordToGuess);
            char[] displayWord = InicializeArrayDisplayWord(wordToGuess.Length);

            Console.WriteLine("Tienes 11 vidas para adivinar la palabra\n");

            do
            {
                char letter = RequestCharacter();
                bool letterFound = false;

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (letter == charactersWord[i])   // Si coincide, mostrar el caracter
                    {
                        displayWord[i] = Char.ToUpper(charactersWord[i]);
                        letterFound = true;
                        numberOfLettersGuessed++;
                    }
                }

                if (!letterFound)
                    mistakes++;

                DisplayWordToUser(displayWord);

                if (mistakes != 0)
                    DisplayHangManToUser(mistakes);

                if (numberOfLettersGuessed == wordToGuess.Length)
                    game = true;

            } while (mistakes != 11 && !game);

            if (game)
                Console.WriteLine("Enhorabuena has adivinado la palabra secreta!!!");
            else
                Console.WriteLine("Muy mal has perdido!!");
        }

        private char RequestCharacter()
        {
            bool isCharacter;
            char letter;

            do
            {
                Console.Write("Introduce una letra: ");
                isCharacter = char.TryParse(Console.ReadLine(), out letter);

                if (!isCharacter)
                    Console.WriteLine("Introduce un Carácter!!");

            } while (!isCharacter);

            return letter;
        }


        private char[] separateWordToCharacters(string word)
        {
            string wordToLower = word.ToLower();
            char[] charactersWord = wordToLower.ToCharArray();

            return charactersWord;
        }


        private void DisplayWordToUser(char[] word)
        {
            string wordToDisplay = "";

            foreach (char letter in word)
            {
                wordToDisplay += letter+" ";
            }

            Console.WriteLine($"Palabra:  {wordToDisplay}");
        }


        private void DisplayHangManToUser(int mistakes)
        {
            DrawHangMan(mistakes);
        }


        private char[] InicializeArrayDisplayWord(int wordLength)
        {
            char[] displayCharacters = new char[wordLength];

            for (int i = 0; i < wordLength; i++)
            {
                displayCharacters[i] = '-';
            }

            return displayCharacters;
        }


        private void DrawHangMan(int numberOfMistakes)
        {
            switch (numberOfMistakes)
            {
                case 1:
                    Console.WriteLine(" \n" +
                        "             \n" +
                        "             \n" +
                        "             \n"+
                        "             \n" +
                        "             \n" +
                        "             \n" +
                        "--------");
                    break;
                case 2:
                    Console.WriteLine(" \n" +
                        "|             \n" +
                        "|             \n" +
                        "|             \n"+
                        "|             \n" +
                        "|             \n" +
                        "|\n" +
                        "--------");
                    break;
                case 3:
                    Console.WriteLine("---------     \n" +
                         "|             \n" +
                         "|             \n" +
                         "|             \n"+
                         "|             \n" +
                         "|             \n" +
                         "|\n" +
                         "--------");
                    break;
                case 4:
                    Console.WriteLine("---------     \n" +
                          "|      |      \n" +
                          "|             \n" +
                          "|             \n"+
                          "|             \n" +
                          "|             \n" +
                          "|\n" +
                          "--------");
                    break;
                case 5:
                    Console.WriteLine("---------     \n" +
                          "|      |      \n" +
                          "|      O      \n" +
                          "|             \n"+
                          "|             \n" +
                          "|             \n" +
                          "|\n" +
                          "--------");
                    break;
                case 6:
                    Console.WriteLine("---------     \n" +
                           "|      |      \n" +
                           "|      O      \n" +
                           "|      |      \n"+
                           "|             \n" +
                           "|             \n" +
                           "|\n" +
                           "--------");
                    break;
                case 7:
                    Console.WriteLine("---------     \n" +
                            "|      |      \n" +
                            "|      O      \n" +
                            "|     /|      \n"+
                            "|             \n" +
                            "|             \n" +
                            "|\n" +
                            "--------");
                    break;
                case 8:
                    Console.WriteLine("---------     \n" +
                             "|      |      \n" +
                             "|      O      \n" +
                             "|     /|\\    \n"+
                             "|             \n" +
                             "|             \n" +
                             "|\n" +
                             "--------");
                    break;
                case 9:
                    Console.WriteLine("---------     \n" +
                             "|      |      \n" +
                             "|      O      \n" +
                             "|     /|\\    \n"+
                             "|      |      \n" +
                             "|             \n" +
                             "|\n" +
                             "--------");
                    break;
                case 10:
                    Console.WriteLine("---------     \n" +
                             "|      |      \n" +
                             "|      O      \n" +
                             "|     /|\\    \n"+
                             "|      |      \n" +
                             "|     /     \n" +
                             "|\n" +
                             "--------");
                    break;
                case 11:
                    Console.WriteLine("---------     \n" +
                             "|      |      \n" +
                             "|      O      \n" +
                             "|     /|\\    \n"+
                             "|      |      \n" +
                             "|     / \\    \n" +
                             "|\n" +
                             "--------");
                    break;
            }
        }
    }
}
