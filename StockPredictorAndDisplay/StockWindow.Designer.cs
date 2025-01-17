namespace StockPredictorAndDisplay
{
    partial class StockWindow
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
            this.displayChart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // displayChart
            // 
            this.displayChart.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayChart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.displayChart.Location = new System.Drawing.Point(3, 2);
            this.displayChart.Name = "displayChart";
            this.displayChart.Size = new System.Drawing.Size(776, 455);
            this.displayChart.TabIndex = 0;
            this.displayChart.Text = "cartesianChart1";
            // 
            // StockWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.displayChart);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "StockWindow";
            this.Text = "StockWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart displayChart;
    }
}