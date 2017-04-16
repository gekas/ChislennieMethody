using System;

namespace ChislennieMethody_Lab2
{
    public static class Matrix
    {
        public static double[][] Multiplication(double[][] a, double[][] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Количество столбцов первой матрицы должно совпадать с количеством строк второй");

            double[][] r = new double[a.GetLength(0)][];
            for(int i = 0; i < a.GetLength(0); i++)
            {
                a[i] = new double[b.GetLength(1)];
            }

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i][j] += a[i][k] * b[k][j];
                    }
                }
            }

            return r;
        }

        public static void Print(double[][] m)
        {
            for(int i = 0; i < m.GetLength(0); i++)
            {
                for(int j = 0; j < m[i].Length; j++)
                {
                    Console.Write(m[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
