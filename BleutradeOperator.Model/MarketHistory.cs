using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Model
{
    public class MarketHistory
    {
        public DateTime TimeStamp { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string OrderType { get; set; }
    }
}
