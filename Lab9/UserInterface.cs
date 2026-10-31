using System;

class UserInterface
{
    public static void ShowMessage(string text)
    {
        Console.WriteLine(text);
    }

    // вывод одного элемента массива
    public static void ShowItem(int i, Uravnenie u)
    {
        Console.Write($"[{i}] ");
        u.Print();
    }

    // вывод корней
    public static void ShowRoots(double[] roots)
    {
        if (roots.Length == 0)
        {
            Console.WriteLine("Корней нет");
        }
        else
        {
            for (int i = 0; i < roots.Length; i++)
                Console.WriteLine($"x{i + 1} = {roots[i]}");
        }
    }

    // ввод одного уравнения с клавиатуры
    public static Uravnenie ReadUravnenie(int number)
    {
        Console.WriteLine($"Уравнение {number}:");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());
        return new Uravnenie(a, b, c);
    }
}