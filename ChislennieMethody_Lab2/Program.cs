using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChislennieMethody_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var xx = Gaus.Calculate(matrix);

            //for(int i =0; i < xx.Length;i++)
            //    Console.WriteLine(xx[i]);

            double[][] array = new double[3][];
            array[0] = new double[]{ 2,-1,-1 };
            array[1] = new double[] { 3, 4, -2 };
            array[2] = new double[] { 3, -2, 4 };
            double[,] array = { { 2,-1,-1},
                                 { 3,4,-2 },
                                 { 3,-2,4}
                               };

            Holetski h = new Holetski(array);

        }
    }
}
