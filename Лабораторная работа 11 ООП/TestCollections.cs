using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab11
{
    // Задание 3: время поиска в коллекциях
    class TestCollections
    {
        public List<Student> col1 = new List<Student>();
        public List<string> col2 = new List<string>();
        public Dictionary<Person, Student> col3 = new Dictionary<Person, Student>();
        public Dictionary<string, Student> col4 = new Dictionary<string, Student>();

        // создаём коллекции из count элементов
        public TestCollections(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Student s = MakeStudent(i);
                AddToAll(s);
            }
        }

        // имена разные, чтобы ключи не повторялись
        static Student MakeStudent(int i)
        {
            return new Student("Student" + i, 18 + i % 10, 1 + i % 4, "РИС-25-" + (i % 3 + 1) + "б");
        }

        // добавляем элемент во все 4 коллекции
        public void AddToAll(Student s)
        {
            col1.Add(s);
            col2.Add(s.ToString());
            col3.Add(s.BasePerson, s);
            col4.Add(s.ToString(), s);
        }

        // удаляем элемент из всех 4 коллекций
        public bool RemoveFromAll(Student s)
        {
            bool result = col1.Remove(s);
            col2.Remove(s.ToString());
            col3.Remove(s.BasePerson);
            col4.Remove(s.ToString());
            return result;
        }

        // измеряем время поиска элемента s
        void Measure(string title, Student s)
        {
            Stopwatch sw = new Stopwatch();
            bool found;

            Console.WriteLine("--- " + title + " ---");

            sw.Start();
            found = col1.Contains(s);
            sw.Stop();
            Console.WriteLine("List<Student>.Contains:               " + sw.ElapsedTicks + " тиков, найден: " + found);

            sw.Restart();
            found = col2.Contains(s.ToString());
            sw.Stop();
            Console.WriteLine("List<string>.Contains:                " + sw.ElapsedTicks + " тиков, найден: " + found);

            sw.Restart();
            found = col3.ContainsKey(s.BasePerson);
            sw.Stop();
            Console.WriteLine("Dictionary<Person,Student>.ContainsKey:   " + sw.ElapsedTicks + " тиков, найден: " + found);

            sw.Restart();
            found = col4.ContainsKey(s.ToString());
            sw.Stop();
            Console.WriteLine("Dictionary<string,Student>.ContainsKey:   " + sw.ElapsedTicks + " тиков, найден: " + found);

            sw.Restart();
            found = col3.ContainsValue(s);
            sw.Stop();
            Console.WriteLine("Dictionary<Person,Student>.ContainsValue: " + sw.ElapsedTicks + " тиков, найден: " + found);
        }

        public void RunTest()
        {
            int n = col1.Count;

            // создаём новые объекты с тем же содержимым
            Student first = new Student(col1[0].Name, col1[0].Age, col1[0].Course, col1[0].Group);
            Student middle = new Student(col1[n / 2].Name, col1[n / 2].Age, col1[n / 2].Course, col1[n / 2].Group);
            Student last = new Student(col1[n - 1].Name, col1[n - 1].Age, col1[n - 1].Course, col1[n - 1].Group);
            Student absent = new Student("Нет такого", 99, 9, "Нет");

            // пробный поиск, чтобы первый замер не был слишком большим
            col1.Contains(absent);
            col2.Contains(absent.ToString());
            col3.ContainsKey(absent.BasePerson);
            col4.ContainsKey(absent.ToString());
            col3.ContainsValue(absent);

            Measure("Первый элемент", first);
            Measure("Центральный элемент", middle);
            Measure("Последний элемент", last);
            Measure("Элемента нет в коллекции", absent);
        }
    }
}
