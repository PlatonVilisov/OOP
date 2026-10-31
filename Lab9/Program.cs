using System;

class Program
{
    // уравнение с самым большим по модулю корнем
    static int FindMaxRoot(UravnenieArray ua)
    {
        int bestIndex = -1;
        double bestAbs = -1;

        for (int i = 0; i < ua.Length; i++)
        {
            double[] roots = ua[i].GetRoots();   // индексатор
            for (int j = 0; j < roots.Length; j++)
            {
                if (Math.Abs(roots[j]) > bestAbs)
                {
                    bestAbs = Math.Abs(roots[j]);
                    bestIndex = i;
                }
            }
        }
        return bestIndex;
    }

    static void Main()
    {
        Uravnenie u1 = new Uravnenie();
        Uravnenie u2 = new Uravnenie(1, -3, 2);
        Uravnenie u3 = new Uravnenie(1, 2, 5);

        // выводим атрибуты
        u1.Print();
        u2.Print();
        u3.Print();

        // проверяем свойства
        u1.A = 2;
        u1.B = -4;
        u1.C = 2;
        UserInterface.ShowMessage($"u1 после изменения: a={u1.A}, b={u1.B}, c={u1.C}");

        // статическая функция
        UserInterface.ShowMessage("\nСтатическая функция для 1x^2 - 3x + 2:");
        UserInterface.ShowRoots(Uravnenie.StaticSolve(1, -3, 2));

        // метод класса
        UserInterface.ShowMessage("\nМетод класса для u2:");
        UserInterface.ShowRoots(u2.GetRoots());
        UserInterface.ShowMessage("Метод класса для u3:");
        UserInterface.ShowRoots(u3.GetRoots());

        // сколько объектов создано
        UserInterface.ShowMessage($"\nСоздано объектов: {Uravnenie.Count}");

        Uravnenie u4 = new Uravnenie(1, -3, 2); // как u2 по коэффициентам

        // ++ и --
        UserInterface.ShowMessage("\nПроверка ++ и --:");
        u2++;
        u2.Print();
        u2--;
        u2.Print();

        // приведение неявное к double
        double r1 = u2;
        double r2 = u3;
        UserInterface.ShowMessage($"\nu2 -> double: {r1}");
        UserInterface.ShowMessage($"u3 -> double: {r2}");

        // приведение явное к bool
        UserInterface.ShowMessage($"\nu2 есть корни - {(bool)u2}");
        UserInterface.ShowMessage($"u3 есть корни - {(bool)u3}");

        // == и !=
        UserInterface.ShowMessage("\nСравнение:");
        UserInterface.ShowMessage($"u2 == u4 -  {u2 == u4}");
        UserInterface.ShowMessage($"u2 != u3 - {u2 != u3}");
        UserInterface.ShowMessage($"u2 == u3 - {u2 == u3}");

        // массив без параметров
        UserInterface.ShowMessage("\nМассив 1 (без параметров):");
        UravnenieArray arr1 = new UravnenieArray();
        arr1.Print();

        // массив со случайными значениями
        UserInterface.ShowMessage("\nМассив 2 (случайные значения):");
        UravnenieArray arr2 = new UravnenieArray(4, -5, 5);
        arr2.Print();

        // массив с вводом с клавиатуры
        UserInterface.ShowMessage("\nМассив 3 (ввод с клавиатуры), введите 2 уравнения:");
        UravnenieArray arr3 = new UravnenieArray(2);
        UserInterface.ShowMessage("Массив 3:");
        arr3.Print();

        // проверка индексатора
        UserInterface.ShowMessage("\nПроверка индексатора:");
        arr2[1].Print();
        try
        {
            arr2[10].Print();
        }
        catch (ArgumentException e)
        {
            UserInterface.ShowMessage("Ошибка: " + e.Message);
        }

        // задание варианта
        UserInterface.ShowMessage("\nУравнение с наибольшим по модулю корнем в массиве 2:");
        int index = FindMaxRoot(arr2);
        if (index == -1)
        {
            UserInterface.ShowMessage("Ни у одного уравнения нет корней");
        }
        else
        {
            arr2[index].Print();
            UserInterface.ShowRoots(arr2[index].GetRoots());
        }

        UserInterface.ShowMessage($"\nСоздано уравнений: {Uravnenie.Count}");
        UserInterface.ShowMessage($"Создано массивов: {UravnenieArray.ArrayCount}");
    }
}