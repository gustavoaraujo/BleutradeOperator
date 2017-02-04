using BleutradeOperator.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BleutradeOperator.Request
{
    public class ApiSign
    {
        public string GetApiSign(string baseUrl, string function)
        {
            Encoding encoding = Encoding.UTF8;
            using (HMACSHA512 hmac = new HMACSHA512(encoding.GetBytes(UserData.API_SECRET)))
            {
                var msg = encoding.GetBytes(string.Format("{0}/{1}", baseUrl, function));
                var hash = hmac.ComputeHash(msg);
                return BitConverter.ToString(hash).ToLower().Replace("-", string.Empty);
            }
        }
    }
}
