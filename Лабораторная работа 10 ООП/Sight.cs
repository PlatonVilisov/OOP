using System;
namespace PlacesLib
{
    public class Sight : IInit
    {
        static Random rnd = new Random();
        static readonly string[] Titles = { "Красная площадь", "Гатчинский дворец", "Выборгский замок", "Пермская галерея" };
        string title;
        int year;
        public Sight() { title = "Без названия"; year = 2000; }
        public void Show()
        {
            Console.WriteLine("Достопримечательность: " + title + ", год: " + year);
        }
        public void Init()
        {
            Console.Write("Название: ");
            title = Console.ReadLine();
            Console.Write("Год основания: ");
            year = Convert.ToInt32(Console.ReadLine());
        }
        public void RandomInit()
        {
            title = Titles[rnd.Next(Titles.Length)];
            year = rnd.Next(1700, 2020);
        }
    }
}