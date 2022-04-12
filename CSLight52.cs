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
                "\n4 - Поиск досье по фамилии." +
                "\n5 - Выход.");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        AddDossier(ref fullName, ref jobPosition);
                        break;
                    case 2:
                        OutputAllDossiers(fullName, jobPosition);
                        break;
                    case 3:
                        DeleteDossier(ref fullName, ref jobPosition);
                        break;
                    case 4:
                        FindByLastName(fullName, jobPosition);
                        break;
                    case 5:
                        isRunning = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddDossier (ref string[] fullName, ref string[] jobPosition)
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
            if (fullName.Length == 0)
            {
                Console.WriteLine("Досье отсутствуют.");
            }
            else
            {
                for (int i = 0; i < fullName.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + fullName[i] + " - " + jobPosition[i]);
                }
            }
        }

        static void DeleteDossier(ref string[] fullName, ref string[] jobPosition)
        {
            if (fullName.Length == 0)
            {
                Console.WriteLine("Досье отсутствуют.");
            }
            else
            {
                Console.WriteLine("1 - Удалить досье по номеру. " +
                            "\n2 - Удалить досье по фамилии." +
                            "\n3 - Удалить последнее досье.");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        DeleteByIndex(ref fullName, ref jobPosition);
                        break;
                    case 2:
                        DeleteByLastName(ref fullName, ref jobPosition);
                        break;
                    case 3:
                        DeleteRecent(ref fullName, ref jobPosition);
                        break;
                }
            }
        }

        static void DeleteByIndex(ref string[] fullName, ref string[] jobPosition)
        {
            int index;
            Console.Write("\nВведите номер досье: ");
            index = Convert.ToInt32(Console.ReadLine());

            string[] tempFullName = new string[fullName.Length - 1];
            string[] tempJobPosition = new string[jobPosition.Length - 1];

            for (int i = 0; i < index - 1; i++)
            {
                tempFullName[i] = fullName[i];
                tempJobPosition[i] = jobPosition[i];
            }

            for (int i = index; i < fullName.Length; i++)
            {
                tempFullName[i - 1] = fullName[i];
                tempJobPosition[i - 1] = jobPosition[i];
            }

            fullName = tempFullName;
            jobPosition = tempJobPosition;

            Console.WriteLine("\nДосье номер " + index + " удалено.");
        }

        static void DeleteByLastName(ref string[] fullName, ref string[] jobPosition)
        {
            int lastNameCounter = 0;
            int index = 0;
            int oneDossier = 1;
            string lastName;
            Console.Write("\nВведите фамилию: ");
            lastName = Console.ReadLine();

            for (int i = 0; i < fullName.Length; i++)
            {
                string[] separateWords = fullName[i].Split(' ');

                if (separateWords[0] == lastName)
                {
                    lastNameCounter++;
                    index = i;
                    Console.WriteLine((i + 1) + ". " + fullName[i] + " - " + jobPosition[i]);
                }
            }

            if (lastNameCounter > oneDossier)
            {
                Console.Write("\nНайдено несколько досье с соответствующей фамилией. ");
                DeleteByIndex(ref fullName, ref jobPosition);
            }
            else if (lastNameCounter == oneDossier)
            {
                string[] temporaryFullName = new string[fullName.Length - 1];
                string[] temporaryJobPosition = new string[jobPosition.Length - 1];

                for (int j = 0; j < index; j++)
                {
                    temporaryFullName[j] = fullName[j];
                    temporaryJobPosition[j] = jobPosition[j];
                }

                for (int j = index + 1; j < fullName.Length; j++)
                {
                    temporaryFullName[j - 1] = fullName[j];
                    temporaryJobPosition[j - 1] = jobPosition[j];
                }

                fullName = temporaryFullName;
                jobPosition = temporaryJobPosition;

                Console.WriteLine("\nДосье удалено.");
            }
            else
            {
                Console.WriteLine("Сотрудник не найден.");
            }
        }

        static void DeleteRecent(ref string[] fullName, ref string[] jobPosition)
        {
            string[] tempFullName = new string[fullName.Length - 1];
            string[] tempJobPosition = new string[jobPosition.Length - 1];

            Console.WriteLine((fullName.Length) + ". " + fullName[fullName.Length - 1] + " - " + jobPosition[jobPosition.Length - 1]);

            for (int i = 0; i < tempFullName.Length; i++)
            {
                tempFullName[i] = fullName[i];
            }

            fullName = tempFullName;

            for (int i = 0; i < tempFullName.Length; i++)
            {
                tempJobPosition[i] = jobPosition[i];
            }

            jobPosition = tempJobPosition;

            Console.WriteLine("\nПоследнее досье удалено.");
        }

        static void FindByLastName(string[] fullName, string[] jobPosition)
        {
            if (fullName.Length == 0)
            {
                Console.WriteLine("Досье отсутствуют.");
            }
            else
            {
                int counter = 0;
                string lastName;
                Console.Write("\nВведите фамилию: ");
                lastName = Console.ReadLine();

                Console.WriteLine("\nРезультаты поиска:\n");

                for (int i = 0; i < fullName.Length; i++)
                {
                    string[] separateWords = fullName[i].Split(' ');

                    if (separateWords[0] == lastName)
                    {
                        Console.WriteLine((i + 1) + ". " + fullName[i] + " - " + jobPosition[i]);
                        counter++;
                    }
                }

                if (counter == 0)
                {
                    Console.WriteLine("Сотрудник не найден.");
                }
            }
        }
    }
}
