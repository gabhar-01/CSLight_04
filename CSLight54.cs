using System;

namespace CSLight54
{
    class Program
    {
        static void Main(string[] args)
        {
            TryToInt();
        }

        static string RequestNumber ()
        {
            Console.Write("Введите строку для конвертации в число: ");
            return Console.ReadLine();
        }

        static void TryToInt ()
        {
            int numResult;
            bool isCorrect;

            bool isRunning = true;

            while (isRunning)
            {
                string userInput = RequestNumber();
               
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
