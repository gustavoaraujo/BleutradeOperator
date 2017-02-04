using BleutradeOperator.Consts;
using BleutradeOperator.Model;
using BleutradeOperator.Request;
using BleutradeOperator.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Controller
{
    public class PrivateController
    {
        public bool Cancel(string orderId)
        {
            var request = new TextRequest<string>()
            {
                Function = string.Format("cancel?apikey={0}&nonce={1}&orderid={2}", UserData.API_KEY, this.GetNonce(), orderId),
            };

            return request.GetResponse().success;
        }

        public bool Buy(Dictionary<string, string> DicParams)
        {
            var strFunc = "buylimit?apikey={0}&nonce={1}&market={2}&rate={3}&quantity={4}";

            var function = string.Format(strFunc, UserData.API_KEY, this.GetNonce(), DicParams["market"], DicParams["rate"], DicParams["quantity"]);

            var request = new TextRequest<string>()
            {
                BaseUrl = "https://bleutrade.com/api/v2/market",
                Function = function
            };
            return request.GetResponse().success;
        }

        public bool Sell(Dictionary<string, string> DicParams)
        {
            var strFunc = "selllimit?apikey={0}&nonce={1}&market={2}&rate={3}&quantity={4}";

            var function = string.Format(strFunc, UserData.API_KEY, this.GetNonce(), DicParams["market"], DicParams["rate"], DicParams["quantity"]);

            var request = new TextRequest<string>()
            {
                BaseUrl = "https://bleutrade.com/api/v2/market",
                Function = function
            };
            return request.GetResponse().success;
        }

        public List<OpenOrder> GetOpenOrders()
        {
            var function = string.Format("getopenorders?apikey={0}&nonce={1}", UserData.API_KEY, this.GetNonce());

            var request = new PrivateBaseRequest<OpenOrder>()
            {
                BaseUrl = "https://bleutrade.com/api/v2/market",
                Function = function
            };
            return request.GetResponse().result;
        }

        public List<BalanceModel> GetBalances()
        {
            var function = string.Format("getbalances?apikey={0}&nonce={1}", UserData.API_KEY, this.GetNonce());

            var request = new PrivateBaseRequest<BalanceModel>()
            {
                BaseUrl = "https://bleutrade.com/api/v2/account",
                Function = function
            };

            return request.GetResponse().result;
        }

        public List<OpenOrder> GetOrders(string market = "", string orderstatus = "", string ordertype = "")
        {
            if(market == string.Empty)
                market = "ALL";

            if (orderstatus == string.Empty)
                orderstatus = "ALL";

            if (ordertype == string.Empty)
                ordertype = "ALL";

            var function = string.Format("getorders?apikey={0}&nonce={1}&market={2}&orderstatus={3}&ordertype={4}",
                UserData.API_KEY, this.GetNonce(), market, orderstatus, ordertype);

            var request = new PrivateBaseRequest<OpenOrder>()
            {
                BaseUrl = "https://bleutrade.com/api/v2/account",
                Function = function
            };

            return request.GetResponse().result;
        }

        public string GetNonce()
        {
            return DateTime.Now.Ticks.ToString();
        }
    }
}
