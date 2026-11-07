using System;
using System.Collections.Generic;
namespace PlacesLib
{
    public static class PlaceQueries
    {
        // Запрос 1: названия всех городов заданной области (оператор as).
        // Мегаполис тоже город, поэтому он попадёт в результат.
        public static List<string> CityNamesInRegion(Place[] arr, string region)
        {
            List<string> result = new List<string>();
            foreach (Place p in arr)
            {
                City c = p as City; // null, если p не City и не его потомок
                if (c != null && c.RegionName == region)
                    result.Add(c.Name);
            }
            return result;
        }
        // Запрос 2: суммарное количество жителей всех городов области (оператор is).
        public static long TotalPopulation(Place[] arr, string region)
        {
            long sum = 0;
            foreach (Place p in arr)
                if (p is City && ((City)p).RegionName == region)
                    sum += ((City)p).Population;
            return sum;
        }
        // Запрос 3а: количество мегаполисов (is).
        public static int CountMegapolises(Place[] arr)
        {
            int n = 0;
            foreach (Place p in arr)
                if (p is Megapolis) n++;
            return n;
        }
        // Запрос 3б: количество «обычных» городов, не мегаполисов (typeof).
        public static int CountPlainCities(Place[] arr)
        {
            int n = 0;
            foreach (Place p in arr)
                if (p.GetType() == typeof(City)) n++;
            return n;
        }
        // Запрос 4: количество адресов в заданном населённом пункте (is).
        public static int CountAddresses(Place[] arr, string city)
        {
            int n = 0;
            foreach (Place p in arr)
                if (p is Address && p.Name == city) n++;
            return n;
        }
    }
}