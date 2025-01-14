using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockPredictorAndDisplay
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        //loads and shows list of stocks to be selected
        private void showStocksButton_Click(object sender, EventArgs e)
        {
            //puts stocks into list of strings
            string[] stocksArr = PopulateList.Populate();



            //makes list visible on click
            if(stockPickerCheckedListBox.Visible == false)
            {
                stockPickerCheckedListBox.Visible = true;

                stockPickerCheckedListBox.Items.Clear();
                stockPickerCheckedListBox.Items.AddRange(stocksArr);
            }
            else
            {
                stockPickerCheckedListBox.Visible = false;
            }
        }

        //makes it so that one item can be selected
        private void stockPickerCheckedListBox_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < stockPickerCheckedListBox.Items.Count; ++ix)
                if (ix != e.Index) stockPickerCheckedListBox.SetItemChecked(ix, false);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //checking that a stock is selected
            if (stockPickerCheckedListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item.");
                return;
                
            }

            string stockSelected = PopulateList.GetTicker(stockPickerCheckedListBox.SelectedItem.ToString());
            int startYear = 0;
            int endYear = 0;

            //check for valid start year
            if (startYearComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a start year.");
                return;
            }else
            {
                startYear = int.Parse(startYearComboBox.SelectedItem.ToString());
            }

            //check for valid end year
            if (yearComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an end year.");
                return; 
            }else
            {
                endYear = int.Parse(yearComboBox.SelectedItem.ToString());
            }

            if(startYear > endYear)
            {
                MessageBox.Show("Start Year cannot be after End Year.");
                return;
            }

            GlobalData.CurrentUserChoice.StockSelected = stockSelected;
            GlobalData.CurrentUserChoice.StartYear = startYear;
            GlobalData.CurrentUserChoice.EndYear = endYear;

            StockWindow stockWindow = new StockWindow();
            stockWindow.Show();
        }
    }
}
