using System;

namespace CSLight56
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
          
            FillArray(ref array);
            WriteArray(array);

            Shuffle(ref array);

            WriteArray(array);

            Console.ReadKey();
        }

        static void Shuffle (ref int[] array)
        {
            int randomElementToShuffle;
            int temp;

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                randomElementToShuffle = random.Next(0, array.Length);

                temp = array[randomElementToShuffle];
                array[randomElementToShuffle] = array[i];
                array[i] = temp;
            }
        }

        static void FillArray (ref int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 50);
            }
        }

        static void WriteArray (int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
