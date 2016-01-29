using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockTracker.Services.Models {
    public class StockDTO {
        //only include what we will display
        public string Ticker { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OpenPrice { get; set; }
    }
}