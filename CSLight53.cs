using System;

namespace CSLight53
{
    class Program
    {
        static void Main(string[] args)
        {
            int healthValue = 8;
            int healthMaxValue = 10;
            int healthPositionX = 2;
            int healthPositionY = 2;
            char healthSymbol = '&';

            int manaValue = 4;
            int manaMaxValue = 10;
            int manaPositionX = 2;
            int manaPositionY = 3;
            char manaSymbol = '#';

            DrawBar(healthValue, healthMaxValue, healthPositionX, healthPositionY, healthSymbol);
            DrawBar(manaValue, manaMaxValue, manaPositionX, manaPositionY, manaSymbol);

            Console.ReadKey();
        }

        static void DrawBar (int value, int maxValue, int positionX, int positionY, char symbol)
        {
            Console.SetCursorPosition(positionX, positionY);
            
            Console.Write("[");

            for (int i = 0; i < value; i++)
            {
                Console.Write(symbol);
            }

            for (int i = value; i < maxValue; i++)
            {
                Console.Write("_");
            }

            Console.Write("]");
            Console.Write($"\t{value}0%");
        }
    }
}
