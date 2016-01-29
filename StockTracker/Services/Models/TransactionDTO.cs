using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockTracker.Services.Models {
    public class TransactionDTO {

        [Required]
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}