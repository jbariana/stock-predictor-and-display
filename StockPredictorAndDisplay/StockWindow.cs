using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Documents.Serialization;
using System.Windows.Forms;
using System.Windows.Markup;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace StockPredictorAndDisplay
{
    public partial class StockWindow : Form
    {
        public StockWindow()
        {
            InitializeComponent();

            // Set up chart properties on form load
            SetupChart();

            PopulateChart(GlobalData.CurrentUserChoice.StockSelected, GlobalData.CurrentUserChoice.StartYear, GlobalData.CurrentUserChoice.EndYear);
        }

        private void SetupChart()
        {
            // Initialize the Cartesian chart
            displayChart.Series = new SeriesCollection();
            displayChart.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = new List<string>() // Will be populated dynamically
            });

            displayChart.AxisY.Add(new Axis
            {
                Title = "Price",
                LabelFormatter = value => value.ToString("C") // Currency format
            });


            displayChart.LegendLocation = LegendLocation.Right;
        }
        public void PopulateChart(string ticker, int startYear, int endYear)
        {
            // Get a list of all dates in the range
            List<string> allDates = allDatesFinder(startYear, endYear);

            // Fetch data from the database
            List<StockModel> stockData = DataAccess.LoadFromTickerWithDates(ticker, startYear, endYear);

            // Generate a list of prices corresponding to the specified dates from the stock data
            List<double> priceData = getPriceData(allDates, GetPriceDictionary(stockData));

            // Updates the X axis labels and updates separator property for spacing, also sets Y-axis range based on stock data
            setAxes(allDates, priceData);

            // Add stock data series to the chart
            displayData(ticker, priceData);

            //adds a line for when the data ends and prediction begins
            addEndOfDataLine(allDates);

            // Force chart to refresh
            displayChart.Refresh();
        }

        //change to change type of price taken from database
        public Dictionary<string, double> GetPriceDictionary(List<StockModel> stockData)
        {
            return stockData
                .ToDictionary(
                    s => DateTime.Parse(s.Date).ToString("yyyy-MM-dd"),
                    s => double.TryParse(s.Close, out var close) ? close : double.NaN
                );
        }

        //creates end of data line
        private void addEndOfDataLine(List<string> allDates)
        {
            // Add a vertical line at 12/29/2024
            var endDateForLine = new DateTime(2024, 12, 29).ToString("yyyy-MM-dd");
            var endDateIndex = allDates.IndexOf(endDateForLine);

            if (endDateIndex != -1)
            {
                // Add a vertical line using AxisSection
                var verticalLine = new LiveCharts.Wpf.AxisSection
                {
                    Value = endDateIndex, // The X-axis index for 12/29/2024
                    Stroke = System.Windows.Media.Brushes.Red,
                    StrokeThickness = 2,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection { 4 }, // Dashed line
                    SectionWidth = 0 // Ensures it appears as a single line
                };

                displayChart.AxisX[0].Sections.Add(verticalLine);
            }
        }

        //finds all of the dates in the given range
        private List<string> allDatesFinder(int startYear, int endYear)
        {
            var startDate = new DateTime(startYear, 1, 1);
            var endDate = new DateTime(endYear, 12, 31);
            return Enumerable.Range(0, (endDate - startDate).Days + 1)
                                      .Select(offset => startDate.AddDays(offset).ToString("yyyy-MM-dd"))
                                      .ToList();
        }

        //gets all priceData in region
        private List<double> getPriceData(List<string> allDates, Dictionary<string, double> dateToPrice)
        {
            return allDates
                .Select(date => dateToPrice.ContainsKey(date) ? dateToPrice[date] : double.NaN)
                .ToList();
        }

        //updates chart
        private void displayData(string ticker, List<double> priceData)
        {
            var lineSeries = new LineSeries
            {
                Title = ticker,
                Values = new ChartValues<double>(priceData),
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 5
            };

            displayChart.Series.Clear();
            displayChart.Series.Add(lineSeries);
        }

        //sets the range for the y axis
        private void setYAxisRange(List<double> priceData)
        {
            var validPrices = priceData.Where(price => !double.IsNaN(price)).ToList();
            var minPrice = validPrices.Min();
            var maxPrice = validPrices.Max();
            displayChart.AxisY[0].MinValue = minPrice - (maxPrice - minPrice) * 0.1; // Add padding
            displayChart.AxisY[0].MaxValue = maxPrice + (maxPrice - minPrice) * 0.1; // Add padding
        }

        //sets separator for x axis
        private void setXAxisSeparator()
        {
            displayChart.AxisX[0].Separator = new LiveCharts.Wpf.Separator
            {
                Step = 1 // Controls the spacing between axis labels
            };
        }

        //updates chart with labels, separator, and range of the y axis
        private void setAxes(List<string> allDates, List<double> priceData)
        {
            displayChart.AxisX[0].Labels = allDates;
            setXAxisSeparator();
            setYAxisRange(priceData);
        }
    }
}