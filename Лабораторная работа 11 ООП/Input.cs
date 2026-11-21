using System;

namespace Lab11
{
    // методы для ввода с клавиатуры
    static class Input
    {
        public static int ReadInt(string text)
        {
            int x;
            Console.Write(text);
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Ошибка! Введите целое число: ");
            }
            return x;
        }

        public static string ReadString(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

        // Вводится Person или Student
        public static Person ReadPerson()
        {
            int type = ReadInt("Что добавить? 1 - Person, 2 - Student: ");
            string name = ReadString("Имя: ");
            int age = ReadInt("Возраст: ");

            if (type == 2)
            {
                int course = ReadInt("Курс: ");
                string group = ReadString("Группа: ");
                return new Student(name, age, course, group);
            }
            return new Person(name, age);
        }
    }
}
