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
            this.displayChart.Location = new System.Drawing.Point(65, 12);
            this.displayChart.Name = "displayChart";
            this.displayChart.Size = new System.Drawing.Size(626, 370);
            this.displayChart.TabIndex = 0;
            this.displayChart.Text = "cartesianChart1";
            // 
            // StockWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.displayChart);
            this.Name = "StockWindow";
            this.Text = "StockWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart displayChart;
    }
}