using System;
namespace PlacesLib
{
    public class Megapolis : City
    {
        protected int metroStations;
        protected int[] districtAreas; // площади районов
        public int MetroStations
        {
            get { return metroStations; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Число станций метро не может быть отрицательным");
                    metroStations = value;
            }
        }
        public int[] DistrictAreas { get { return districtAreas; } }
        public Megapolis() : base() { metroStations = 0; districtAreas = new int[0]; }
        public Megapolis(string name, int population, string regionName,
        int metroStations, int[] districtAreas)
        : base(name, population, regionName)
        {
            MetroStations = metroStations;
            this.districtAreas = (int[])districtAreas.Clone();
        }
        public Megapolis(Megapolis m) : base(m)
        {
            metroStations = m.metroStations;
            districtAreas = (int[])m.districtAreas.Clone(); // копия массива
        }
        public override void Show()
        {
            Console.WriteLine("Мегаполис: " + name + ", область: " + regionName
            + ", жителей: " + population + ", станций метро: " + metroStations
            + ", районов: " + districtAreas.Length);
            Console.Write("Площади районов:");
            foreach (int a in districtAreas)
                Console.Write(" " + a);
            Console.WriteLine();
        }
        public new void ShowNonVirtual()
        {
            Console.WriteLine("[невирт.] Мегаполис: " + name);
        }
        public override void Init()
        {
            base.Init();
            MetroStations = ReadInt("Станций метро: ");
            int n = ReadInt("Число районов: ");
            districtAreas = new int[n];
            for (int i = 0; i < n; i++)
                districtAreas[i] = ReadInt("Площадь района " + (i + 1) + ": ");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            population = rnd.Next(1000000, 5000000); // мегаполис — от миллиона жителей
            metroStations = rnd.Next(1, 60);
            districtAreas = new int[rnd.Next(3, 8)];
            for (int i = 0; i < districtAreas.Length; i++)
                districtAreas[i] = rnd.Next(10, 300);
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;
            Megapolis m = (Megapolis)obj;
            if (m.metroStations != metroStations) return false;
            if (m.districtAreas.Length != districtAreas.Length) return false;
            for (int i = 0; i < districtAreas.Length; i++)
                if (m.districtAreas[i] != districtAreas[i]) return false;
            return true;
        }
        public override int GetHashCode() { return base.GetHashCode() + metroStations; }
        public override object Clone() { return new Megapolis(this); }
    }
}
