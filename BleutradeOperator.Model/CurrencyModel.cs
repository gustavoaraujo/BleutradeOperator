using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Model
{
    public class CurrencyModel
    {
        public string Currency { get; set; }
        public string CurrencyLong { get; set; }
        public int MinConfirmation { get; set; }
        public decimal TxFee { get; set; }
        public bool IsActive { get; set; }
        public string CoinType { get; set; }
        public bool MaintenanceMode { get; set; }
    }
}
