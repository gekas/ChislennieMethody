using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab3
{
    public partial class Form1 : Form
    {
        Series sLagrange = new Series("Lagrange") { ChartType = SeriesChartType.Line };
        Series sNewtone = new Series("Newtone") { ChartType = SeriesChartType.Line };
        Series sLessSquares1 = new Series("sLessSquares1") { ChartType = SeriesChartType.Point, MarkerSize = 10 };
        Series sLessSquares2 = new Series("sLessSquares2") { ChartType = SeriesChartType.Point, MarkerSize = 10 };
        Series sLessSquares3 = new Series("sLessSquares3") { ChartType = SeriesChartType.Point, MarkerSize = 10 };
        Series sLessSquares4 = new Series("sLessSquares4") { ChartType = SeriesChartType.Point, MarkerSize = 10 };

        private static double[] x = { 0, 2, 3, 4, 6 };
        private static double[] y = { 3, -1, 4, 5, 1 };

        private static double[] xz = { -1, 0, 1, 2, 2.5, 3, 3.5, 4, 5, 5, 6, 6.5 };

        public Form1()
        {
            InitializeComponent();
            chart1.Series.Add(sLagrange);
            chart1.Series.Add(sNewtone);
            chart1.Series.Add(sLessSquares1);
            chart1.Series.Add(sLessSquares2);
            chart1.Series.Add(sLessSquares3);
            chart1.Series.Add(sLessSquares4);
        }

        class MeasurementsModel
        {
            public double X { get; set; }
            public double L { get; set; }
            public double P { get; set; }
            public double Q1 { get; set; }
            public double Q2 { get; set; }
            public double Q3 { get; set; }
            public double Q4 { get; set; }
        }

        private void FillGrid()
        {
            dgvMeasurements.Rows.Clear();

            List<MeasurementsModel> results = new List<MeasurementsModel>();
            var  newtones = NewtonDevidedDifferencescs.Calc(xz, x, y);
            var q1s = LessSquares.Calc(x, y, xz, 1);
            var q2s = LessSquares.Calc(x, y, xz, 2);
            var q3s = LessSquares.Calc(x, y, xz, 3);
            var q4s = LessSquares.Calc(x, y, xz, 4);

            for (int i = 0; i < xz.Length; i++)
            {
                var newMeasurement = new MeasurementsModel();
                newMeasurement.X = xz[i];
                newMeasurement.L = Lagrange.Calc(x, y, xz[i]);
                newMeasurement.P = newtones[i];
                newMeasurement.Q1 = q1s[i];
                newMeasurement.Q2 = q2s[i];
                newMeasurement.Q3 = q3s[i];
                newMeasurement.Q4 = q4s[i];

                results.Add(newMeasurement);
                var idx = dgvMeasurements.Rows.Add();
                dgvMeasurements.Rows[idx].Cells["dcX"].Value = newMeasurement.X;
                dgvMeasurements.Rows[idx].Cells["dcL"].Value = newMeasurement.L;
                dgvMeasurements.Rows[idx].Cells["dcP"].Value = newMeasurement.P;
                dgvMeasurements.Rows[idx].Cells["dcQ1"].Value = newMeasurement.Q1;
                dgvMeasurements.Rows[idx].Cells["dcQ2"].Value = newMeasurement.Q2;
                dgvMeasurements.Rows[idx].Cells["dcQ3"].Value = newMeasurement.Q3;
                dgvMeasurements.Rows[idx].Cells["dcQ4"].Value = newMeasurement.Q4;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private static double[] formXs()
        {
            var xi = new List<double>();

            double xMinus1 = x[0] - (x[1] - x[0]) / 2;
            for (int i = 0; i < x.Length - 1; i++)
            {
                double value = x[i] + (x[i + 1] - x[i]) / 2;
                if (!xi.Contains(value))
                {
                    xi.Add(value);
                }

            }
            double xN = x[x.Length - 1] + (x[x.Length - 2] - x[x.Length - 1]) / 2;

            xi.AddRange(x); //Add all existing values of X
            xi.Add(xMinus1);
            xi.Add(xN);
            xi.Sort();
            //xi.ForEach(a => Console.Write(a + " "));
            return xi.ToArray();
        }

        private void cbxLagrange_CheckedChanged(object sender, EventArgs e)
        {
            sLagrange.Points.Clear();

            if (cbxLagrange.Checked)
            {
                for (int i = 0; i < xz.Length; i++)
                {
                    sLagrange.Points.Add(new DataPoint(xz[i], Lagrange.Calc(x, y, xz[i])));
                }
            }
        }

        private void cbxNewtone_CheckedChanged(object sender, EventArgs e)
        {
            sNewtone.Points.Clear();

            if (cbxNewtone.Checked)
            {
                double[] newtons = NewtonDevidedDifferencescs.Calc(xz, x, y);
                for (int i = 0; i < xz.Length; i++)
                {
                    sNewtone.Points.Add(new DataPoint(xz[i], newtons[i]));
                }
            }
        }

        private void FillMnk(Series seria, int power)
        {
            var results = LessSquares.Calc(x, y, xz, power);
            for (int j = 0; j < results.Length; j++)
            {
                seria.Points.Add(new DataPoint(xz[j], results[j]));
            }
        }

        private void cbxMNK1_CheckedChanged(object sender, EventArgs e)
        {
            sLessSquares1.Points.Clear();

            if (cbxMNK1.Checked)
            {
                FillMnk(sLessSquares1, 1);
            }
        }

        private void cbxMNK2_CheckedChanged(object sender, EventArgs e)
        {
            sLessSquares2.Points.Clear();

            if (cbxMNK2.Checked)
            {
                FillMnk(sLessSquares2, 2);
            }
        }

        private void cbxMNK3_CheckedChanged(object sender, EventArgs e)
        {
            sLessSquares3.Points.Clear();

            if (cbxMNK3.Checked)
            {
                FillMnk(sLessSquares3, 3);
            }
        }

        private void cbxMNK4_CheckedChanged(object sender, EventArgs e)
        {
            sLessSquares4.Points.Clear();

            if (cbxMNK4.Checked)
            {
                FillMnk(sLessSquares4, 4);
            }
        }
    }
}
