using BleutradeOperator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;
using BleutradeOperator.Response;

namespace BleutradeOperator.Request
{
    public abstract class BaseRequest<T> where T : class
    {
        public string BaseUrl { get; set; }
        public Dictionary<string, string> Params { get; set; }
        public string Function { get; set; }

        public RestClient restClient;
        
        public abstract Response<T> GetResponse();
    }
}
