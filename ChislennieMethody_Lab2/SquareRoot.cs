using System;

namespace ChislennieMethody_Lab2
{
    class SquareRoot
    {
        public static double[] Calculate(out double[,] S, double [,] Mtx, double[] B)
        {
            int Count = 3;
            S = new double[Count, Count];
            S[0, 0] = Math.Sqrt(Mtx[0,0]);
            S[1, 0] = (double)Mtx[0, 1] / S[0, 0];
            S[2, 0] = (double)Mtx[0, 2] / S[0, 0];
            S[1, 1] = Math.Sqrt(Mtx[1, 1] - Math.Pow(S[1, 0], 2));
            S[2, 1] = (double)(Mtx[2, 1] - S[2, 0] * S[1, 0]) / S[1, 1];
            S[2, 2] = Math.Sqrt(Mtx[2, 2] - Math.Pow(S[2, 0], 2) - Math.Pow(S[2, 1], 2));

            double[] y = new double[Count];
            y[0] = (double)B[0] / S[0, 0];
            y[1] = (double)(B[1] - S[1, 0] * y[0]) / S[1, 1];
            y[2] = (double)(B[2] - S[2, 0] * y[0] - S[2, 1] * y[1]) / S[2, 2];

            double[] x = new double[Count];
            x[2] = (double)y[2] / S[2, 2];
            x[1] = (double)(y[1] - x[2] * S[2, 1]) / S[1, 1];
            x[0] = (double)(y[0] - x[1] * S[1, 0] - x[2] * S[2, 0]) / S[0, 0];

            return x;
        }

        //public uint RowCount;
        //public uint ColumCount;
        //public double[][] Matrix { get; set; }
        //public double[][] MatrixS { get; set; }
        //public double[][] MatrixS_T { get; set; }
        //public double[] MatrixY { get; set; }
        //public double[] MatrixX { get; set; }
        //public double[] RightPart { get; set; }
        //OutMatrix out_mtr;

        //private void FullArr()
        //{
        //    //обнулим массив
        //    for (int i = 0; i < RowCount; i++)
        //    {
        //        for (int j = 0; j < ColumCount; j++)
        //            MatrixS[i][j] = 0;
        //    }
        //}

        //public SquareRoot(double[][] m, double[] r)
        //{
        //    uint row = 3;
        //    uint colum = 3;

        //    RightPart = r;
        //    MatrixX = new double[row];
        //    MatrixY = new double[row];
        //    Matrix = m;
        //    MatrixS = new double[row][];
        //    for (int i = 0; i < row; i++) MatrixS[i] = new double[colum];
        //    MatrixS_T = new double[colum][];
        //    for (int i = 0; i < row; i++) MatrixS_T[i] = new double[colum];
        //    RowCount = row;
        //    ColumCount = colum;
        //    out_mtr = new OutMatrix(3, 3);

        //    FullArr();
        //}

        //public double[][] GetMatrixS()
        //{
        //    double tmp = 0;
        //    for (int i = 0; i < RowCount; i++)
        //    {
        //        MatrixS[i][i] = Math.Sqrt(Matrix[i][i]- tmp);

        //        for (int j = 1; j < ColumCount; j++)
        //        {
        //            if (j > i)
        //                MatrixS[i][j] = (1 / MatrixS[i][i]) * (Matrix[i][j] - GetSumIJ(i, j, MatrixS));
        //        }
        //        if (i < RowCount - 1)
        //            tmp = GetSumII(i + 1, MatrixS);
        //    }
        //    return MatrixS;
        //}

        //public double[][] GetMatrixS_T()
        //{
        //    for (int i = 0; i < RowCount; i++)
        //    {
        //        for (int j = 0; j < ColumCount; j++)
        //        {
        //            MatrixS_T[i][j] = MatrixS[j][i];
        //        }
        //    }
        //    return MatrixS_T;
        //}

        //public double[] GetMatrixY()
        //{
        //    double tmp = 0;
        //    for (int i = 0; i < RowCount; i++)
        //    {
        //        tmp = GetSumYI(i, MatrixS, MatrixY);
        //        MatrixY[i] = (RightPart[i] - tmp) / MatrixS[i][i];
        //    }
        //    return MatrixY;
        //}

        //public double[] GetMatrixX()
        //{
        //    double tmp = 0, b;
        //    int row = int.Parse(Convert.ToString(RowCount)) - 1;

        //    for (int i = row; i > -1; i--)
        //    {
        //        tmp = GetSumXI(i, MatrixS_T, MatrixX);
        //        b = MatrixS_T[i][i];
        //        MatrixX[i] = (MatrixY[i] - tmp) / b;
        //    }
        //    return MatrixX;
        //}

        //private double GetSumXI(int i, double[][] matrix, double[] x)
        //{
        //    double tmp = 0;
        //    int row = int.Parse(Convert.ToString(RowCount)) - 1;
        //    if (i < row)
        //    {
        //        for (int k = row; k > i; k--)
        //            tmp += matrix[k][i] * x[k];
        //        return tmp;
        //    }
        //    else return tmp;
        //}
        //private double GetSumYI(int i, double[][] matrix, double[] y)
        //{
        //    double tmp = 0;
        //    if (i > 0)
        //    {
        //        for (int k = 0; k < i; k++)
        //            tmp += matrix[k][i] * y[k];
        //        return tmp;
        //    }
        //    else return tmp;
        //}

        //private double GetSumII(int i, double[][] matrix)
        //{
        //    double tmp = 0;
        //    if (i > 0)
        //    {
        //        for (int k = 0; k < i; k++)
        //            tmp += matrix[k][i] * matrix[k][i];
        //        return tmp;
        //    }
        //    else return tmp;
        //}
        //private double GetSumIJ(int i, int j, double[][] matrix)
        //{
        //    double sum = 0;
        //    if (i > 0)
        //    {
        //        for (int k = 0; k < i; k++)
        //            sum += matrix[k][i] * matrix[k][j];
        //        return sum;
        //    }
        //    else return 0;
        //}

        //public void Solution()
        //{
        //    Console.WriteLine("3. Метод квадратного корня");
        //    Console.WriteLine();
        //    Console.WriteLine("S => ");
        //    Console.WriteLine("--------------");
        //    out_mtr.Output(GetMatrixS());
        //    Console.WriteLine("--------------");
        //    Console.WriteLine("S_T => ");
        //    Console.WriteLine("--------------");
        //    out_mtr.Output(GetMatrixS_T());
        //    Console.WriteLine("--------------");
        //    Console.Write("Y = ");
        //    out_mtr.Output(GetMatrixY());
        //    Console.WriteLine();
        //    Console.WriteLine("--------------");
        //    Console.Write("X = ");
        //    out_mtr.Output(GetMatrixX());
        //    Console.WriteLine();
        //    Console.WriteLine("--------------");
        //}

        //    public static double[] method(double[][] a, double[] coeffs)
        //    {
        //        int n = a.Length;
        //        double[][] g = new double[n][];

        //        for (int i = 0; i < n; i++)
        //        {
        //            g[i] = new double[n];
        //            double accGtoG1 = 0;
        //            for (int k = 0; k < i; k++)
        //            {
        //                accGtoG1 = accGtoG1 + g[k][i] * g[k][i]; //sums of g[1,i]^2
        //            }
        //            g[i][i] = Math.Sqrt(a[i][i] - accGtoG1); //actual g[1,1] - on diagonal

        //            for (int j = i + 1; j < n; j++)
        //            {
        //                double accGtoG2 = 0;
        //                for (int k = 0; k < i; k++)
        //                {
        //                    accGtoG2 = accGtoG2 + g[k][i] * g[k][j];
        //                }
        //                g[i][j] = (a[i][j] - accGtoG2) / g[i][i]; //actual g[1,2]
        //            }
        //        }
        //        //find
        //        double[] y = new double[n];
        //        for (int i = 0; i < n; i++)
        //        {
        //            double accGtoY = 0;
        //            for (int k = 0; k < i; k++)
        //            {
        //                accGtoY = accGtoY + g[k][i] * y[k]; //count vertical elements: g[1,3] g[2,3]
        //            }
        //            y[i] = (coeffs[i] - accGtoY) / g[i][i]; //actual y[1]
        //        }
        //        //print(g);
        //        //reverse steps:
        //        double[] x = new double[n];
        //        for (int i = n - 1; i >= 0; i--)
        //        {
        //            double accGtoX = 0;
        //            for (int k = i + 1; k < n; k++)
        //            {       //for (k = (i + 1); k < n; k++)
        //                accGtoX = accGtoX + g[i][k] * x[k];
        //            }
        //            x[i] = (y[i] - accGtoX) / g[i][i];
        //        }
        //        return x;
        //    }
    }
}
