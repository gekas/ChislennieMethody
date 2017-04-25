using System;

namespace ChislennieMethody_Lab1.Methods
{
    class HalfDeviation
    {
        public HalfDeviation(double a, double b, Func<double, double> f)
        {
            Console.WriteLine("\n\n\nМетод деления пополам: ");
            var iterationNumber = Math.Ceiling(Math.Log((3 - 2) / Math.Pow(10, -5), 2) - 1);
            Console.WriteLine($"Итераций: {iterationNumber}");

            PrintTable.PrintRow("n", "an", "xn", "bn", "f(an)", "f(xn)", "f(bn)");

            double x = (a + b) / 2;
            double fa = 0, fx = 0, fb = 0;
            do
            {
                fa = f(a);
                fx = f(x);
                fb = f(b);

                PrintTable.PrintRow(iterationNumber, a, x, b, fa, fx, fb);

                if (fx == 0) break;

                a = SameSign(fa, fx) ? x : a;
                b = SameSign(fb, fx) ? x : b;
                x = (a + b) / 2;

            } while (iterationNumber-- > 0);

            Console.WriteLine($"Х є околу: {x}");
        }

        private bool SameSign(double num1, double num2)
        {
            return num1 >= 0 && num2 >= 0 || num1 < 0 && num2 < 0;
        }
    }
}
