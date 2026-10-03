using System;
namespace Lab3
{
    public class Program
    {
        public static void Main()
        {
            var lowerBound = 0.1;
            var upperBound = 1.0;
            var k = 9;
            var n = 25;
            var eps = 0.0001;
            var step = (upperBound - lowerBound) / k;

            Console.WriteLine("Вычисление функции");
            for (var i = 0; i <= k; i++)
            {
                var x = lowerBound + i * step;
                // Сумма ряда для заданного n
                var sn = GetSumByN(x, n);
                // Сумма ряда с заданной точностью
                var se = GetSumByEps(x, eps);
                // Точное значение функции
                var y = GetExactValue(x);
                Console.WriteLine($"X={x:F2}  SN={sn:F6}  SE={se:F6}  Y={y:F6}");
            }

            Console.WriteLine();
            Console.WriteLine($"n = {n}");
            Console.WriteLine($"eps = {eps}");
            Console.WriteLine($"Шаг = {step}");
        }

        // Вычисление первого множителя n-го члена ряда
        private static double GetPhi(int index)
        {
            return Math.Cos(index * Math.PI / 4);
        }

        // Сумма ряда для заданного n
        private static double GetSumByN(double x, int n)
        {
            var sum = 0.0;
            var c = 1.0;
            for (var i = 0; i <= n; i++)
            {
                // Вычисление n-го члена ряда и добавление его к сумме
                sum = sum + GetPhi(i) * c;
                c = c * x / (i + 1);
            }
            return sum;
        }

        // Сумма ряда с заданной точностью eps
        private static double GetSumByEps(double x, double eps)
        {
            var sum = 0.0;
            var c = 1.0;
            var i = 0;
            while (c >= eps)
            {
                // Вычисление n-го члена ряда и добавление его к сумме
                sum = sum + GetPhi(i) * c;
                i++;
                c = c * x / i;
            }
            return sum;
        }

        // Точное значение функции
        private static double GetExactValue(double x)
        {
            return Math.Exp(x * Math.Cos(Math.PI / 4)) * Math.Cos(x * Math.Sin(Math.PI / 4));
        }
    }
}
