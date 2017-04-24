using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChislennieMethody_Lab2
{
    class SimpleIteration
    {
        public static double[] Calculate(double[][] matrixInit, double[] results, double eps)
        {
            int size = 3;
            var matrix = MergeMatrixs(matrixInit, results);

            // Введем вектор значений неизвестных на предыдущей итерации,
            // размер которого равен числу строк в матрице, т.е. size,
            // причем согласно методу изначально заполняем его нулями
            double[] previousVariableValues = new double[size];
            for (int i = 0; i < size; i++)
            {
                previousVariableValues[i] = 0.0;
            }

            // Будем выполнять итерационный процесс до тех пор,
            // пока не будет достигнута необходимая точность
            while (true)
            {
                // Введем вектор значений неизвестных на текущем шаге
                double[] currentVariableValues = new double[size];

                // Посчитаем значения неизвестных на текущей итерации
                // в соответствии с теоретическими формулами
                for (int i = 0; i < size; i++)
                {
                    // Инициализируем i-ую неизвестную значением
                    // свободного члена i-ой строки матрицы
                    currentVariableValues[i] = matrix[i][size];

                    // Вычитаем сумму по всем отличным от i-ой неизвестным
                    for (int j = 0; j < size; j++)
                    {
                        if (i != j)
                        {
                            currentVariableValues[i] -= matrix[i][j] * previousVariableValues[j];
                        }
                    }

                    // Делим на коэффициент при i-ой неизвестной
                    currentVariableValues[i] /= matrix[i][i];
                }

                // Посчитаем текущую погрешность относительно предыдущей итерации
                double error = 0.0;

                for (int i = 0; i < size; i++)
                {
                    error += Math.Abs(currentVariableValues[i] - previousVariableValues[i]);
                }

                // Если необходимая точность достигнута, то завершаем процесс
                if (error < eps)
                {
                    break;
                }

                // Переходим к следующей итерации, так
                // что текущие значения неизвестных
                // становятся значениями на предыдущей итерации
                previousVariableValues = currentVariableValues;
            }

            // Выводим найденные значения неизвестных
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(previousVariableValues[i] + " ");
            }

            return previousVariableValues;
        }

        ///**
        // * Совмещает матрицу значений А и матрицу коэффициентов coeffs.
        // */
        public static double[][] MergeMatrixs(double[][] a, double[] coeffs)
        {
            int initialLength = a[0].Length;
            double[][] matrix = new double[a.Length][];
            for (int i = 0; i < a.Length; i++)
            {
                matrix[i] = new double[a[i].Length + 1];
            }
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    matrix[i][j] = a[i][j];
                }
                matrix[i][initialLength] = coeffs[i];
            }

            return matrix;
        }

        ///** 
        //* Посчитаем, имеется ли диагональное доминирование в матрице. 
        //* Является ли значение a[i][i], взятое по модулю, больше суммые коэфф. а на этой строке, 
        //* исключая диаг. элементы. 
        //*/
        //private static bool isMethodApplicable(double[][] a)
        //{
        //    bool[] aIsGreater = new bool[a.Length]; //хранит true, если модуль a[i][i] > суммы эл-в в строке (кроме a[i][i]) 
        //    bool atLeastOneStrict = false; //хотя бы одно неравенство должно быть строгим: >= 
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        double sum = 0;
        //        for (int j = 0; j < a[i].Length; j++)
        //        {
        //            if (i != j)
        //            {
        //                sum += Math.Abs(a[i][j]);
        //            }
        //        }
        //        aIsGreater[i] = Math.Abs(a[i][i]) >= sum;
        //        if (a[i][i] == sum)
        //        {
        //            atLeastOneStrict = true;
        //        }
        //    }
        //    if (!atLeastOneStrict)
        //    { //для диаг. доминирования нужно хотя бы одно строгое равенство 
        //        return false;
        //    }
        //    bool result = true;
        //    for (int i = 0; i < aIsGreater.Length; i++)
        //    {
        //        result &= aIsGreater[i]; //сложение по И: хоть один false превратит result в false 
        //    }
        //    return result;
        //}

        //public static double[] method(double[][] matrix, double eps)
        //{
        //    int size = matrix.Length;
        //    //Вектор значений неизвестных на предыдущей итерации
        //    double[] previousVariableValues = new double[size];

        //    //Будем выполнять итерационный процесс до тех пор,
        //    //пока не будет достигнута необходимая точность
        //    while (true)
        //    {
        //        //Введем вектор значений неизвестных на текущем шаге
        //        double[] currentVariableValues = new double[size];
        //        //Посчитаем значения неизвестных на текущей итерации
        //        //в соответствии с теоретическими формулами
        //        for (int i = 0; i < size; i++)
        //        {
        //            //Инициализируем i-ую неизвестную значением
        //            //свободного члена i-ой строки матрицы
        //            currentVariableValues[i] = matrix[i][size];

        //            //Вычитаем сумму по всем отличным от i-ой неизвестным
        //            for (int j = 0; j < size; j++)
        //            {
        //                if (i != j)
        //                {
        //                    currentVariableValues[i] -= matrix[i][j] * previousVariableValues[j];
        //                }
        //            }
        //            //Делим на коэффициент при i-ой неизвестной
        //            currentVariableValues[i] /= matrix[i][i];
        //        }
        //        //Посчитаем текущую погрешность относительно предыдущей итерации
        //        double error = 0.0;
        //        for (int i = 0; i < size; i++)
        //        {
        //            error += Math.Abs(currentVariableValues[i] - previousVariableValues[i]);
        //        }
        //        //Если необходимая точность достигнута, то завершаем процесс
        //        if (error < eps)
        //        {
        //            break;
        //        }
        //        //Переходим к следующей итерации, так
        //        //что текущие значения неизвестных
        //        //становятся значениями на предыдущей итерации
        //        previousVariableValues = currentVariableValues;
        //    }
        //    return previousVariableValues;

        //}
    }
}
