using BleutradeOperator.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategy = new GustavoStrategy();

            while (true)
            {
                try
                {
                    strategy.Execute();
                }
                catch (Exception)
                {
                }
            }
            
        }
    }
}
