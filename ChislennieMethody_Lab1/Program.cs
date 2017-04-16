using ChislennieMethody_Lab1.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChislennieMethody_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            HalfDeviation method = new HalfDeviation(2, 3, (x) => { return x * x * x - 3 * x * x + 4 * x - 5; });
            SimpleIteration method1 = new SimpleIteration(2, 3, 0.00001, (x) => { return x * x * x - 3 * x * x + 4 * x - 5; }, (x) => { return 3 * x * x - 6 * x + 4; });
            Chords method2 = new Chords(2, 3, 0.00001, (x) => { return x * x * x - 3 * x * x + 4 * x - 5; }, (x) => { return 3 * x * x - 6 * x + 4; }, (x) => { return 6 * x - 6; });
            Newton method3 = new Newton(2, 3, 0.00001, (x) => { return x * x * x - 3 * x * x + 4 * x - 5; }, (x) => { return 3 * x * x - 6 * x + 4; }, (x) => { return 6 * x - 6; });

            Console.ReadLine();
        }
    }
}
