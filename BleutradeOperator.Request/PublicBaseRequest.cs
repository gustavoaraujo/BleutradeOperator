using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BleutradeOperator.Response;
using RestSharp;

namespace BleutradeOperator.Request
{
    public class PublicBaseRequest<T> : BaseRequest<T> where T : class
    {
        public override Response<T> GetResponse()
        {
            this.BaseUrl = "https://bleutrade.com/api/v2/public";
            restClient = new RestClient(BaseUrl);

            var request = new RestRequest(Function, Method.GET);
            //request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            //request.RequestFormat = DataFormat.Json;

            //if (this.Params != null && this.Params.Count > 0)
            //    this.Params.ToList().ForEach(x => request.AddParameter(x.Key, x.Value));

            new RequestConfig<T>().ConfigureRequest(this, request);

            IRestResponse<Response<T>> response = restClient.Execute<Response<T>>(request);

            return response.Data;
        }
    }
}