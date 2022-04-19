using System;

namespace CSLight56
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
          
            Fill(array);
            Write(array);

            Shuffle(array);

            Write(array);

            Console.ReadKey();
        }

        static void Shuffle (int[] array)
        {
            int randomIndex;
            int temporaryElement;

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                randomIndex = random.Next(0, array.Length);

                temporaryElement = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = temporaryElement;
            }
        }

        static void Fill (int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 50);
            }
        }

        static void Write (int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
