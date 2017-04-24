using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class LessSquares
    {
        //m is maximum Pow of resulting equation.
        public static double[] Calc(double[] x, double[] y, double[] xz, int m)
        {
            int rowsInSystem = x.Length - 1; //actual amount of rows in the system.
            int amountOfC = m * 2 + 1; 
            double[] c = new double[amountOfC];

            for (int i = 0; i < amountOfC; i++)
            {
                double temp = 0;
                for (int j = 0; j <= rowsInSystem; j++)
                {
                    temp += Math.Pow(x[j], i); //sum of x's in Power = index of the "c"
                }
                c[i] = temp;
            }

            //as matrix remains being square, the same variable is reused to iterate over rows and cols
            int rows = m + 1;
            double[][] matrixOfC = new double[rows][]; //matix of actual coefficients
            for (int i = 0; i < rows; i++)
            {
                matrixOfC[i] = new double[rows];
                for (int j = 0; j < rows; j++)
                {
                    matrixOfC[i][j] = c[i + j];
                }
            }
            //calculate values of d. As their amount == to amount of rows in matrix, reuse that variable
            double[] d = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                double temp = 0;
                for (int j = 0; j <= rowsInSystem; j++)
                {
                    temp += Math.Pow(x[j], i) * y[j];
                }
                d[i] = temp;
            }

            double[] ixs = Gauss.Calculate(matrixOfC, d); //indexes

            double[] results = new double[xz.Length];
            for (int i = 0; i < xz.Length; i++)
            {
                double sumOfCoeffs = 0;
                //equation evaluation, given in general form : a4*x^4 + a3*x^3 + a2*x^2 + a1*x^1 + a0
                for (int j = m; j >= 0; j--)
                {
                    sumOfCoeffs += ixs[j] * Math.Pow(xz[i], j);
                }
                results[i] = sumOfCoeffs;
            }
            return results;
        }
    }
}
