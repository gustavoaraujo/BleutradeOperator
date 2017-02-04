using BleutradeOperator.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Request
{
    public class TextRequest<T> : BaseRequest<T> where T : class
    {
        public override Response<T> GetResponse()
        {
            this.BaseUrl = "https://bleutrade.com/api/v2/market";
            restClient = new RestClient(BaseUrl);
            var request = new RestRequest(Function, Method.POST);
            //request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            //request.RequestFormat = DataFormat.Json;

            //if (this.Params != null && this.Params.Count > 0)
            //    this.Params.ToList().ForEach(x => request.AddParameter(x.Key, x.Value));
            
            new RequestConfig<T>().ConfigureRequest(this, request);

            request.AddHeader("apisign", new ApiSign().GetApiSign(this.BaseUrl, this.Function));

            IRestResponse<Response<T>> response = restClient.Execute<Response<T>>(request);

            return response.Data;
        }
    }
}
