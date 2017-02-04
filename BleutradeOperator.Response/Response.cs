using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Response
{
    public class Response<T> : BaseResponse<T> where T : class
    {
        public List<T> result { get; set; }
    }
}
