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

            //array[0] = new double[] { 1, 3, -3 };
            //array[1] = new double[] { 3, 10, -11 };
            //array[2] = new double[] { -3, -11, 22 };

            //double[] results = { 11, -2, 10 };

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




            // Квадратного корня (На симметричнйо матрице)
            double[,] Mtx = new double[3,3];
            Mtx[0, 0] = 2;
            Mtx[0, 1] = 1;
            Mtx[0, 2] = 4;

            Mtx[1, 0] = 1;
            Mtx[1, 1] = 1;
            Mtx[1, 2] = 3;

            Mtx[2, 0] = 4;
            Mtx[2, 1] = 3;
            Mtx[2, 2] = 14;

            double[,] S;

            double[] B = { 16,12,52};
            var  sr = SquareRoot.Calculate(out S, Mtx, B);

            Console.WriteLine("Квадратного корня: ");
            for (int i = 0; i < result.Length; i++) Console.WriteLine(i + ": " + sr[i]);
            Console.ReadLine();
        }
    }
}
