using System;
namespace PlacesLib
{
    public class Address : Place
    {
        static readonly string[] Streets = { "Ленина", "Мира", "Гагарина", "Пушкина", "Кирова" };
        protected string street;
        protected int house;
        protected int flat;
        public string Street
        {
            get { return street; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Улица не может быть пустой");
                street = value;
            }
        }
        public int House
        {
            get { return house; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Номер дома должен быть положительным");
                house = value;
            }
        }
        public int Flat
        {
            get { return flat; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Номер квартиры не может быть отрицательным");
                    flat = value;
            }
        }
        public Address() : base() { street = "Не задана"; house = 1; flat = 0; }
        public Address(string city, string street, int house, int flat) : base(city)
        {
            Street = street;
            House = house;
            Flat = flat;
        }
        public Address(Address a) : base(a)
        {
            street = a.street;
            house = a.house;
            flat = a.flat;
        }
        public override void Show()
        {
            Console.WriteLine("Адрес: г. " + name + ", ул. " + street + ", д. " + house + ", кв. "
            + flat);
        }
        public new void ShowNonVirtual()
        {
            Console.WriteLine("[невирт.] Адрес: г. " + name);
        }
        public override void Init()
        {
            base.Init();
            Console.Write("Улица: ");
            Street = Console.ReadLine();
            House = ReadInt("Дом: ");
            Flat = ReadInt("Квартира: ");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            street = Streets[rnd.Next(Streets.Length)];
            house = rnd.Next(1, 200);
            flat = rnd.Next(1, 300);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj)
            && ((Address)obj).street == street
            && ((Address)obj).house == house
            && ((Address)obj).flat == flat;
        }
        public override int GetHashCode() { return name.GetHashCode() + house; }
        public override object Clone() { return new Address(this); }
    }
}