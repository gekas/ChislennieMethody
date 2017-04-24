using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChislennieMethody_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            double y;
            y = integralpram(0, 1, 10, (x)=>(9*x*x*x / Math.Sqrt(1+3*x*x)));

            Console.ReadLine();
        }

        static double integralpram(double a, double b, int n, Func<double, double> f)
        {
            double h, S, x;
            int i;
            h = (b - a) / n;
            S = 0;
            for (i = 0; i <= n; i++)
            {
                x = a + i * h;
                S = S + f(x);
            }
            S = h * S;
            return S;
        }
    }
}
