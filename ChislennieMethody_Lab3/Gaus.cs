using System;

namespace Lab3
{
    public class Gauss
    {
        public static double[] Calculate(double[][] a, double[] b)
        {
            double[][] matrixA = new double[a.Length][];
            for (int i = 0; i < a.Length; i++)
            {
                matrixA[i] = new double[a[i].Length];
                for (int j = 0; j < a[i].Length; j++)
                {
                    matrixA[i][j] = a[i][j];
                }
            }
            double[] matrixB = (double[])b.Clone();
            int n = matrixA.Length;
            double[] results = new double[n];

            for (int k = 0; k < n; k++)
            {
                double max = Math.Abs(matrixA[k][k]);
               
                int index = k;
                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(matrixA[i][k]) > max)
                    {
                        max = Math.Abs(matrixA[i][k]);
                        index = i;
                    }
                }

                if (max == 0)
                {
                    throw new ArithmeticException("Нулевой столбцец " + index);
                }

                for (int j = 0; j < n; j++)
                {
                    double temp = matrixA[k][j];
                    matrixA[k][j] = matrixA[index][j];
                    matrixA[index][j] = temp;
                } 
                double temp1 = matrixB[k];
                matrixB[k] = matrixB[index];
                matrixB[index] = temp1;

                for (int i = k; i < n; i++)
                {
                    double temp = matrixA[i][k];
                    if (Math.Abs(temp) == 0)
                    {
                        continue;
                    }
                    for (int j = 0; j < n; j++)
                    {
                        matrixA[i][j] = matrixA[i][j] / temp;
                    }
                    matrixB[i] = matrixB[i] / temp;
                    if (i == k)
                    {
                        continue;
                    }
                    for (int j = 0; j < n; j++)
                    {
                        matrixA[i][j] = matrixA[i][j] - matrixA[k][j];
                    }
                    matrixB[i] = matrixB[i] - matrixB[k];
                }
            }

            for (int k = n - 1; k >= 0; k--)
            {
                results[k] = matrixB[k];
                for (int i = 0; i < k; i++)
                {
                    matrixB[i] = matrixB[i] - matrixA[i][k] * results[k];
                }
            }
            return results;

        }
    }
}
