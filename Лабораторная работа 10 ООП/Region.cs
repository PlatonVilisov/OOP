using System;
namespace PlacesLib
{
    public class Region : Place
    {
        protected string center; //  центр области
        protected int area; // площадь
        public string Center
        {
            get { return center; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Центр не может быть пустым");
                center = value;
            }
        }
        public int Area
        {
            get { return area; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Площадь должна быть больше нуля");
                area = value;
            }
        }
        public Region() : base() { center = "Не задан"; area = 1; }
        public Region(string name, string center, int area) : base(name)
        {
            Center = center;
            Area = area;
        }
        public Region(Region r) : base(r)
        {
            center = r.center;
            area = r.area;
        }
        public override void Show()
        {
            Console.WriteLine("Область: " + name + ", центр: " + center + ", площадь: " +
            area + " км²");
        }
        public new void ShowNonVirtual()
        {
            Console.WriteLine("[невирт.] Область: " + name);
        }
        public override void Init()
        {
            base.Init();
            Console.Write("Центр: ");
            Center = Console.ReadLine();
            Area = ReadInt("Площадь, км²: ");
        }
        public override void RandomInit()
        {
            int i = rnd.Next(RegionNames.Length);
            name = RegionNames[i];
            center = CitiesByRegion[i][0];   // центр области: первый город в списке
            area = rnd.Next(10000, 200000);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj) && ((Region)obj).center == center && ((Region)obj).area == area;
        }
        public override int GetHashCode() { return name.GetHashCode() + area; }
        public override object Clone() { return new Region(this); }
    }
}