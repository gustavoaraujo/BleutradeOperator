using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Model
{
    public class MarketSummary
    {
        public string MarketName { get; set; }
        public decimal PrevDay { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Last { get; set; }
        public decimal Average { get; set; }
        public decimal Volume { get; set; }
        public decimal BaseVolume { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public bool IsActive { get; set; }
    }
}
