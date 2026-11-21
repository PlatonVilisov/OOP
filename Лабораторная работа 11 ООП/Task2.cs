using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11
{
    // Задание 2: коллекция Dictionary<int, Person>
    class Task2
    {
        static Dictionary<int, Person> dict = new Dictionary<int, Person>();
        static int nextKey = 1;   // номер для нового ключа

        public static void Run()
        {
            AddPerson(new Person("Иван", 40));
            AddPerson(new Student("Анна", 19, 2, "РИС-25-1б"));
            AddPerson(new Student("Борис", 20, 3, "РИС-25-2б"));
            AddPerson(new Person("Мария", 35));
            AddPerson(new Student("Виктор", 18, 1, "РИС-25-3б"));

            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Задание 2. Dictionary<int, Person>");
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент по ключу");
                Console.WriteLine("3. Печать всех элементов (foreach)");
                Console.WriteLine("4. Запрос: количество студентов");
                Console.WriteLine("5. Запрос: печать людей старше заданного возраста");
                Console.WriteLine("6. Запрос: печать студентов заданного курса");
                Console.WriteLine("7. Клонирование коллекции");
                Console.WriteLine("8. Сортировка по имени");
                Console.WriteLine("9. Поиск элемента");
                Console.WriteLine("0. Назад");
                choice = Input.ReadInt("Ваш выбор: ");

                switch (choice)
                {
                    case 1: Add(); break;
                    case 2: Remove(); break;
                    case 3: Print(dict); break;
                    case 4: CountStudents(); break;
                    case 5: PrintOlder(); break;
                    case 6: PrintCourse(); break;
                    case 7: CloneDict(); break;
                    case 8: SortDict(); break;
                    case 9: Find(); break;
                }
            }
        }

        static void AddPerson(Person p)
        {
            dict.Add(nextKey, p);
            nextKey++;
        }

        static void Add()
        {
            Person p = Input.ReadPerson();
            AddPerson(p);
            Console.WriteLine("Элемент добавлен с ключом " + (nextKey - 1));
        }

        static void Remove()
        {
            int key = Input.ReadInt("Введите ключ: ");
            if (dict.Remove(key))
                Console.WriteLine("Элемент удалён");
            else
                Console.WriteLine("Такого ключа нет");
        }

        static void Print(Dictionary<int, Person> d)
        {
            if (d.Count == 0)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }
            foreach (KeyValuePair<int, Person> pair in d)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }

        // запрос 1
        static void CountStudents()
        {
            int count = 0;
            foreach (KeyValuePair<int, Person> pair in dict)
            {
                if (pair.Value is Student)
                    count++;
            }
            Console.WriteLine("Количество студентов: " + count);
        }

        // запрос 2
        static void PrintOlder()
        {
            int age = Input.ReadInt("Введите возраст: ");
            foreach (KeyValuePair<int, Person> pair in dict)
            {
                if (pair.Value.Age > age)
                    Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }

        // запрос 3
        static void PrintCourse()
        {
            int course = Input.ReadInt("Введите курс: ");
            int found = 0;
            foreach (KeyValuePair<int, Person> pair in dict)
            {
                if (pair.Value is Student)
                {
                    Student s = (Student)pair.Value;
                    if (s.Course == course)
                    {
                        Console.WriteLine(pair.Key + ": " + s);
                        found++;
                    }
                }
            }
            if (found == 0)
                Console.WriteLine("Студентов этого курса нет");
        }

        static void CloneDict()
        {
            // копируем и сами объекты через Clone()
            Dictionary<int, Person> copy = new Dictionary<int, Person>();
            foreach (KeyValuePair<int, Person> pair in dict)
            {
                copy.Add(pair.Key, (Person)pair.Value.Clone());
            }
            Console.WriteLine("Копия коллекции (" + copy.Count + " элементов):");
            Print(copy);

            // проверяем, что копия независима
            if (copy.Count > 0)
            {
                foreach (int key in copy.Keys)
                {
                    copy.Remove(key);
                    break;
                }
            }
            Console.WriteLine("После удаления из копии: в оригинале " + dict.Count + ", в копии " + copy.Count);
        }

        static void SortDict()
        {
            // словарь нельзя отсортировать, поэтому берём значения в список
            List<Person> list = new List<Person>(dict.Values);
            list.Sort();

            Console.WriteLine("Элементы, отсортированные по имени:");
            foreach (Person p in list)
            {
                Console.WriteLine(p);
            }
        }

        static void Find()
        {
            int type = Input.ReadInt("Искать по: 1 - ключу, 2 - значению (Person): ");
            if (type == 1)
            {
                int key = Input.ReadInt("Введите ключ: ");
                if (dict.ContainsKey(key))
                    Console.WriteLine("Найден: " + dict[key]);
                else
                    Console.WriteLine("Ключ не найден");
            }
            else
            {
                string name = Input.ReadString("Введите имя: ");
                int age = Input.ReadInt("Введите возраст: ");
                Person p = new Person(name, age);
                if (dict.ContainsValue(p))
                    Console.WriteLine("Такой элемент есть в коллекции");
                else
                    Console.WriteLine("Элемент не найден");
            }
        }
    }
}
