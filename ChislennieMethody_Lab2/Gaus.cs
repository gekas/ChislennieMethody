using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChislennieMethody_Lab2
{
    class Gaus
    {
        public static double[] Calculate(double[,] matrix)
        {
            int n = matrix.Rank + 1;
            //выводим массив
            Console.WriteLine("Матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

            //Метод Гаусса
            //Прямой ход, приведение к верхнетреугольному виду
            double tmp;
            double[] xx = new double[4];

            for (int i = 0; i < n; i++)
            {
                tmp = matrix[i, i];
                for (int j = n; j >= i; j--)
                    matrix[i, j] /= tmp;
                for (int j = i + 1; j < n; j++)
                {
                    tmp = matrix[j, i];
                    for (int k = n; k >= i; k--)
                        matrix[j, k] -= tmp * matrix[i, k];
                }
            }

            /*обратный ход*/
            xx[n - 1] = matrix[n - 1, n];
            for (int i = n - 2; i >= 0; i--)
            {
                xx[i] = matrix[i, n];
                for (int j = i + 1; j < n; j++) xx[i] -= matrix[i, j] * xx[j];
            }

            return xx;
        }
    }
}
