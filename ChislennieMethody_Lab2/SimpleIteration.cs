using System;

namespace ChislennieMethody_Lab2
{
    class OutMatrix
    {
        private uint row;
        private uint column;

        public OutMatrix(uint row, uint column)
        {
            this.row = row;
            this.column = column;
        }

        public void Output(double[,] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                    Console.Write(Math.Round(matrix[i, j], 2) + "  ");
                Console.WriteLine();
            }
        }

        public void Output(double[] matrix, double error, double eps, int k)
        {
            Console.Write("Iteration: " + k + "| matrix=>| ");
            for (int i = 0; i < row; i++)
            {
                Console.Write("x" + i + "=" + Math.Round(matrix[i], 2) + "|");
            }
            bool b = error < eps;
            Console.Write(" (xp - xc) = " + error + " # " + b + " | ");
            Console.WriteLine();
        }

        public void Output(double[][] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                    Console.Write(Math.Round(matrix[i][j], 2) + "  ");
                Console.WriteLine();
            }
        }

        public void Output(double[] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                Console.Write(Math.Round(matrix[i], 2) + "  ");
            }
        }
    }

    class SimpleIteration
    {
        double eps = 0.00005;
        int size = 3;
        private double[][] Matrix { get; set; }
        private double[] RightPart { get; set; }
        OutMatrix out_mtr;

        public SimpleIteration(double[][] m, double[] r)
        {
            Matrix = m;
            RightPart = r;

            out_mtr = new OutMatrix(3, 3);
        }

        public double[] GetMatrixAnswer()
        {
            if (!isMethodApplicable(Matrix))
            {
                Console.WriteLine("Mетод применить нельзя - нет диагонального доминирования!");
                return new double[Matrix.Length]; // возвращаем массив нулей 
            }
            return MainMeth(Matrix, eps);
        }
        /** 
        * Посчитаем, имеется ли диагональное доминирование в матрице. 
        * Является ли значение a[i][i], взятое по модулю, больше суммые коэфф. а на этой строке, 
        * исключая диаг. элементы. 
        */
        private bool isMethodApplicable(double[][] a)
        {
            bool[] aIsGreater = new bool[a.Length]; //хранит true, если модуль a[i][i] > суммы эл-в в строке (кроме a[i][i]) 

            for (int i = 0; i < a.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (i != j)
                    {
                        sum += Math.Abs(a[i][j]);
                    }
                }
                aIsGreater[i] = Math.Abs(a[i][i]) >= sum;
            }

            bool result = true;
            for (int i = 0; i < aIsGreater.Length; i++)
            {
                result &= aIsGreater[i]; //сложение по И: хоть один false превратит result в false 
            }
            return result;
        }

        private double[] MainMeth(double[][] matrix, double eps)
        {
            double[] previousVariableValues = new double[size];
            double[] currentVariableValues = new double[size];
            //Вектор значений неизвестных на предыдущей итерации
            for (int i = 0; i < size; i++)
            {
                previousVariableValues[i] = RightPart[i] / matrix[i][i];
            }
            out_mtr.Output(previousVariableValues, -1, -1, 0);

            //Введем вектор значений неизвестных на текущем шаге            
            int k = 1;
            // Будем выполнять итерационный процесс до тех пор, пока не будет достигнута необходимая точность
            while (true)
            {
                currentVariableValues = new double[size];
                // Посчитаем значения неизвестных на текущей итерации
                // в соответствии с теоретическими формулами
                for (int i = 0; i < size; i++)
                {
                    // Вычитаем сумму по всем отличным от i-ой неизвестным
                    for (int j = 0; j < size; j++)
                    {
                        if (i != j)
                        {
                            currentVariableValues[i] -= (matrix[i][j] / matrix[i][i]) * previousVariableValues[j];
                        }
                    }
                    currentVariableValues[i] += RightPart[i] / matrix[i][i];
                }

                if (GetError(currentVariableValues, previousVariableValues) < eps)
                {
                    break;
                }
                out_mtr.Output(currentVariableValues, GetError(currentVariableValues, previousVariableValues), eps, k);
                k++;
                previousVariableValues = currentVariableValues;
            }
            return previousVariableValues;
        }

        private double GetError(double[] cVV, double[] pVV)
        {
            // Посчитаем текущую погрешность относительно предыдущей итерации
            double error = 0.0, max = 0;

            for (int i = 0; i < size; i++)
            {
                error = Math.Abs((cVV[i] - pVV[i]));
                if (max < error)
                    max = error;
            }
            return error;
        }
    }
}
