using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPredictorAndDisplay
{
    public class UserChoice
    {
        public string StockSelected { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }

    public static class GlobalData
    {
        public static UserChoice CurrentUserChoice { get; set; } = new UserChoice();
    }
}
