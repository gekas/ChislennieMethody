using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class NewtonDevidedDifferencescs
    {
        public static double[] Calc(double[] xk, double[] x, double[] y)
        {
            int n = x.Length - 1;
            double elementInTheMiddle = x[x.Length / 2]; //should be around 3 for my variant

            double[][] dy = new double[n][];//array of differences

            //first row is filled from the "y" and "x" values:
            dy[0] = new double[n];
            for (int j = 0; j < n; j++)
            {
                dy[0][j] = (y[j + 1] - y[j]) / (x[j + 1] - x[j]); //0 + j + 1 or even i + j + 1
            }

            //rest of values are calculated over previously found "dy" differences and "x" values:
            for (int i = 1; i < n; i++)
            {
                dy[i] = new double[n - i];
                for (int j = 0; j < n - i; j++)
                {
                    dy[i][j] = (dy[i - 1][j + 1] - dy[i - 1][j]) / (x[j + i + 1] - x[j]);
                }
            }

            double[] results = new double[xk.Length];
            //when element is closer to right boundary, it's better to use backward interpolation,
            //if it's closer to the left boundary - then forward interpolation, respectively.
            for (int j = 0; j < xk.Length; j++)
            {
                results[j] = xk[j] > elementInTheMiddle ? calculateBackward(xk[j], x, y, dy) :
                        calculateForward(xk[j], x, y, dy);
            }

            return results;
        }

        /**
         * Inner loop models next sequence:
         * dy00 * (z - x0)
         * dy10 * (z - x0) * (z - x1)
         * dy20 * (z - x0) * (z - x1) * (z - x2)
         * dy30 * (z - x0) * (z - x1) * (z - x2) * (z - x3)
         *
         * @param X  - value of x, for which interp. should be calculated
         * @param x  - array of initial values of x
         * @param y  - array of initial values of y
         * @param dy - array^2 of Newton differencies, built for x and y
         */
        private static double calculateForward(double X, double[] x, double[] y, double[][] dy)
        {
            int n = x.Length - 1;
            double Pforward = y[0];

            for (int j = 0; j < n; j++)
            {
                double accum = 1;
                for (int k = 0; k < j + 1; k++)
                {
                    accum *= (X - x[k]);
                }
                Pforward += dy[j][0] * accum;
            }
            return Pforward;
        }

        /**
         * Inner loop models next sequence:
         * dy04 * (z - x4)
         * dy13 * (z - x4) * (z - x3)
         * dy22 * (z - x4) * (z - x3) * (z - x2)
         * dy31 * (z - x4) * (z - x3) * (z - x2) * (z - x1)
         *
         * @param X  - value of x, for which interp. should be calculated
         * @param x  - array of initial values of x
         * @param y  - array of initial values of y
         * @param dy - array^2 of Newton differencies, built for x and y
         */
        private static double calculateBackward(double X, double[] x, double[] y, double[][] dy)
        {
            int n = x.Length - 1;
            double Pbackward = y[n];
            for (int j = n; j > 0; j--)
            {
                int k = n;
                double accum = 1;
                for (int kk = k - j; kk >= 0; k--, kk--)
                {
                    accum *= (X - x[k]);
                }
                Pbackward += dy[n - j][k] * accum;
            }
            return Pbackward;
        }
    }
}
