using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StockPredictorAndDisplay
{
    public class PopulateList
    {

        public static string[] Populate()
        {
            return new string[]
            {
                "Apple",
                "Microsoft",
                "Alphabet(Google)",
                "Amazon",
                "NVIDIA",
                "Taiwan Semiconductor",
                "Johnson & Johnson",
                "United HealthGroup",
                "Eli Lilly",
                "ExxonMobil",
                "NextEra Energy",
                "JPMorgan Chase",
                "Visa",
                "Blackrock",
                "Walmart",
                "Costco",
                "Proctor & Gamble",
                "Caterpillar",
                "Honeywell",
                "Salesforce",
                "ASML Holding"
            };
        }

        private static readonly Dictionary<string, string> stockNameToTicker = new Dictionary<string, string>()
        {
            { "Apple", "AAPL" },
            { "Microsoft", "MSFT" },
            { "Alphabet(Google)", "GOOGL" },
            { "Amazon","AMZN" },
            { "NVIDIA", "NVDA" },
            { "Taiwan Semiconductor", "TSM" },
            { "Johnson & Johnson", "JNJ" },
            { "United HealthGroup", "UNH" },
            { "Eli Lilly", "LLY" },
            { "ExxonMobil", "XOM" },
            { "NextEra Energy", "NEE" },
            { "JPMorgan Chase", "JPM" },
            { "Visa", "V" },
            { "Blackrock", "BLK" },
            { "Walmart", "WMT" },
            { "Costco", "COST" },
            { "Proctor & Gamble", "PG" },
            { "Caterpillar", "CAT" },
            { "Honeywell", "HON" },
            { "Salesforce", "CRM" },
            { "ASML Holding", "ASML" }

        };

        public static string GetTicker(string stockName)
        {
            if (stockNameToTicker.ContainsKey(stockName))
                return stockNameToTicker[stockName];
            return "Ticker not found";
        }
        }
}