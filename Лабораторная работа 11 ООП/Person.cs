using System;

namespace Lab11
{
    // Базовый класс
    class Person : IComparable, ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Name = "Без имени";
            Age = 0;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return "Person: " + Name + ", возраст " + Age;
        }

        // сравниваем по содержимому
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            Person p = (Person)obj;
            return Name == p.Name && Age == p.Age;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age;
        }

        // для сортировки по имени
        public int CompareTo(object obj)
        {
            if (!(obj is Person))
                throw new ArgumentException("Объект не является Person");
            Person p = (Person)obj;
            return string.Compare(Name, p.Name);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
