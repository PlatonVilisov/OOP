using System;
using System.Collections;

namespace Lab11
{
    // Задание 1: коллекция Queue
    class Task1
    {
        static Queue queue = new Queue();

        public static void Run()
        {
            // добавим несколько элементов
            queue.Enqueue(new Person("Иван", 40));
            queue.Enqueue(new Student("Анна", 19, 2, "РИС-25-1б"));
            queue.Enqueue(new Student("Борис", 20, 3, "РИС-25-2б"));
            queue.Enqueue(new Person("Мария", 35));
            queue.Enqueue(new Student("Виктор", 18, 1, "РИС-25-3б"));

            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Задание 1. Коллекция Queue");
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент (из начала очереди)");
                Console.WriteLine("3. Печать всех элементов (foreach)");
                Console.WriteLine("4. Запрос: количество студентов");
                Console.WriteLine("5. Запрос: печать людей старше заданного возраста");
                Console.WriteLine("6. Запрос: печать студентов заданного курса");
                Console.WriteLine("7. Клонирование коллекции");
                Console.WriteLine("8. Сортировка по имени");
                Console.WriteLine("9. Поиск элемента по имени");
                Console.WriteLine("0. Назад");
                choice = Input.ReadInt("Ваш выбор: ");

                switch (choice)
                {
                    case 1: Add(); break;
                    case 2: Remove(); break;
                    case 3: Print(queue); break;
                    case 4: CountStudents(); break;
                    case 5: PrintOlder(); break;
                    case 6: PrintCourse(); break;
                    case 7: CloneQueue(); break;
                    case 8: SortQueue(); break;
                    case 9: Find(); break;
                }
            }
        }

        static void Add()
        {
            Person p = Input.ReadPerson();
            queue.Enqueue(p);
            Console.WriteLine("Элемент добавлен");
        }

        static void Remove()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Очередь пуста");
                return;
            }
            object removed = queue.Dequeue();
            Console.WriteLine("Удалён элемент: " + removed);
        }

        static void Print(Queue q)
        {
            if (q.Count == 0)
            {
                Console.WriteLine("Очередь пуста");
                return;
            }
            foreach (object obj in q)
            {
                Console.WriteLine(obj);
            }
        }

        // запрос 1
        static void CountStudents()
        {
            int count = 0;
            foreach (object obj in queue)
            {
                if (obj is Student)
                    count++;
            }
            Console.WriteLine("Количество студентов: " + count);
        }

        // запрос 2
        static void PrintOlder()
        {
            int age = Input.ReadInt("Введите возраст: ");
            foreach (object obj in queue)
            {
                Person p = (Person)obj;
                if (p.Age > age)
                    Console.WriteLine(p);
            }
        }

        // запрос 3
        static void PrintCourse()
        {
            int course = Input.ReadInt("Введите курс: ");
            int found = 0;
            foreach (object obj in queue)
            {
                if (obj is Student)
                {
                    Student s = (Student)obj;
                    if (s.Course == course)
                    {
                        Console.WriteLine(s);
                        found++;
                    }
                }
            }
            if (found == 0)
                Console.WriteLine("Студентов этого курса нет");
        }

        static void CloneQueue()
        {
            // Clone() копирует очередь, а объекты внутри остаются теми же
            Queue copy = (Queue)queue.Clone();
            Console.WriteLine("Копия очереди (" + copy.Count + " элементов):");
            Print(copy);

            // проверка на разные очереди
            copy.Dequeue();
            Console.WriteLine("После удаления из копии: в оригинале " + queue.Count + ", в копии " + copy.Count);
        }

        static void SortQueue()
        {
            // у Queue нет Sort, поэтому переносим элементы в массив
            object[] arr = queue.ToArray();
            Array.Sort(arr);
            queue.Clear();
            foreach (object obj in arr)
            {
                queue.Enqueue(obj);
            }
            Console.WriteLine("Очередь отсортирована:");
            Print(queue);
        }

        static void Find()
        {
            string name = Input.ReadString("Введите имя: ");
            int index = 0;
            bool found = false;
            foreach (object obj in queue)
            {
                Person p = (Person)obj;
                if (p.Name == name)
                {
                    Console.WriteLine("Найден (позиция " + index + "): " + p);
                    found = true;
                }
                index++;
            }
            if (!found)
                Console.WriteLine("Элемент не найден");
        }
    }
}
