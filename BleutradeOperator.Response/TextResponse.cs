using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Response
{
    public class TextResponse<T> : BaseResponse<T> where T : class
    {
        public string result { get; set; }
    }
}
