using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace StockPredictorAndDisplay
{
    public partial class StockWindow : Form
    {
        private static List<string> yearLabels = new List<string>();
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
                Labels = yearLabels
            });

            displayChart.AxisY.Add(new Axis
            {
                Title = "Average Price",
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

            //makes a prediction and updates the priceData list
            Prediction prediction = new Prediction();
            priceData = prediction.Predict(allDates, priceData, "2024-12-29");

            // Updates the X axis labels and updates separator property for spacing, also sets Y-axis range based on stock data
            setAxes(allDates, priceData);

            // adds lines for each of the years
            AddYearlyLines(allDates);

            // Add stock data series to the chart
            displayData(ticker, priceData);

            //adds a line for when the data ends and prediction begins
            addEndOfDataLine(allDates);

            // Force chart to refresh
            displayChart.Refresh();
        }


        //returns a dictionary with the date and average prices for that date
        public Dictionary<string, double> GetPriceDictionary(List<StockModel> stockData)
        {
            return stockData
                .ToDictionary(
                    s => DateTime.Parse(s.Date).ToString("yyyy-MM-dd"),
                    s =>
                    {
                        if (double.TryParse(s.High, out var high) &&
                            double.TryParse(s.Low, out var low) &&
                            double.TryParse(s.Open, out var open) &&
                            double.TryParse(s.Close, out var close))
                        {
                            return (high + low + open + close) / 4.0; // Calculate average
                        }
                        return double.NaN; // Return NaN if any value is invalid
                    }
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

                createPredictionLineLegend();

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
            // Only show labels for distinct years or another interval
            var distinctYears = allDates
                .Select(date => DateTime.Parse(date).Year)
                .Distinct()
                .ToList();

            // Set labels to be one per year
            yearLabels = distinctYears
                .Select(year => year.ToString())
                .ToList();

            // Set the labels on the X-axis
            displayChart.AxisX[0].Labels = yearLabels;

            // Adjust separator and Y-axis range as before
            setXAxisSeparator();
            setYAxisRange(priceData);
        }



        //adds a legend item for when the predicton starts
        public void createPredictionLineLegend()
        {
            var predictionLineLegend = new LineSeries
            {
                Title = "Where prediction starts",
                Stroke = System.Windows.Media.Brushes.Red,
                StrokeThickness = 2,
                Values = new ChartValues<double> { double.NaN }, // No actual data
                PointGeometry = null, // No points
                StrokeDashArray = new System.Windows.Media.DoubleCollection { 4 } // Dashed line
            };

            displayChart.Series.Add(predictionLineLegend);
        }


        //adds lines for each year and updates legend
        private void AddYearlyLines(List<string> allDates)
        {
            // Define the date format
            string dateFormat = "yyyy-MM-dd";

            // Ensure the Labels list is initialized with placeholders
            if (yearLabels == null || yearLabels.Count == 0)
            {
                yearLabels = new List<string>(new string[allDates.Count]);
            }

            // Clear existing year labels
            yearLabels.Clear();

            // Initialize yearLabels with empty values (to ensure labels exist for all dates)
            yearLabels.AddRange(Enumerable.Repeat<string>(string.Empty, allDates.Count));

            // Extract unique years from the list of dates
            var years = allDates
                .Select(date =>
                {
                    if (DateTime.TryParseExact(date, dateFormat, System.Globalization.CultureInfo.InvariantCulture,
                                               System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                    {
                        return parsedDate.Year;
                    }
                    else
                    {
                        return (int?)null; // Return null for invalid dates
                    }
                })
                .Where(year => year.HasValue) // Exclude null values
                .Select(year => year.Value) // Get the non-null year values
                .Distinct()
                .OrderBy(year => year)
                .ToList();

            // Loop over the unique years and add vertical lines
            foreach (var year in years)
            {
                // Find the first index of the year in the list of dates
                var firstDateOfYear = allDates.FindIndex(date =>
                    DateTime.TryParseExact(date, dateFormat, System.Globalization.CultureInfo.InvariantCulture,
                                           System.Globalization.DateTimeStyles.None, out DateTime parsedDate) &&
                    parsedDate.Year == year);

                if (firstDateOfYear != -1)
                {
                    // Add a vertical line at the start of each year
                    var verticalLine = new LiveCharts.Wpf.AxisSection
                    {
                        Value = firstDateOfYear, // Position of the year on the X-axis
                        Stroke = System.Windows.Media.Brushes.Gray, // Line color
                        StrokeThickness = 1,
                        StrokeDashArray = new System.Windows.Media.DoubleCollection { 2, 2 }, // Dashed line
                        SectionWidth = 0 // Ensures it appears as a single line
                    };

                    displayChart.AxisX[0].Sections.Add(verticalLine);

                    // Add the year as a label on the X-axis (only once per year)
                    if (firstDateOfYear < yearLabels.Count)
                    {
                        yearLabels[firstDateOfYear] = year.ToString();
                    }
                }
            }

            // Remove excess labels (only keep one label per year)
            yearLabels = yearLabels
                .Select((label, index) => index % (allDates.Count / years.Count) == 0 ? label : string.Empty)
                .ToList();

            // Ensure the chart updates after modifying the labels
            displayChart.Refresh();
        }
    }
}