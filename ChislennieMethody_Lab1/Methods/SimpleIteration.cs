using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChislennieMethody_Lab1.Methods
{
    class SimpleIteration
    {
        /// <summary>
        /// Метод простой итерации
        /// </summary>
        /// <param name="a">Левая граница</param>
        /// <param name="b">Правая граница</param>
        /// <param name="f">Функция</param>
        /// <param name="f1">Первая производная</param>
        public SimpleIteration(double a, double b, double eps, Func<double, Double> f, Func<double, double> f1)
        {
            Console.WriteLine("\n\n\nМетод простой итерации");
            // Переходим от заданого уравнения к уравнению удобному для итерирования: x = x - alpha*f(x)
            var M1 = Math.Max(f1(a), f1(b));
            var m1 = Math.Min(f1(a), f1(b));

            if(f1(a) > f1(b))
            {
                M1 = f1(a);
                m1 = f1(b);
                Console.WriteLine($"M1 = f({a}) = {f1(a)}");
                Console.WriteLine($"m1 = f({b}) = {f1(b)}");
            }
            else
            {
                M1 = f1(b);
                m1 = f1(a);
                Console.WriteLine($"M1 = f({b}) = {f1(b)}");
                Console.WriteLine($"m1 = f({a}) = {f1(a)}");
            }

            var alpha = 2 / (M1 + m1);
            Console.WriteLine($"Alpha = {alpha}");

            double x = a;
            double stopValue = Math.Abs(f(x)) / m1;
            int i = 0;

            PrintTable.PrintRow("n", "x", "|f(xn)|/m1", "epsilon", "Stop");
            while (stopValue > eps)
            {
                PrintTable.PrintRow(i,x, Math.Abs(f(x)) / m1, eps, stopValue < eps);
                x = x - alpha * f(x);
                stopValue = Math.Abs(f(x)) / m1;

                i++;
            }

            PrintTable.PrintRow(i, x, Math.Abs(f(x)) / m1, eps, stopValue < eps);

            Console.WriteLine($"Х є околу: {x}");
        }
    }
}
