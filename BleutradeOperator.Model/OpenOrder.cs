using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Model
{
    public class OpenOrder
    {
        public double OrderId { get; set; }
        public string Exchange { get; set; }
        public string Type { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityRemaining { get; set; }
        public decimal QuantityBaseTraded { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public string Comments { get; set; }
    }
}
