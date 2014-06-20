using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Models
{
    public static class Consts
    {
        /// <summary>
        /// 用于客户端向服务器端发送“用户名”
        /// </summary>
        public const string HTTP_HEADER_AUTH_USER = "Custom-Auth-Name";

        /// <summary>
        /// 用于客户端向服务器端发送的加密的用于验证的“Key”
        /// </summary>
        public const string HTTP_HEADER_AUTH_KEY = "Custom-Auth-Key";

        public const string ERRMSG_FAILED_TO_SEND_MESSAGE = "发送网络请求失败";
        public const string ERRMSG_SERVER_EXCEPTIONAL_FAILURE = "服务器意外错误";
        public const string ERRMSG_RESULT_CONTENT_DOESNOT_MATCH = "服务器返回与请求不匹配";
    }
}
