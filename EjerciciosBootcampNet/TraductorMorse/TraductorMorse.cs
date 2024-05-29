using System;

namespace EjerciciosBootcampNet
{
    public class TraductorMorse
    {
        public void MorseCodeTraductor()
        {
            string[] morseCode = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." };
            char[] alfabetsAndNumbers = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            int option = Menu();

            if (option == 1)
                TraduceTextToMorseCode(morseCode, alfabetsAndNumbers);
            else
                TraduceMorseCodeToText(morseCode, alfabetsAndNumbers);
        }

        private int Menu()
        {
            int traductorOption; // Tipo de traducción
            bool isNumberOption; // Control de errores

            // Menu
            do
            {
                Console.Write(@"
(1) Traducir de codigo morse a texto
(2) Traducir de texto a código morse
Introduce el numero: ");
                isNumberOption = int.TryParse(Console.ReadLine(), out traductorOption);

                if (!isNumberOption)
                    Console.WriteLine("\nIntroduce un numero no string!\n");
                else if (traductorOption > 2 || traductorOption == 0)
                    Console.WriteLine("\nIntroduce un numero del 1 al 2\n");

            } while (!isNumberOption && traductorOption > 2 || traductorOption == 0);

            return traductorOption;
        }

        private void TraduceTextToMorseCode(string[] morseCode, char[] alfabetsAndNumbers)
        {
            string sentence;
            string morseCodeTraduced = "";

            Console.Write("\nIntroduce la cadena: ");
            sentence = Console.ReadLine();

            for (int i = 0; i < sentence.Length; i++) // Convertir en foreach
            {
                int positionAlfabet = 0;
                bool characterFound = false;

                // Buscar el caracter (sale del bucle hasta que encuentre)
                // Cambiar a metodo
                while (!characterFound)
                {
                    if (Char.ToLower(sentence[i]) == alfabetsAndNumbers[positionAlfabet])     // Caracter entonctrado
                    {
                        morseCodeTraduced += morseCode[positionAlfabet] + " ";
                        characterFound = true;
                    }
                    else if (sentence[i] == ' ')                                              // Caracter Espacio
                    {
                        morseCodeTraduced += " / ";
                        characterFound = true;
                    }
                    else if (positionAlfabet == morseCode.Length - 1)                         // Caracter o numero no encontrado
                    {
                        //Poner un interrogante en el caracter correspondiente
                        Console.WriteLine($"No se encuentra el carácter {sentence[i]}");
                        characterFound = true;
                    }

                    positionAlfabet++;
                }
            }

            Console.WriteLine($"\n{morseCodeTraduced}");
        }

        private void TraduceMorseCodeToText(string[] morseCode, char[] alfabetsAndNumbers)
        {
            string morseCodeSentence;
            string[] listDigitMorseCode;
            string sentenceTextTraduced = "";

            Console.Write("\nIntroduce el código morse (espacio por cada caracter y para hacer espacio /): ");
            morseCodeSentence = Console.ReadLine();

            listDigitMorseCode = morseCodeSentence.Split(' '); //Divido los codigos

            // Buscar caracter de cada código
            foreach (string code in listDigitMorseCode)
            {
                int positionCodeMorse = 0;
                bool codeMorseFound = false;

                while (!codeMorseFound)
                {
                    if (code == morseCode[positionCodeMorse])                           // Codigo encontrado
                    {
                        sentenceTextTraduced += alfabetsAndNumbers[positionCodeMorse];
                        codeMorseFound = true;
                    }
                    else if (code == "/")                                               // Espacio
                    {
                        sentenceTextTraduced += " ";
                        codeMorseFound = true;
                    }
                    else if (positionCodeMorse == morseCode.Length - 1)                    // Codigo no encontrado
                    {
                        Console.WriteLine($"No se ha encontrado el codigo {code}");
                        codeMorseFound = true;
                    }
                    positionCodeMorse++;
                }
            }

            Console.WriteLine($"\n{sentenceTextTraduced}");
        }
    }
}
