using System;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

class Uravnenie
{
    private double a;
    private double b;
    private double c;

    // статическая переменная для подсчёта объектов
    private static int ObjectCount = 0;

    // свойства
    public double A
    {
        get { return a; }
        set { a = value; }
    }

    public double B
    {
        get { return b; }
        set { b = value; }
    }

    public double C
    {
        get { return c; }
        set { c = value; }
    }

    // свойство для чтения счётчика
    public static int Count
    {
        get { return ObjectCount; }
    }

    // конструкторы (поля заполняются через свойства)
    public Uravnenie() : this(1, 0, 0)
    {
    }

    public Uravnenie(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
        ObjectCount++;
    }

    // вывод атрибутов
    public void Print()
    {
        UserInterface.ShowMessage($"Уравнение: {a}*x^2 + {b}x + {c} = 0");
    }

    // статическая функция
    public static double[] StaticSolve(double a, double b, double c)
    {
        if (a == 0)
        {
            if (b == 0)
            {
                return new double[0];
            }
            return new double[] { -c / b };
        }

        double d = b * b - 4 * a * c; // дискриминант

        if (d < 0)
        {
            return new double[0];
        }
        if (d == 0)
        {
            return new double[] { -b / (2 * a) };
        }

        double sqrtD = Math.Sqrt(d);
        double x1 = (-b + sqrtD) / (2 * a);
        double x2 = (-b - sqrtD) / (2 * a);
        return new double[] { x1, x2 };
    }

    // метод класса
    public double[] GetRoots()
    {
        return StaticSolve(a, b, c);
    }

    // Унарные операции

    // увеличивает коэффициенты на 1
    public static Uravnenie operator ++(Uravnenie u)
    {
        return new Uravnenie(u.a + 1, u.b + 1, u.c + 1);
    }

    // уменьшает коэффы на 1
    public static Uravnenie operator --(Uravnenie u)
    {
        return new Uravnenie(u.a - 1, u.b - 1, u.c - 1);
    }

    // Приведение типов

    // неявное
    public static implicit operator double(Uravnenie u)
    {
        double[] roots = u.GetRoots();
        if (roots.Length == 0)
            return 0;
        return roots[0];
    }

    // явное
    public static explicit operator bool(Uravnenie u)
    {
        return u.GetRoots().Length > 0;
    }

    // Бинарные операции

    public static bool operator ==(Uravnenie t1, Uravnenie t2)
    {
        return t1.a == t2.a && t1.b == t2.b && t1.c == t2.c;
    }

    public static bool operator !=(Uravnenie t1, Uravnenie t2)
    {
        return !(t1 == t2);
    }
}