using System;

namespace CSLight53
{
    class Program
    {
        static void Main(string[] args)
        {
            int healthValue = 80;
            int healthMaxValue = 100;
            int healthPositionX = 2;
            int healthPositionY = 2;
            char healthSymbol = '&';

            int manaValue = 23257;
            int manaMaxValue = 100000;
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

            int barLength = 10;
            int decimalValue = value * barLength / maxValue;

            for (int i = 0; i < decimalValue; i++)
            {
                Console.Write(symbol);
            }

            for (int i = decimalValue; i < barLength; i++)
            {
                Console.Write("_");
            }

            Console.Write("]");
            Console.Write($"\t{value}%/{maxValue}%");
        }
    }
}
