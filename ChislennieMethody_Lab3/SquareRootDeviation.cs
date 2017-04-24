using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class SquareRootDeviation
    {
        /**
         * deviation is calculated values of Y, given in preconditions,
         * and for Y, calculated using LessSquare method.
         */
        public static double calculate(double[] initialY, double[] calculatedY)
        {
            double sum = 0;
            for (int i = 0; i < initialY.Length; i++)
            {
                sum += Math.Pow(initialY[i] - calculatedY[i], 2);
            }
            return Math.Sqrt(sum / initialY.Length);
        }
    }
}
