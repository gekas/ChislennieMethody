namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbxLagrange = new System.Windows.Forms.CheckBox();
            this.cbxNewtone = new System.Windows.Forms.CheckBox();
            this.cbxMNK1 = new System.Windows.Forms.CheckBox();
            this.cbxMNK2 = new System.Windows.Forms.CheckBox();
            this.cbxMNK3 = new System.Windows.Forms.CheckBox();
            this.cbxMNK4 = new System.Windows.Forms.CheckBox();
            this.dgvMeasurements = new System.Windows.Forms.DataGridView();
            this.dcX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcQ1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcQ2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcQ3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcQ4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurements)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Left;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(808, 741);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // cbxLagrange
            // 
            this.cbxLagrange.AutoSize = true;
            this.cbxLagrange.Location = new System.Drawing.Point(817, 22);
            this.cbxLagrange.Name = "cbxLagrange";
            this.cbxLagrange.Size = new System.Drawing.Size(71, 17);
            this.cbxLagrange.TabIndex = 1;
            this.cbxLagrange.Text = "Lagrange";
            this.cbxLagrange.UseVisualStyleBackColor = true;
            this.cbxLagrange.CheckedChanged += new System.EventHandler(this.cbxLagrange_CheckedChanged);
            // 
            // cbxNewtone
            // 
            this.cbxNewtone.AutoSize = true;
            this.cbxNewtone.Location = new System.Drawing.Point(817, 45);
            this.cbxNewtone.Name = "cbxNewtone";
            this.cbxNewtone.Size = new System.Drawing.Size(69, 17);
            this.cbxNewtone.TabIndex = 2;
            this.cbxNewtone.Text = "Newtone";
            this.cbxNewtone.UseVisualStyleBackColor = true;
            this.cbxNewtone.CheckedChanged += new System.EventHandler(this.cbxNewtone_CheckedChanged);
            // 
            // cbxMNK1
            // 
            this.cbxMNK1.AutoSize = true;
            this.cbxMNK1.Location = new System.Drawing.Point(817, 69);
            this.cbxMNK1.Name = "cbxMNK1";
            this.cbxMNK1.Size = new System.Drawing.Size(56, 17);
            this.cbxMNK1.TabIndex = 3;
            this.cbxMNK1.Text = "МНК1";
            this.cbxMNK1.UseVisualStyleBackColor = true;
            this.cbxMNK1.CheckedChanged += new System.EventHandler(this.cbxMNK1_CheckedChanged);
            // 
            // cbxMNK2
            // 
            this.cbxMNK2.AutoSize = true;
            this.cbxMNK2.Location = new System.Drawing.Point(817, 92);
            this.cbxMNK2.Name = "cbxMNK2";
            this.cbxMNK2.Size = new System.Drawing.Size(56, 17);
            this.cbxMNK2.TabIndex = 4;
            this.cbxMNK2.Text = "МНК2";
            this.cbxMNK2.UseVisualStyleBackColor = true;
            this.cbxMNK2.CheckedChanged += new System.EventHandler(this.cbxMNK2_CheckedChanged);
            // 
            // cbxMNK3
            // 
            this.cbxMNK3.AutoSize = true;
            this.cbxMNK3.Location = new System.Drawing.Point(817, 115);
            this.cbxMNK3.Name = "cbxMNK3";
            this.cbxMNK3.Size = new System.Drawing.Size(56, 17);
            this.cbxMNK3.TabIndex = 5;
            this.cbxMNK3.Text = "МНК3";
            this.cbxMNK3.UseVisualStyleBackColor = true;
            this.cbxMNK3.CheckedChanged += new System.EventHandler(this.cbxMNK3_CheckedChanged);
            // 
            // cbxMNK4
            // 
            this.cbxMNK4.AutoSize = true;
            this.cbxMNK4.Location = new System.Drawing.Point(817, 138);
            this.cbxMNK4.Name = "cbxMNK4";
            this.cbxMNK4.Size = new System.Drawing.Size(56, 17);
            this.cbxMNK4.TabIndex = 6;
            this.cbxMNK4.Text = "МНК4";
            this.cbxMNK4.UseVisualStyleBackColor = true;
            this.cbxMNK4.CheckedChanged += new System.EventHandler(this.cbxMNK4_CheckedChanged);
            // 
            // dgvMeasurements
            // 
            this.dgvMeasurements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasurements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dcX,
            this.dcL,
            this.dcP,
            this.dcQ1,
            this.dcQ2,
            this.dcQ3,
            this.dcQ4});
            this.dgvMeasurements.Location = new System.Drawing.Point(817, 219);
            this.dgvMeasurements.Name = "dgvMeasurements";
            this.dgvMeasurements.Size = new System.Drawing.Size(540, 308);
            this.dgvMeasurements.TabIndex = 7;
            // 
            // dcX
            // 
            this.dcX.HeaderText = "x";
            this.dcX.Name = "dcX";
            this.dcX.Width = 70;
            // 
            // dcL
            // 
            this.dcL.HeaderText = "L(x)";
            this.dcL.Name = "dcL";
            this.dcL.Width = 70;
            // 
            // dcP
            // 
            this.dcP.HeaderText = "P(x)";
            this.dcP.Name = "dcP";
            this.dcP.Width = 70;
            // 
            // dcQ1
            // 
            this.dcQ1.HeaderText = "Q1(x)";
            this.dcQ1.Name = "dcQ1";
            this.dcQ1.Width = 70;
            // 
            // dcQ2
            // 
            this.dcQ2.HeaderText = "Q2(x)";
            this.dcQ2.Name = "dcQ2";
            this.dcQ2.Width = 70;
            // 
            // dcQ3
            // 
            this.dcQ3.HeaderText = "Q3(x)";
            this.dcQ3.Name = "dcQ3";
            this.dcQ3.Width = 70;
            // 
            // dcQ4
            // 
            this.dcQ4.HeaderText = "Q4(x)";
            this.dcQ4.Name = "dcQ4";
            this.dcQ4.Width = 70;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.dgvMeasurements);
            this.Controls.Add(this.cbxMNK4);
            this.Controls.Add(this.cbxMNK3);
            this.Controls.Add(this.cbxMNK2);
            this.Controls.Add(this.cbxMNK1);
            this.Controls.Add(this.cbxNewtone);
            this.Controls.Add(this.cbxLagrange);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox cbxLagrange;
        private System.Windows.Forms.CheckBox cbxNewtone;
        private System.Windows.Forms.CheckBox cbxMNK1;
        private System.Windows.Forms.CheckBox cbxMNK2;
        private System.Windows.Forms.CheckBox cbxMNK3;
        private System.Windows.Forms.CheckBox cbxMNK4;
        private System.Windows.Forms.DataGridView dgvMeasurements;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcL;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcQ1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcQ2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcQ3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcQ4;
    }
}

