using System;

namespace ChislennieMethody_Lab2
{
    class Holetski
    {
        public static double[] Calculate(double[][] a, double[] coeffs)
        {
            double[][] b = new double[3][];
            double[][] c = new double[3][];
            for (int i = 0; i < b.GetLength(0); i++)
            {
                b[i] = new double[3];
                c[i] = new double[3];
            }

            CreateBC(a, b, c);
            Console.WriteLine("matrix B: ");
            Matrix.Print(b);
            Console.WriteLine("matrix C: ");
            Matrix.Print(c);
            return calculateResults(b, c, coeffs);
        }

        //B*C = A
        private static void CreateBC(double[][] a, double[][] b, double[][] c)
        {
            int n = a.GetLength(0);
            //матрица С должна содержать 1 по главной диагонали
            for (int i = 0; i < n; i++)
            {
                c[i][i] = 1;
            }
            //заполняем матрицы В и С
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        b[j][0] = a[j][0];
                    }
                    //заполняем элементы матрицы С по формуле: с12 = а12/b11. Диаг. элементы не меняем
                    for (int j = 1; j < n; j++)
                    {
                        c[0][j] = a[0][j] / b[0][0];
                    }
                }
                else
                {
                    for (int j = i; j < n; j++)
                    {
                        b[j][i] = a[j][i];
                        for (int k = 0; k < i; k++)
                        {
                            b[j][i] = b[j][i] - b[j][k] * c[k][i];
                        }
                    }
                    for (int j = i; j < n; j++)
                    {
                        c[i][j] = a[i][j];
                        for (int k = 0; k < i; k++)
                        {
                            c[i][j] = c[i][j] - b[i][k] * c[k][j];
                        }
                        c[i][j] = c[i][j] / b[i][i];
                    }
                }
            }
        }

        private static double[] calculateResults(double[][] b, double[][] c, double[] coeffs)
        {
            int n = coeffs.GetLength(0);
            double[] y = new double[n];
            double[][] y1 = new double[n][];
            for (int i=0;i<y1.GetLength(0); i++) { y1[i] = new double[n]; }

            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    y[i] = coeffs[i] / b[i][i];
                }
                else
                {
                    double w = 0;
                    for (int k = 0; k < i; k++)
                    {
                        y1[i][k] = w + b[i][k] * y[k];
                        w = y1[i][k];
                    }
                    y[i] = (coeffs[i] - w) / b[i][i];
                }
            }
            double[] x = new double[n];
            double[][] x1 = new double[n][];
            for (int i = 0; i < x1.GetLength(0); i++) { x1[i] = new double[n]; }

            for (int i = n - 1; i >= 0; i--)
            {
                if (i == n - 1)
                {
                    x[i] = y[i];
                }
                else
                {
                    double q = 0;
                    for (int k = i; k < n; k++)
                    {
                        x1[i][k] = q + c[i][k] * x[k];
                        q = x1[i][k];
                    }
                    x[i] = y[i] - q;
                }
            }
            return x;
        }
    }
}
