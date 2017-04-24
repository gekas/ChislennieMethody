namespace Lab3
{
    public class Lagrange
    {

        public static double Calc(double[] X, double[] Y, double x)
        {
            int n = X.Length;
            double z = 0;
            for (int j = 0; j < n; j++)
            {
                double upper = 1;
                double lower = 1;
                for (int i = 0; i < n; i++)
                {
                    if (i != j)
                    {
                        upper *= (x - X[i]);
                        lower *= (X[j] - X[i]);
                    }
                }
                z = z + Y[j] * upper / lower;
            }
            return z;
        }
    }
}
