using BleutradeOperator.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BleutradeOperator.Request
{
    public class PrivateBaseRequest<T> : BaseRequest<T> where T : class
    {
        public override Response<T> GetResponse()
        {
            restClient = new RestClient(BaseUrl);
            var request = new RestRequest(Function, Method.GET)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; },
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("apisign", new ApiSign().GetApiSign(this.BaseUrl, this.Function));

            IRestResponse<Response<T>> response = restClient.Execute<Response<T>>(request);

            return response.Data;
        }
    }
}