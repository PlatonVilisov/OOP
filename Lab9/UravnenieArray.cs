using System;

class UravnenieArray
{
    private Uravnenie[] arr;

    // статическая переменная для подсчёта созданных массивов
    private static int arrayCount = 0;

    // свойство для поля arr
    public Uravnenie[] Arr
    {
        get { return arr; }
        set { arr = value; }
    }

    public int Length
    {
        get { return arr.Length; }
    }

    public static int ArrayCount
    {
        get { return arrayCount; }
    }

    // конструктор без параметров
    public UravnenieArray()
    {
        Arr = new Uravnenie[0];
        arrayCount++;
    }

    // конструктор со случаными значениями
    public UravnenieArray(int n, int min, int max)
    {
        Arr = new Uravnenie[n];
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            double a = rnd.Next(min, max + 1);
            double b = rnd.Next(min, max + 1);
            double c = rnd.Next(min, max + 1);
            Arr[i] = new Uravnenie(a, b, c);
        }
        arrayCount++;
    }

    // конструктор с вводом с клавиатуры
    public UravnenieArray(int n)
    {
        Arr = new Uravnenie[n];
        for (int i = 0; i < n; i++)
        {
            Arr[i] = UserInterface.ReadUravnenie(i + 1);
        }
        arrayCount++;
    }

    // индексатор
    public Uravnenie this[int index]
    {
        get
        {
            if (index < 0 || index >= arr.Length)
                throw new ArgumentException("Индекс выходит за границы массива");
            return arr[index];
        }
        set
        {
            if (index < 0 || index >= arr.Length)
                throw new ArgumentException("Индекс выходит за границы массива");
            arr[index] = value;
        }
    }

    // просмотр элементов
    public void Print()
    {
        if (arr.Length == 0)
        {
            UserInterface.ShowMessage("Массив пуст");
        }
        for (int i = 0; i < arr.Length; i++)
        {
            UserInterface.ShowItem(i, arr[i]);
        }
    }
}