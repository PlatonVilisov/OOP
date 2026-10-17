using System;
using System.Text.RegularExpressions;

namespace Lab5
{
    class Program
    {
        // Ввод целого числа с проверкой, оно должно быть не меньше 1
        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    if (number < 1)
                    {
                        Console.WriteLine("Ошибка: число должно быть не меньше 1");
                    }
                    else
                    {
                        return number;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите целое число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Слишком большое число!");
                }
            }
        }

        // Вывод меню, пункты передаются через params
        static int ShowMenu(params string[] items)
        {
            Console.WriteLine();
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
            return ReadInt("Ваш выбор: ");
        }

        // Вывод двумерного и рваного массивов
        static void Print(int[,] a)
        {
            if (a == null)
            {
                Console.WriteLine("Массив пуст");
                return;
            }
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0,5}", a[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Print(int[][] a)
        {
            if (a == null || a.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return;
            }
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write("{0,5}", a[i][j]);
                }
                Console.WriteLine();
            }
        }

        // Создание двумерного массива (вручную или случайно)
        static int[,] CreateMatrix(bool manual, Random rnd)
        {
            int rows = ReadInt("Количество строк: ");
            int cols = ReadInt("Количество столбцов: ");
            int[,] a = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (manual)
                    {
                        a[i, j] = ReadInt("Элемент [" + i + "," + j + "]: ");
                    }
                    else
                    {
                        a[i, j] = rnd.Next(1, 100);
                    }
                }
            }
            return a;
        }

        // Добавление столбца в начало. ref, потому что массив заменяется новым
        static void AddColumn(ref int[,] a)
        {
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);
            int[,] b = new int[rows, cols + 1];
            Console.WriteLine("Введите значения нового столбца:");
            for (int i = 0; i < rows; i++)
            {
                b[i, 0] = ReadInt("Строка " + (i + 1) + ": ");
                for (int j = 0; j < cols; j++)
                {
                    b[i, j + 1] = a[i, j];
                }
            }
            a = b;
        }

        // Создание рваного массива (вручную или случайно)
        static int[][] CreateJagged(bool manual, Random rnd)
        {
            int rows = ReadInt("Количество строк: ");
            int[][] a = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int len;
                if (manual)
                {
                    len = ReadInt("Длина строки " + (i + 1) + ": ");
                }
                else
                {
                    len = rnd.Next(1, 8);
                }
                a[i] = new int[len];
                for (int j = 0; j < len; j++)
                {
                    if (manual)
                    {
                        a[i][j] = ReadInt("Элемент [" + i + "][" + j + "]: ");
                    }
                    else
                    {
                        a[i][j] = rnd.Next(1, 100);
                    }
                }
            }
            return a;
        }

        // Удаление строк с k1 по k2, нумерация идет с 1
        static void DeleteRows(ref int[][] a)
        {
            Console.WriteLine("Всего строк: " + a.Length);
            int k1 = ReadInt("Введите K1: ");
            int k2 = ReadInt("Введите K2: ");
            if (k1 > k2)
            {
                Console.WriteLine("Ошибка: K1 больше, чем K2");
                return;
            }
            if (k2 > a.Length)
            {
                Console.WriteLine("Ошибка: в массиве только " + a.Length + " строк");
                return;
            }
            int[][] b = new int[a.Length - (k2 - k1 + 1)][];
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i < k1 - 1 || i > k2 - 1)
                {
                    b[index] = a[i];
                    index++;
                }
            }
            a = b;
        }

        // Поиск ключевых слов C# и их подсчет
        static void FindKeywords(string text, string[] keywords)
        {
            bool found = false;
            foreach (string word in keywords)
            {
                // b - граница слова, чтобы int не находился внутри info
                int count = Regex.Matches(text, @"\b" + word + @"\b").Count;
                if (count > 0)
                {
                    Console.WriteLine(word + " - " + count);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Ключевых слов нет");
            }
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Random rnd = new Random();
            int[,] matrix = null;
            int[][] jag = null;
            string text = "";

            string[] tests =
            {
                "static void PrintUpper string info12346: WriteLine ToUpper info, 1234info. if x>0 then sign=1; else if x<0 sign=-1; else sign=0.",
                "Hello, World!",
                "if x > 0 return 1 ; else return 0;",
                "Текст без ключевых слов"
            };

            string[] keywords =
            {
                "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue",
                "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally",
                "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long",
                "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public",
                "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch",
                "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void",
                "volatile", "while"
            };

            int choice = 0;
            while (choice != 4)
            {
                choice = ShowMenu("1. Двумерный массив", "2. Рваный массив", "3. Строка", "4. Завершить работу");
                switch (choice)
                {
                    case 1:
                        {
                            int sub = 0;
                            while (sub != 5)
                            {
                                sub = ShowMenu("1. Создать вручную", "2. Создать с рандомными значениями", "3. Вывести массив",
                                               "4. Добавить столбец в начало", "5. Назад");
                                switch (sub)
                                {
                                    case 1:
                                    case 2:
                                        {
                                            matrix = CreateMatrix(sub == 1, rnd);
                                            Print(matrix);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Print(matrix);
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (matrix == null)
                                            {
                                                Console.WriteLine("Ошибка: массив пуст");
                                            }
                                            else
                                            {
                                                AddColumn(ref matrix);
                                                Print(matrix);
                                            }
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            int sub = 0;
                            while (sub != 5)
                            {
                                sub = ShowMenu("1. Создать вручную", "2. Создать случайно", "3. Вывести массив",
                                               "4. Удалить строки с K1 по K2", "5. Назад");
                                switch (sub)
                                {
                                    case 1:
                                    case 2:
                                        {
                                            jag = CreateJagged(sub == 1, rnd);
                                            Print(jag);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Print(jag);
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (jag == null || jag.Length == 0)
                                            {
                                                Console.WriteLine("Ошибка: массив пуст");
                                            }
                                            else
                                            {
                                                DeleteRows(ref jag);
                                                Print(jag);
                                            }
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            int sub = 0;
                            while (sub != 5)
                            {
                                sub = ShowMenu("1. Ввести с клавиатуры", "2. Взять из тестового массива", "3. Вывести строку",
                                               "4. Найти ключевые слова C#", "5. Назад");
                                switch (sub)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Введите строку:");
                                            text = Console.ReadLine();
                                            break;
                                        }
                                    case 2:
                                        {
                                            text = tests[0];
                                            Console.WriteLine("Выбрана строка: " + text);
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (string.IsNullOrEmpty(text))
                                            {
                                                Console.WriteLine("Строка пуста");
                                            }
                                            else
                                            {
                                                Console.WriteLine(text);
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (string.IsNullOrEmpty(text))
                                            {
                                                Console.WriteLine("Строка пуста");
                                            }
                                            else
                                            {
                                                FindKeywords(text, keywords);
                                            }
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                }
            }
        }
    }
}
