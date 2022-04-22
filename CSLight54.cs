using System;

namespace CSLight54
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Конвертированное число: " + ReadIntNumber());
            
            Console.ReadKey();
            Console.Clear();
        }

        static string ReadUserInput ()
        {
            Console.Write("Введите строку для конвертации в число: ");
            return Console.ReadLine();
        }

        static int ReadIntNumber()
        {
            int numberResult;
            bool isCorrect;

            bool isRunning = true;

            while (isRunning)
            {               
                isCorrect = int.TryParse(ReadUserInput(), out numberResult);

                if (isCorrect)
                {
                    isRunning = false;
                }
            }

            return numberResult;
        }
    }
}
