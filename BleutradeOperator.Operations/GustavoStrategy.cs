using BleutradeOperator.Controller;
using BleutradeOperator.Model;
using BleutradeOperator.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace BleutradeOperator.Operations
{
    public class GustavoStrategy
    {
        PrivateController PrivateController;
        PublicController PublicController;

        private Decimal LIMIT = new Decimal(0.01);

        public GustavoStrategy()
        {
            PrivateController = new PrivateController();
            PublicController = new PublicController();
        }

        public void Execute()
        {
            Dictionary<string, string> RequestParams = new Dictionary<string, string>();
            string textResult = string.Empty;

            var openOrders = PrivateController.GetOpenOrders();

            Console.WriteLine("Cancelling.");
            openOrders.Where(x => x.Type == "BUY" && x.Status == "OPEN").ToList()
                .ForEach(x => PrivateController.Cancel(x.OrderId.ToString()));

            var marketSummaries = PublicController.GetMarketSummaries();

            var marketNames = marketSummaries.Select(x => x.MarketName).ToList();

            Console.WriteLine("Getting tickers.");
            var tickers = PublicController.GetTicker(marketNames);

            var dicTickers = new List<KeyValuePair<string, Ticker>>();

            for (int i = 0; i < marketNames.Count(); i++)
                if (marketNames[i].Contains("_BTC"))
                    dicTickers.Add(new KeyValuePair<string, Ticker>(marketNames[i], tickers[i]));

            dicTickers = dicTickers.Where(x => Decimal.Compare(x.Value.Bid, new decimal(0.000001)) > 0).ToList();

            dicTickers = dicTickers.OrderByDescending(x =>
                Decimal.Divide(Decimal.Subtract(x.Value.Ask, x.Value.Bid), x.Value.Bid)).ToList();

            var balances = PrivateController.GetBalances();

            var balanceBtc = balances.Where(x => x.Currency == "BTC").First().Available;

            Console.WriteLine("Buying:");

            var buyingTickers = new List<string>();

            foreach (var dicTicker in dicTickers)
            {
                if (Decimal.Compare(balanceBtc, new decimal(0.01)) < 0)
                    break;

                var orders = PrivateController.GetOrders(dicTicker.Key, string.Empty, "BUY");

                var avg = Decimal.Divide(
                    Decimal.Add(orders.Min(x => x.Price), orders.Max(x => x.Price)), new decimal(2));

                var balance = balances.Where(
                    x => x.Currency == Regex.Match(dicTicker.Key, @".*(?=_)").Value).First();

                var balanceCoin = balance.Balance;

                balanceCoin = balanceCoin * dicTicker.Value.Bid;

                if (Decimal.Compare(balanceCoin, LIMIT) == -1 &&
                    (Decimal.Compare(dicTicker.Value.Bid, avg) == -1 || orders.Count == 0))
                {
                    var spend = Decimal.Subtract(LIMIT, balanceCoin);
                    var market = dicTicker.Key;
                    var rate = dicTicker.Value.Bid;
                    var quantity = Decimal.Divide(spend, rate);

                    RequestParams = new Dictionary<string, string>()
                    {
                        { "market", market },
                        { "rate", rate.ToString("#0.0000000").Replace(',', '.') },
                        { "quantity", quantity.ToString("#0.0000000").Replace(',', '.') },
                    };

                    if (PrivateController.Buy(RequestParams))
                        Console.WriteLine(dicTicker.Key);

                    buyingTickers.Add(dicTicker.Key);

                    balanceBtc = Decimal.Subtract(balanceBtc, spend);
                }
            }

            Console.WriteLine("Selling:");

            var coinsToSell = balances.Where(x => x.Currency != "BTC" && Decimal.Compare(x.Available, new decimal(0.00000000)) != 0);

            if (coinsToSell != null)
                foreach (var coinToSell in coinsToSell)
                {
                    var market = coinToSell.Currency + "_BTC";

                    var orders = PrivateController.GetOrders(market, string.Empty, "BUY");

                    if (orders.Count == 0)
                        continue;

                    var order = orders.OrderBy(x => x.Created).Last();

                    if (buyingTickers.Where(x => x == market).Count() == 1)
                    {
                        orders.Remove(order);
                        order = orders.OrderBy(x => x.Created).Last();
                    }

                    var rate = Decimal.Multiply(order.Price, new decimal(1.02));
                    var quantity = coinToSell.Available;

                    RequestParams = new Dictionary<string, string>()
                        {
                            { "market", market },
                            { "rate", rate.ToString("#0.00000000").Replace(',', '.') },
                            { "quantity", quantity.ToString().Replace(',', '.') },
                        };

                    if (PrivateController.Sell(RequestParams))
                        Console.WriteLine(market);
                }

            Console.WriteLine("Esperando 10 segundos");
            Thread.Sleep(10000);

            Console.Clear();
        }
    }
}
