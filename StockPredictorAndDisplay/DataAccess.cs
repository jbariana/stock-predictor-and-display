using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Data;
using Dapper;

namespace StockPredictorAndDisplay
{
    public class DataAccess
    {
        public static List<StockModel> LoadStocks()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StockModel>("select * from StockInfo", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<StockModel> LoadFromTicker(string ticker)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StockModel>("SELECT * FROM StockInfo WHERE ticker = @Ticker", new { Ticker = ticker });
                return output.ToList();
            }
        }

        public static List<StockModel> LoadFromTickerWithDates(string ticker, int startYear, int endYear)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                return cnn.Query<StockModel>(@"SELECT * FROM StockInfo WHERE ticker = @Ticker AND strftime('%Y', date) BETWEEN @StartYear AND @EndYear ORDER BY date", new { Ticker = ticker, StartYear = startYear.ToString(), EndYear = endYear.ToString() }).ToList();
            }
        }

        private static string LoadConnectionString(string id = "StockPortfolio")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
