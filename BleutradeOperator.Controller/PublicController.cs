using BleutradeOperator.Request;
using BleutradeOperator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Public
{
    public class PublicController
    {
        public List<Candle> GetCandles(Dictionary<string,string> RequestParams)
        {
            var request = new PublicBaseRequest<Candle>()
            {
                Function = "getcandles",
                Params = RequestParams
            };

            return request.GetResponse().result;
        }

        public List<CurrencyModel> GetCurrencies()
        {
            var request = new PublicBaseRequest<CurrencyModel>()
            {
                Function = "getcurrencies"
            };

            return request.GetResponse().result;
        }

        public List<Market> GetMarkets()
        {
            var request = new PublicBaseRequest<Market>()
            {
                Function = "getmarkets"
            };

            return request.GetResponse().result;
        }

        public List<MarketHistory> GetMarketHistory(Dictionary<string, string> RequestParams)
        {
            var request = new PublicBaseRequest<MarketHistory>()
            {
                Function = "getmarkethistory",
                Params = RequestParams
            };

            return request.GetResponse().result;
        }

        public List<MarketSummary> GetMarketSummary(Dictionary<string, string> RequestParams)
        {
            var request = new PublicBaseRequest<MarketSummary>()
            {
                Function = "getmarketsummary",
                Params = RequestParams
            };

            return request.GetResponse().result;
        }

        public List<MarketSummary> GetMarketSummaries()
        {
            var request = new PublicBaseRequest<MarketSummary>()
            {
                Function = "getmarketsummaries"
            };

            return request.GetResponse().result;
        }

        public List<OrderBook> GetOrderBook()
        {
            var request = new PublicBaseRequest<OrderBook>()
            {
                Function = "getorderbook"
            };

            return request.GetResponse().result;
        }

        public List<Ticker> GetTicker(List<string> RequestParams)
        {
            var marketValue = string.Empty;

            RequestParams.ForEach(x => 
            {
                marketValue = string.Format("{0}{1}", marketValue, x);

                if (x != RequestParams.Last())
                    marketValue = string.Format("{0},", marketValue);
            });

            var request = new PublicBaseRequest<Ticker>()
            {
                Function = string.Format("getticker?market={0}", marketValue)
            };

            return request.GetResponse().result;
        }
    }
}
