using System;
using System.Text;

namespace Lab1
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Задача 1
            Console.WriteLine("Задача 1, выражения 1-3");
            Console.Write("n?");
            var n = int.Parse(Console.ReadLine());
            Console.Write("m?");
            var m = int.Parse(Console.ReadLine());
            var startN = n;
            var startM = m;

            var difference = m - ++n;
            Console.WriteLine("m-++n={0}, m={1}, n={2}", difference, m, n);

            m = startM;
            n = startN;
            var isGreater = m++ > --n;
            Console.WriteLine("m++>--n={0}, m={1}, n={2}", isGreater, m, n);

            m = startM;
            n = startN;
            var isLess = m-- < ++n;
            Console.WriteLine("m--<++n={0}, m={1}, n={2}", isLess, m, n);

            // Задача 1, выражение 4
            Console.WriteLine();
            Console.WriteLine("Задача 1, выражение 4");
            Console.Write("x?");
            var x = double.Parse(Console.ReadLine());
            var radicand = x * x + x;
            if (radicand < 0)
            {
                Console.WriteLine("Нельзя вычислить");
            }
            else
            {
                var y = 25 * Math.Pow(x, 5) - Math.Sqrt(radicand);
                Console.WriteLine("x={0}, y={1}", x, y);
            }

            // Задача 2
            Console.WriteLine();
            Console.WriteLine("Задача 2");
            Console.Write("x1?");
            var x1 = double.Parse(Console.ReadLine());
            Console.Write("y1?");
            var y1 = double.Parse(Console.ReadLine());
            var isInsideCircle = x1 * x1 + y1 * y1 <= 1;
            var isBelowAxis = y1 <= 0;
            var isInArea = isInsideCircle && isBelowAxis;
            Console.WriteLine("Точка ({0}; {1}) в области: {2}", x1, y1, isInArea);

            // Задача 3
            Console.WriteLine();
            Console.WriteLine("Задача 3");

            // вариант с float
            var floatA = 1000f;
            var floatB = 0.0001f;
            var floatDifferenceCube = (float)Math.Pow(floatA - floatB, 3);
            var floatSumPart = (float)Math.Pow(floatA, 3) + 3 * floatA * (float)Math.Pow(floatB, 2);
            var floatNumerator = floatDifferenceCube - floatSumPart;
            var floatDenominator = -3 * (float)Math.Pow(floatA, 2) * floatB - (float)Math.Pow(floatB, 3);
            var floatResult = floatNumerator / floatDenominator;
            Console.WriteLine("float: числитель={0}, знаменатель={1}", floatNumerator, floatDenominator);
            Console.WriteLine("float:  {0}", floatResult);

            // вариант с double
            var doubleA = 1000.0;
            var doubleB = 0.0001;
            var doubleDifferenceCube = Math.Pow(doubleA - doubleB, 3);
            var doubleSumPart = Math.Pow(doubleA, 3) + 3 * doubleA * Math.Pow(doubleB, 2);
            var doubleNumerator = doubleDifferenceCube - doubleSumPart;
            var doubleDenominator = -3 * Math.Pow(doubleA, 2) * doubleB - Math.Pow(doubleB, 3);
            var doubleResult = doubleNumerator / doubleDenominator;
            Console.WriteLine("double: числитель={0}, знаменатель={1}", doubleNumerator, doubleDenominator);
            Console.WriteLine("double: {0}", doubleResult);
            Console.WriteLine("Точное значение: 1");
        }
    }
}
