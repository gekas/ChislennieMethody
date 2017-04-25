using System;

namespace ChislennieMethody_Lab1.Methods
{
    class Chords
    {
        public Chords(double a, double b, double eps, Func<double, Double> f, Func<double, double> f1, Func<double, double> f2)
        {
            Console.WriteLine("\n\n\nМетод хорд");
            Console.WriteLine($"f'({a}) = {f1(a)}");
            Console.WriteLine($"f'({b}) = {f1(b)}");
            var M1 = Math.Max(f1(a), f1(b));
            var m1 = Math.Min(f1(a), f1(b));

            Console.WriteLine($"M1 = {M1}");
            Console.WriteLine($"m1 = {m1}");

            var gamma = m1 * eps / (M1 - m1);
            Console.WriteLine($"Gamma = {gamma}");

            var x = a;

           // while (f(x) * f2(x) >= 0)
           // {
                x = x + eps;
           // }

            PrintTable.PrintRow("n", "Xn", "|Xn-X(n-1)|", "|Xn-X(n-1)| < gamma");
            PrintTable.PrintRow(0, x, "-", "-");

            double prevX;
            int i = 1;
            do
            {
                prevX = x;
                x = prevX - f(prevX) * (3 - prevX) / (f(3) - f(prevX));
                PrintTable.PrintRow(i, x, Math.Abs(x - prevX), Math.Abs(x - prevX) < gamma);

                i++;
            } while (Math.Abs(x - prevX) >= gamma);

            Console.WriteLine($"Х є околу: {x}");
        }
    }
}
