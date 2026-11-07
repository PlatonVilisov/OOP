using PlacesLib;
using System;
using System.Collections;
class Program
{
    static Place CreateRandom(int kind)
    {
        Place p;
        switch (kind)
        {
            case 0: p = new Place(); break;
            case 1: p = new Region(); break;
            case 2: p = new City(); break;
            case 3: p = new Megapolis(); break;
            default: p = new Address(); break;
        }
        p.RandomInit();
        return p;
    }
    static Place[] CreateArray(int count)
    {
        Place[] arr = new Place[count];
        for (int i = 0; i < count; i++)
            arr[i] = CreateRandom(i % 5); // все пять типов по кругу
        return arr;
    }
    static void Part1(Place[] arr)
    {
        Console.WriteLine("Часть 1: виртуальный Show()");
        foreach (Place p in arr) p.Show();
        Console.WriteLine("\nТот же массив, невиртуальный ShowNonVirtual()");
        foreach (Place p in arr) p.ShowNonVirtual();
        Console.WriteLine("\nРазница на одном объекте");
        City city = new City("Березники", 140000, "Пермский край");
        Place asPlace = city; // один объект, ссылка типа Place
        asPlace.Show(); // вызовется City.Show — по типу объекта
        asPlace.ShowNonVirtual(); // вызовется Place.ShowNonVirtual — по типу ссылки
        city.ShowNonVirtual(); // City.ShowNonVirtual — ссылка типа City
    }
    static void Part2(Place[] arr)
    {
        Console.WriteLine("\nЧасть 2: запросы (is/as/typeof)");
        Console.Write("Типы объектов в массиве: ");
        foreach (Place p in arr) Console.Write(p.GetType().Name + " ");
        Console.WriteLine();
        for (int i = 0; i < Place.RegionNames.Length; i++)Console.WriteLine((i + 1) + " - " + Place.RegionNames[i]);
        Console.Write("Выберите область (номер): ");
        int k;
        while (!int.TryParse(Console.ReadLine(), out k) || k < 1 || k > Place.RegionNames.Length)
            Console.Write("Введите номер из списка: ");
        string region = Place.RegionNames[k - 1];
        List<string> names = PlaceQueries.CityNamesInRegion(arr, region);
        Console.WriteLine("1) Города области " + region + ": " + (names.Count == 0 ? "нет" : string.Join(", ", names)));
        Console.WriteLine("2) Жителей во всех городах области: " + PlaceQueries.TotalPopulation(arr, region));
        Console.WriteLine("3) Мегаполисов: " + PlaceQueries.CountMegapolises(arr) + ", обычных городов: " + PlaceQueries.CountPlainCities(arr));
        Console.WriteLine("Города: " + string.Join(", ", Place.CityNames));
        Console.Write("Введите город для запроса 4: ");
        string city = Console.ReadLine();
        Console.WriteLine("4) Адресов в городе " + city + ": " + PlaceQueries.CountAddresses(arr, city));
    }
    static void ShowAll(string title, Place[] a)
    {
        Console.WriteLine("--- " + title);
        foreach (Place p in a) p.Show();
    }
    // собственный бинарный поиск по названию (массив отсортирован по названию)
    static int BinarySearchByName(Place[] a, string name)
    {
        int lo = 0, hi = a.Length - 1;
        while (lo <= hi)
        {
            int mid = (lo + hi) / 2;
            int c = string.Compare(a[mid].Name, name, StringComparison.CurrentCulture);
            if (c == 0) return mid;
            if (c < 0) lo = mid + 1;
            else hi = mid - 1;
        }
        return -1;
    }
    static void Part3(Place[] arr)
    {
        Console.WriteLine("\nЧасть 3: интерфейсы");
        // 1 IComparable сортировка по названию
        Place[] byName = (Place[])arr.Clone(); // копия массива, сами объекты общие
        Array.Sort(byName);
        ShowAll("Сортировка по названию (IComparable)", byName);
        // 2 IComparer: сортировка по длине названия
        Place[] byLength = (Place[])arr.Clone();
        Array.Sort(byLength, new NameLengthComparer());
        ShowAll("Сортировка по длине названия (IComparer)", byLength);
        // 3 Поиск и бинарный поиск
        Console.WriteLine("Названия: " + string.Join(", ", Place.CityNames));
        Console.Write("Название для поиска: ");
        string key = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(key)) key = byName[0].Name;
        Place keyObj = new Place(key);
        int i1 = Array.BinarySearch(byName, keyObj); // IComparable
        int i2 = BinarySearchByName(byName, key); // свой метод
        int i3 = Array.BinarySearch(byLength, keyObj, new NameLengthComparer()); // IComparer
        Console.WriteLine("Array.BinarySearch (IComparable): " + (i1 >= 0 ? "индекс " + i1 : "не найдено"));
        Console.WriteLine("Свой бинарный поиск: " + (i2 >= 0 ? "индекс " + i2 : "не найдено"));
        Console.WriteLine("Array.BinarySearch (IComparer): " + (i3 >= 0 ? "индекс " + i3 : "не найдено"));
        // 4 Массив IInit: классы иерархии и посторонний класс
        Console.WriteLine("\n--- Массив IInit ---");
        IInit[] items =
        { new Place(), new Region(), new City(), new Megapolis(), new Address(), new Sight() };
        foreach (IInit x in items)
        {
            x.RandomInit();
            if (x is Place) ((Place)x).Show();
            else if (x is Sight) ((Sight)x).Show();
        }
        Console.WriteLine("Ручной ввод Init() для Sight:");
        items[5].Init();
        ((Sight)items[5]).Show();
        // 5 Клонирование и поверхностное копирование
        Console.WriteLine("\n--- Clone() и ShallowCopy() ---");
        Megapolis m = new Megapolis("Москва", 12000000, "Московская область",
        15, new int[] { 100, 200, 300 });
        Megapolis same = m; // копия ссылки
        Megapolis shallow = (Megapolis)m.ShallowCopy(); // MemberwiseClone: массив общий
        Megapolis deep = (Megapolis)m.Clone(); // новый объект и новый массив
        m.DistrictAreas[0] = 9999; // меняем элемент массива у исходного объекта
        m.Name = "Изменённая"; // меняем название у исходного объекта
        Console.Write("original: "); m.Show();
        Console.Write("same: "); same.Show();
        Console.Write("shallow: "); shallow.Show();
        Console.Write("deep: "); deep.Show();
    }
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Place[] arr = CreateArray(20);
        Part1(arr);
        Part2(arr);
        Part3(arr);
    }
}