using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChislennieMethody_Lab2
{
    class SquareRoot
    {
        public static double[] method(double[][] a, double[] coeffs)
        {
            int n = a.Length;
            double[][] g = new double[n][];

            for (int i = 0; i < n; i++)
            {
                g[i] = new double[n];
                double accGtoG1 = 0;
                for (int k = 0; k < i; k++)
                {
                    accGtoG1 = accGtoG1 + g[k][i] * g[k][i]; //sums of g[1,i]^2
                }
                g[i][i] = Math.Sqrt(a[i][i] - accGtoG1); //actual g[1,1] - on diagonal

                for (int j = i + 1; j < n; j++)
                {
                    double accGtoG2 = 0;
                    for (int k = 0; k < i; k++)
                    {
                        accGtoG2 = accGtoG2 + g[k][i] * g[k][j];
                    }
                    g[i][j] = (a[i][j] - accGtoG2) / g[i][i]; //actual g[1,2]
                }
            }
            //find
            double[] y = new double[n];
            for (int i = 0; i < n; i++)
            {
                double accGtoY = 0;
                for (int k = 0; k < i; k++)
                {
                    accGtoY = accGtoY + g[k][i] * y[k]; //count vertical elements: g[1,3] g[2,3]
                }
                y[i] = (coeffs[i] - accGtoY) / g[i][i]; //actual y[1]
            }
            //print(g);
            //reverse steps:
            double[] x = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                double accGtoX = 0;
                for (int k = i + 1; k < n; k++)
                {       //for (k = (i + 1); k < n; k++)
                    accGtoX = accGtoX + g[i][k] * x[k];
                }
                x[i] = (y[i] - accGtoX) / g[i][i];
            }
            return x;
        }
    }
}
