using System;
namespace PlacesLib
{
    public class City : Place
    {
        protected int population;
        protected string regionName;
        public int Population
        {
            get { return population; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Население не может быть отрицательным");
                population = value;
            }
        }
        public string RegionName
        {
            get { return regionName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Область не может быть пустой");
                regionName = value;
            }
        }
        public City() : base() { population = 0; regionName = "Не задана"; }
        public City(string name, int population, string regionName) : base(name)
        {
            Population = population;
            RegionName = regionName;
        }
        public City(City c) : base(c)
        {
            population = c.population;
            regionName = c.regionName;
        }
        public override void Show()
        {
            Console.WriteLine("Город: " + name + ", область: " + regionName + ", жителей: "
            + population);
        }
        public new void ShowNonVirtual()
        {
            Console.WriteLine("[невирт.] Город: " + name);
        }
        public override void Init()
        {
            base.Init();
            Population = ReadInt("Население: ");
            Console.Write("Область: ");
            RegionName = Console.ReadLine();
        }
        public override void RandomInit()
        {
            int i = rnd.Next(RegionNames.Length);
            regionName = RegionNames[i];
            name = CitiesByRegion[i][rnd.Next(CitiesByRegion[i].Length)];
            population = rnd.Next(10000, 1000000);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj)
            && ((City)obj).population == population
            && ((City)obj).regionName == regionName;
        }
        public override int GetHashCode() { return name.GetHashCode() + population; }
        public override object Clone() { return new City(this); }
    }
}