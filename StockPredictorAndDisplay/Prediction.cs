using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockPredictorAndDisplay
{
    public class Prediction
    {
        public List<double> Predict(List<string> allDates, List<double> priceData, string endOfData)
        {
            var context = new MLContext();

            // Find the index of the endOfData
            int endOfDataIndex = allDates.IndexOf(endOfData);

            // Prepare the data up until endOfData
            var data = priceData.Take(endOfDataIndex + 1)  // Include data up to endOfData
                .Select(price => new StockData { Value = (float)price }).ToList();
            var dataView = context.Data.LoadFromEnumerable(data);

            // Define the pipeline
            var pipeline = context.Forecasting.ForecastBySsa(
                outputColumnName: "Forecast",
                inputColumnName: "Value",
                windowSize: 5,
                seriesLength: 10,
                trainSize: data.Count,
                horizon: allDates.Count - (endOfDataIndex + 1)
            );

            // Train the model
            var model = pipeline.Fit(dataView);

            // Create a forecasting engine
            var forecastingEngine = model.CreateTimeSeriesEngine<StockData, PriceForecast>(context);

            // Make predictions
            var forecasts = forecastingEngine.Predict();

            // Create a list to store the final price data
            var predictedPrices = priceData.Take(endOfDataIndex + 1).ToList(); // Existing data

            //generate random object
            Random rand = new Random();

            // Add predicted values into the list
            foreach (var forecast in forecasts.Forecast)
            {
                double random = (rand.NextDouble() * 50) - 25; //generates num between -25
                predictedPrices.Add((double)forecast+(double)random);
            }

            return predictedPrices;
        }
    }

    public class StockData
    {
        [LoadColumn(0)]
        public float Value { get; set; }
    }


    public class PriceForecast
    {
        public float[] Forecast { get; set; }
    }
}
