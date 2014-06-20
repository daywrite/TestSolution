using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Tools
{
    /// <summary>
    /// 用于客户端或局部的异常
    /// </summary>
    public class ClientException : Exception
    {
        public ClientException() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">对用户的信息</param>
        public ClientException(string message) : base(message) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">对用户的信息</param>
        /// <param name="inner">系统异常（用于记录）</param>
        public ClientException(string message, Exception inner) : base(message, inner) { }

        public Object ParameterObject { get; set; }
    }
}
