using System;
namespace PlacesLib
{
    public class Place : IInit, IComparable, ICloneable
    {
        protected static Random rnd = new Random();
        public static readonly string[] RegionNames = { "Пермский край", "Московская область", "Ленинградская область" };
        public static readonly string[][] CitiesByRegion = 
        {
            new string[] { "Пермь", "Березники", "Соликамск" },
            new string[] { "Москва", "Подольск", "Химки" },
            new string[] { "Санкт-Петербург", "Гатчина", "Выборг" }
        };
        public static readonly string[] CityNames = { "Пермь", "Березники", "Соликамск", "Москва", "Подольск", "Химки", "Гатчина", "Выборг" };
        protected string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не может быть пустым");
                name = value;
            }
        }
        // три конструктора: без параметров, с параметрами, копирования
        public Place() { name = "Без названия"; }
        public Place(string name) { Name = name; }
        public Place(Place other) { name = other.name; }
        // ввод целого числа (нужен потомкам в Init)
        protected static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }
        public virtual void Show()
        {
            Console.WriteLine("Место: " + name);
        }
        // обычный (невиртуальный) метод — для сравнения с виртуальным Show()
        public void ShowNonVirtual()
        {
            Console.WriteLine("[невирт.] Место: " + name);
        }
        public virtual void Init()
        {
            Console.Write("Название: ");
            Name = Console.ReadLine();
        }
        public virtual void RandomInit()
        {
            name = CityNames[rnd.Next(CityNames.Length)];
        }
        // объекты равны, если совпадает точный тип и все поля
        public override bool Equals(object obj)
        {
            return obj != null && obj.GetType() == GetType()
            && ((Place)obj).name == name;
        }
        public override int GetHashCode() { return name.GetHashCode(); }
        // IComparable: сортировка по названию (часть 3)
        public int CompareTo(object obj)
        {
            Place p = obj as Place;
            if (p == null)
                throw new ArgumentException("Сравнивать можно только с Place");
            return string.Compare(name, p.name, StringComparison.CurrentCulture);
        }
        // ICloneable: полное клонирование (часть 3)
        public virtual object Clone() { return new Place(this); }
        // поверхностное копирование (часть 3)
        public Place ShallowCopy() { return (Place)MemberwiseClone(); }
    }
}