using System;

namespace ChislennieMethody_Lab2
{
    class Program
    {

        static void Main(string[] args)
        {
            double[][] array = new double[3][];

            //array[0] = new double[] { 3, -1, -1 };
            //array[1] = new double[] { 1, 1, -4 };
            //array[2] = new double[] { -2, 6, -1 };

            //double[] results = { -1, -10, 1 };

            array[0] = new double[] { 3, 1, -1 };
            array[1] = new double[] { -2, 4, -1 };
            array[2] = new double[] { 1, 1, -4 };

            double[] results = { 2, 0, -6 };

            var result = Holetski.Calculate(array, results);
            Console.WriteLine("Холецкий: ");
            for (int i = 0; i < result.Length; i++) Console.WriteLine(i + ": " + result[i]);

            result = Gaus.Calculate(array, results);
            Console.WriteLine("Гаус: ");
            for (int i = 0; i < result.Length; i++) Console.WriteLine(i + ": " + result[i]);

            double eps = 0.000001;
            //result = SimpleIteration.Calculate(array, eps);
            result = new SimpleIteration(array, results).GetMatrixAnswer();

            Console.WriteLine("Простой итерации: ");
            for (int i = 0; i < result.Length; i++) Console.WriteLine(i + ": " + result[i]);

            result = SquareRoot.method(array, results);
            Console.WriteLine("Квадратного корня: ");
            for (int i = 0; i < result.Length; i++) Console.WriteLine(i + ": " + result[i]);

            //double[][] array1 = new double[3][];
            //array1[0] = new double[] { 2, -1, 1 };
            //array1[1] = new double[] { 3, 5, -2 };
            //array1[2] = new double[] { 1, -4, 10 };

            //double[] results1 = {-3, 1, 0 };

            //double eps = 0.000001;
            //var result = SimpleIteration.Calculate(array1, results1, eps);
            //for (int i = 0; i < result.Length; i++) Console.WriteLine(i+": "+result[i]);


            //double[][] array1 = new double[3][];
            //array1[0] = new double[] { 1, -3, 2 };
            //array1[1] = new double[] { -3, 10, -5 };
            ////array1[2] = new double[] { 2, -5, 9 };

            //double[] results1 = { 10, 12, 14 };
            //var result = SquareRoot.method(array1, results1);

            Console.ReadLine();
        }
    }
}
