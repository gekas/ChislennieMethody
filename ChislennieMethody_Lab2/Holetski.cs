using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChislennieMethody_Lab2
{
    class Holetski
    {
        public Holetski(double[,] a)
        {
            var n = a.GetLength(0);
            double[,] b = new double[n,n];
            double[,] c = new double[n,n];

            for (int i = 0; i < n; i++) b[i, 0] = a[i, 0];
            for (int i = 0; i < n; i++)
            {
                c[0, i] = a[0, i] / b[0, 0];
                c[i, i] = 1;
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 1; j <= i; ++j)
                {
                    double sum = 0;
                    for (int k = 0; k <= i - 1; k++)
                        sum += b[i, k] * c[k, j];

                    b[i, j] = a[i, j] - sum;
                }

                for (int j = n-1; j >= i; j--)
                {
                    if (i == j) continue;
                    double sum = 0;
                    for(int k = 0; k < i -1; k++)
                    {
                        sum += b[i, k] * c[k, j];
                    }

                    c[i, j] = (a[i, j] - sum) / b[i, i];
                }
            }

            var asas = 5;
        }
    }
}
