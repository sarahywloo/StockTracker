using StockTracker.Services;
using StockTracker.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StockTracker.Presentation.Controllers
{
    public class StocksController : ApiController {

        private StockService _stockService;

        //StocksController depends on the StocksService
        public StocksController(StockService stockService) {
            _stockService = stockService;
        }

        [HttpGet]
        //{} is the route parameter
        [Route("api/stocks/search/{searchTerms}")]
        public IList<StockDTO> Search(string searchTerms) {
            return _stockService.Search(searchTerms);
        }

        [HttpGet]
        [Route("api/stocks/{ticker}")]
        public ExpandedStockDTO GetStock(string ticker) {
            return _stockService.GetStockWithTransactions(ticker, User.Identity.Name);
        }

        [HttpPost]
        [Authorize]
        [Route("api/trade/buy")]
        //Changed Transaction DTO to IHttpActionResult here
        public IHttpActionResult Buy(TransactionDTO transaction) {

            if (ModelState.IsValid && _stockService.CheckExists(transaction.Ticker)) {
                return Ok(_stockService.Buy(transaction.Ticker, transaction.Quantity, User.Identity.Name));
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        [Route("api/trade/sell")]
        public IHttpActionResult Sell(TransactionDTO transaction) {
            if (ModelState.IsValid && _stockService.CheckExists(transaction.Ticker)) {
                return Ok(_stockService.Sell(transaction.Ticker, transaction.Quantity, User.Identity.Name));
            }
            return BadRequest();
        }
    }
}
