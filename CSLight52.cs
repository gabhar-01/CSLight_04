using System;

namespace CSLight52
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fullName = new string [0];
            string[] jobPosition = new string [0];

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1 - Добавить досье." +
                "\n2 - Вывести все досье." +
                "\n3 - Удалить досье." +
                "\n4 - Поиск по фамилии." +
                "\n5 - Выход.");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        //AddDossier(fullName, jobPosition); <= не работает

                        //работает =>

                        Console.Write("Введите ФИО: ");
                        string[] tempFullName = new string[fullName.Length + 1];

                        for (int i = 0; i < fullName.Length; i++)
                        {
                            tempFullName[i] = fullName[i];
                        }

                        tempFullName[tempFullName.Length - 1] = Console.ReadLine();
                        fullName = tempFullName;

                        Console.Write("\nВведите должность: ");
                        string[] tempJobPosition = new string[jobPosition.Length + 1];

                        for (int i = 0; i < jobPosition.Length; i++)
                        {
                            tempJobPosition[i] = jobPosition[i];
                        }

                        tempJobPosition[tempJobPosition.Length - 1] = Console.ReadLine();
                        jobPosition = tempJobPosition;

                        Console.WriteLine("\nДосье добавлено.");

                        break;
                    case 2:
                        OutputAllDossiers(fullName, jobPosition);
                        break;
                    case 3:
                        //удалить досье (Массивы уменьшаются на один элемент. Нужны дополнительные проверки, чтобы не возникало ошибок)
                        DeleteDossier();
                        break;
                    case 4:
                        //поиск по фамилии
                        FindByLastName();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddDossier (string[] fullName, string[] jobPosition)
        {
            Console.Write("Введите ФИО: ");
            string[] tempFullName = new string[fullName.Length + 1];
            
            for (int i = 0; i < fullName.Length; i++)
            {
                tempFullName[i] = fullName[i];
            }

            tempFullName[tempFullName.Length - 1] = Console.ReadLine();
            fullName = tempFullName;

            Console.Write("\nВведите должность: ");
            string[] tempJobPosition = new string[jobPosition.Length + 1];

            for (int i = 0; i < jobPosition.Length; i++)
            {
                tempJobPosition[i] = jobPosition[i];
            }

            tempJobPosition[tempJobPosition.Length - 1] = Console.ReadLine();
            jobPosition = tempJobPosition;

            Console.WriteLine("\nДосье добавлено.");
        }

        static void OutputAllDossiers (string[] fullName, string[] jobPosition)
        {
            for (int i = 0; i < fullName.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + fullName[i] + " - " + jobPosition[i]);
            }
        }

        static void DeleteDossier()
        {

        }

        static void FindByLastName ()
        {

        }
    }
}
