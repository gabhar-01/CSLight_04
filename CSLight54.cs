using System;

namespace CSLight54
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку для конвертации в число:");
            Console.WriteLine("Конвертированное число: " + ReadInt());

            Console.ReadKey();
        }

        static int ReadInt()
        {
            int numberResult = 0;
            bool isCorrect;

            bool isRunning = true;

            while (isRunning)
            {               
                isCorrect = int.TryParse(Console.ReadLine(), out numberResult);

                if (isCorrect)
                {
                    isRunning = false;
                }
            }

            return numberResult;
        }
    }
}
