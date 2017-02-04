using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Request
{
    public class RequestConfig<T> where T : class
    {
        public void ConfigureRequest(BaseRequest<T> baseRequest, RestRequest request)
        {
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.RequestFormat = DataFormat.Json;
            if (baseRequest.Params != null && baseRequest.Params.Count > 0)
                baseRequest.Params.ToList().ForEach(x => request.AddParameter(x.Key, x.Value));
        }
    }
}
