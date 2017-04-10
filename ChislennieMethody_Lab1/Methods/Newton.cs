using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChislennieMethody_Lab1.Methods
{
    class Newton
    {
        public Newton(double a, double b, double eps, Func<double, Double> f, Func<double, double> f1, Func<double, double> f2)
        {
            Console.WriteLine("Метод Ньютона");
            Console.WriteLine($"f'({a}) = {f1(a)}");
            Console.WriteLine($"f'({b}) = {f1(b)}");

            double m1 = Math.Min(f1(a), f1(b));
            Console.WriteLine($"m1 = min{{f'({a}); f'({b})}} = {m1}");
            Console.WriteLine();
            Console.WriteLine($"f''({a}) = {f2(a)}");
            Console.WriteLine($"f''({b}) = {f2(b)}");
            
            double M2 = Math.Max(f2(a), f2(b));
            Console.WriteLine($"M1 = max{{f''({a}); f''({b})}} = {M2}");

            double delta = Math.Sqrt(2 * m1 * eps / M2);
            Console.WriteLine($"Delta = {delta}");

            var x = a;

            if (f(x) * f2(x) <= 0) x = b;

            while (f(x) * f2(x) <= 0)
            {
                x -= eps;
            }

            PrintTable.PrintRow("n", "Xn", "|Xn-X(n-1)|", "|Xn-X(n-1)| < delta");
            PrintTable.PrintRow(0, x, "-", "-");

            double xPrev;
            var i = 1;
            do
            {
                xPrev = x;
                x = xPrev - f(x) / f1(x);

                PrintTable.PrintRow(i, x, Math.Abs(x - xPrev), Math.Abs(x - xPrev) < delta);
                i++;
            } while (Math.Abs(x - xPrev) >= delta);

            Console.WriteLine($"Х є околу: {x}");
        }
    }
}
