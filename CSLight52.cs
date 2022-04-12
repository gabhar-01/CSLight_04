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
            IncreaseDossier(ref fullName, "Введите ФИО: ");
            IncreaseDossier(ref jobPosition, "\nВведите должность: ");

            Console.WriteLine("\nДосье добавлено.");
        }

        static void IncreaseDossier(ref string[] dossierArray, string input)
        {
            Console.Write(input);
            string[] tempDossierArray = new string[dossierArray.Length + 1];

            for (int i = 0; i < dossierArray.Length; i++)
            {
                tempDossierArray[i] = dossierArray[i];
            }

            tempDossierArray[tempDossierArray.Length - 1] = Console.ReadLine();
            dossierArray = tempDossierArray;
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
            index = Convert.ToInt32(Console.ReadLine()) - 1;

            ReduceDossierInMiddle(ref fullName, index);
            ReduceDossierInMiddle(ref jobPosition, index);

            Console.WriteLine("\nДосье номер " + (index + 1) + " удалено.");
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
                ReduceDossierInMiddle(ref fullName, index);
                ReduceDossierInMiddle(ref jobPosition, index);

                Console.WriteLine("\nДосье удалено.");
            }
            else
            {
                Console.WriteLine("Сотрудник не найден.");
            }
        }

        static void ReduceDossierInMiddle (ref string[] dossierArray, int index)
        {
            string[] tempDossierArray = new string[dossierArray.Length - 1];

            for (int j = 0; j < index; j++)
            {
                tempDossierArray[j] = dossierArray[j];
            }

            for (int j = index + 1; j < dossierArray.Length; j++)
            {
                tempDossierArray[j - 1] = dossierArray[j];
            }

            dossierArray = tempDossierArray;
        }

        static void DeleteRecent(ref string[] fullName, ref string[] jobPosition)
        {
            Console.WriteLine((fullName.Length) + ". " + fullName[fullName.Length - 1] + " - " + jobPosition[jobPosition.Length - 1]);

            ReduceDossier(ref fullName);
            ReduceDossier(ref jobPosition);

            Console.WriteLine("\nПоследнее досье удалено.");
        }

        static void ReduceDossier(ref string[] dossierArray)
        {
            string[] tempDossierArray = new string[dossierArray.Length - 1];

            for (int i = 0; i < tempDossierArray.Length; i++)
            {
                tempDossierArray[i] = dossierArray[i];
            }

            dossierArray = tempDossierArray;
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
