# Stock Analyzer And Predictor

**StockAnalyzerAndPredictor** is a C# WinForms application that retrieves, manages, visualizes, and predicts stock data for 21 major companies. The application interfaces with an SQLite database to fetch stock information spanning from 2020 to 2024. It features advanced data visualization using **LiveCharts 2** and integrates **machine learning** functionality via **ML.NET** to predict stock trends.

## Features

- **Stock Data Management**: Connects to an SQLite database containing stock data of 21 major companies for the years 2020 to 2024.
- **Dynamic Data Visualization**: Utilizes **LiveCharts 2** to create interactive and real-time charts displaying stock prices and trends.
- **Machine Learning Integration**: Uses **ML.NET** to analyze stock trends and provide predictions based on historical data.
- **Intuitive Interface**: Easy-to-use WinForms interface for managing and visualizing stock data, making complex financial information accessible.

## Tech Stack

- **C#** – Main programming language
- **WinForms** – User interface framework
- **SQLite** – Database for storing stock data
- **LiveCharts 2** – Data visualization library for creating interactive charts
- **ML.NET** – Machine learning framework for stock trend predictions

## Getting Started

### Prerequisites

Before running the application, ensure you have the following installed:

- **.NET Framework 4.7.2** or higher
- **Visual Studio 2019** or higher (with WinForms and ML.NET support)
- **SQLite** (for local database)
- **LiveCharts 2** and **ML.NET** libraries (which are included in the project)

### Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/your-username/StockAnalyzerAndPredictor.git
    ```

2. **Open the project** in Visual Studio:
    - Double-click the solution file `StockAnalyzerAndPredictor.sln` to open the project.

3. **Set up the database**:
    - Ensure that the `StockPortfolio.db` SQLite file is located in the root directory of the project.
    - If you need to import data, you can do so manually via SQLite or use the application's data import functionality.

4. **Build and run**:
    - Press `Ctrl + F5` to build and run the application.
    - The application will open with a UI allowing you to visualize stock trends and perform analyses.

### Usage

- **Stock Data Visualization**: You can view interactive charts showing stock trends over time for selected companies and date ranges.
- **Machine Learning Predictions**: The app uses **ML.NET** to predict future stock trends based on historical data.
  
### Example Usage:

1. Launch the application.
2. Select a company ticker (e.g., "AAPL" for Apple).
3. Choose a date range (e.g., 2020-2024).
4. View the stock chart generated in real-time, with stock prices plotted on the graph.
5. Optionally, use machine learning-based predictions to forecast future stock behavior.

## Folder Structure

/StockAnalyzerAndPredictor
- /CSV                   # Contains the CSV file with stock data
- /packages              # NuGet packages for project dependencies
- /StockPredictorAndDisplay  # Source code for the application
- /StockPortfolio.db     # SQLite database containing stock data
- /StockPredictorAndDisplay.sln  # Solution file for the project
- ...                  # Other project-related files (e.g., .gitignore, README)

## Troubleshooting

- **"No such table: StockInfo" error**:
  Ensure that the `StockPortfolio.db` SQLite database is properly set up and contains the `StockInfo` table with data.

- **Missing Chart Data**:
  If no data appears on the chart, make sure the date range and ticker symbol are correctly entered, and that the database contains data for the specified criteria.

