using System;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Практическая работа 11. Коллекции");
                Console.WriteLine("1. Задание 1 (Queue)");
                Console.WriteLine("2. Задание 2 (Dictionary)");
                Console.WriteLine("3. Задание 3 (время поиска в коллекциях)");
                Console.WriteLine("0. Выход");
                choice = Input.ReadInt("Ваш выбор: ");

                switch (choice)
                {
                    case 1:
                        Task1.Run();
                        break;
                    case 2:
                        Task2.Run();
                        break;
                    case 3:
                        TestCollections tc = new TestCollections(1000);
                        Console.WriteLine("Создано элементов: " + tc.col1.Count);
                        tc.RunTest();
                        break;
                }
            }
        }
    }
}
