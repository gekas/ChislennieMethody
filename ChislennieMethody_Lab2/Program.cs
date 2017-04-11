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

            double[,] array = { { 2,-1,-1},
                                 { 3,4,-2 },
                                 { 3,-2,4}
                               };

            Holetski h = new Holetski(array);
            Console.ReadLine();

        }
    }
}
