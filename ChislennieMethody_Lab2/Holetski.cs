using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChislennieMethody_Lab2
{
    class Holetski
    {
        public Holetski()
        {
            int n = 3;
            double[,] a = { { 3,2,1,5},
                                 { 2,3,1,1},
                                 { 2,1,3,11}
                               };

            for (int k = 0; k < n; ++k)
            {
                a[k, k] = Math.Sqrt(a[k, k]);
                for (int i = k + 1; i < n; ++i)
                {
                    a[i, k] = a[i, k] / a[k, k];
                }
                Console.WriteLine($"{k}\n");
                for (int j = k + 1; j < n; ++j)
                {
                    for (int i = j; i < n; ++i)
                        a[i, j] = a[i, j] - a[i, k] * a[j, k];
                }
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
