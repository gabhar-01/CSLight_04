using System;

namespace CSLight54
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int numResult;
            bool isCorrect;

            ConvertToInt(out userInput, out numResult, out isCorrect);
        }

        static void RequestNumber (out string userInput)
        {
            Console.Write("Введите строку для конвертации в число: ");
            userInput = Console.ReadLine();
        }

        static void ConvertToInt (out string userInput, out int numResult, out bool isCorrect)
        {
            bool isRunning = true;

            while (isRunning)
            {
                RequestNumber(out userInput);
               
                isCorrect = int.TryParse(userInput, out numResult);

                if (isCorrect)
                {
                    Console.WriteLine("Число конвертировано корректно: " + numResult);
                    isRunning = false;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
