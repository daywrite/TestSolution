using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Tools
{
    /// <summary>
    /// 用于统一Web API的出错返回
    /// </summary>
    public class WebApiHttpInfo : Dictionary<string, object>
    {
        const string Key = "Message";

        public WebApiHttpInfo() { }

        public WebApiHttpInfo(string message) { this[Key] = message; }

        public WebApiHttpInfo(IEnumerable<string> messages)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string value in messages)
            {
                if (sb.Length > 0)
                    sb.Append("\r\n");
                sb.Append(value);
            }
            this[Key] = sb.ToString();
        }

        public string Message
        {
            get
            {
                if (ContainsKey(Key))
                {
                    return (string)this[Key];
                }
                return null;
            }
        }
    }
}
