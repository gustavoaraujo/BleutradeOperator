using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Model
{
    public class OrderBook
    {
        public List<Order> buy { get; set; }
        public List<Order> sell { get; set; }
    }
}
