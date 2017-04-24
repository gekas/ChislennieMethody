using ChislennieMethody_Lab1.Methods;
using System;

namespace ChislennieMethody_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> f = (x) => { return x * x * x - 1.3 * x * x + x - 1; };
            Func<double, double> f1 = (x) => { return 3 * x * x - 2.6 * x + 1; };
            Func<double, double> f2 = (x) => { return 6 * x - 2.6; };

            //Func<double, double> f = (x) => { return x * x * x - 3 * x * x + 4 * x - 5; };
            //Func<double, double> f1 = (x) => { return 3 * x * x - 6 * x + 4; };
            //Func<double, double> f2 = (x) => { return 6 * x - 6; };

            HalfDeviation method = new HalfDeviation(2, 3, f);
            SimpleIteration method1 = new SimpleIteration(2, 3, 0.00001, f, f1);
            Chords method2 = new Chords(2, 3, 0.00001, f, f1, f2);
            Newton method3 = new Newton(2, 3, 0.00001, f, f1, f2);

            Console.ReadLine();
        }
    }
}
