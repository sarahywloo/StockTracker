using StockTracker.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StockTracker.Infrastructure {
    public class TransactionRespository : GenericRepository<Transaction> {

        public TransactionRespository(DbContext db) : base(db) {}


    }
}