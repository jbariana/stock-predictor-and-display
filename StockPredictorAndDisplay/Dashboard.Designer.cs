namespace StockPredictorAndDisplay
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;

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
            this.stockPickerCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.showStocksButton = new System.Windows.Forms.Button();
            this.programLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.startYearLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.startYearComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // stockPickerCheckedListBox
            // 
            this.stockPickerCheckedListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.stockPickerCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stockPickerCheckedListBox.CheckOnClick = true;
            this.stockPickerCheckedListBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockPickerCheckedListBox.ForeColor = System.Drawing.Color.FloralWhite;
            this.stockPickerCheckedListBox.FormattingEnabled = true;
            this.stockPickerCheckedListBox.Location = new System.Drawing.Point(12, 164);
            this.stockPickerCheckedListBox.Name = "stockPickerCheckedListBox";
            this.stockPickerCheckedListBox.Size = new System.Drawing.Size(453, 225);
            this.stockPickerCheckedListBox.TabIndex = 0;
            this.stockPickerCheckedListBox.Visible = false;
            this.stockPickerCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.stockPickerCheckedListBox_ItemCheck_1);
            // 
            // showStocksButton
            // 
            this.showStocksButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.showStocksButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(98)))));
            this.showStocksButton.FlatAppearance.BorderSize = 3;
            this.showStocksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showStocksButton.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showStocksButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.showStocksButton.Location = new System.Drawing.Point(12, 111);
            this.showStocksButton.Name = "showStocksButton";
            this.showStocksButton.Size = new System.Drawing.Size(120, 35);
            this.showStocksButton.TabIndex = 1;
            this.showStocksButton.Text = "Show Stocks";
            this.showStocksButton.UseVisualStyleBackColor = false;
            this.showStocksButton.Click += new System.EventHandler(this.showStocksButton_Click);
            // 
            // programLabel
            // 
            this.programLabel.AutoSize = true;
            this.programLabel.Font = new System.Drawing.Font("Roboto", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programLabel.Location = new System.Drawing.Point(12, 19);
            this.programLabel.Name = "programLabel";
            this.programLabel.Size = new System.Drawing.Size(360, 58);
            this.programLabel.TabIndex = 2;
            this.programLabel.Text = "Stock Predictor";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(483, 85);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(180, 25);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "Enter Date Range:";
            // 
            // startYearLabel
            // 
            this.startYearLabel.AutoSize = true;
            this.startYearLabel.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startYearLabel.Location = new System.Drawing.Point(485, 136);
            this.startYearLabel.Name = "startYearLabel";
            this.startYearLabel.Size = new System.Drawing.Size(74, 18);
            this.startYearLabel.TabIndex = 4;
            this.startYearLabel.Text = "Start Year";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLabel.Location = new System.Drawing.Point(485, 187);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(66, 18);
            this.yearLabel.TabIndex = 7;
            this.yearLabel.Text = "End Year";
            // 
            // yearComboBox
            // 
            this.yearComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035"});
            this.yearComboBox.Location = new System.Drawing.Point(564, 183);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(121, 28);
            this.yearComboBox.TabIndex = 8;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(92)))), ((int)(((byte)(98)))));
            this.startButton.FlatAppearance.BorderSize = 3;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(488, 247);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(213, 121);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // startYearComboBox
            // 
            this.startYearComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startYearComboBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startYearComboBox.FormattingEnabled = true;
            this.startYearComboBox.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024"});
            this.startYearComboBox.Location = new System.Drawing.Point(564, 132);
            this.startYearComboBox.Name = "startYearComboBox";
            this.startYearComboBox.Size = new System.Drawing.Size(121, 28);
            this.startYearComboBox.TabIndex = 11;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.startYearComboBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.startYearLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.programLabel);
            this.Controls.Add(this.showStocksButton);
            this.Controls.Add(this.stockPickerCheckedListBox);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MaximumSize = new System.Drawing.Size(750, 450);
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox stockPickerCheckedListBox;
        private System.Windows.Forms.Button showStocksButton;
        private System.Windows.Forms.Label programLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label startYearLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox startYearComboBox;
    }
}