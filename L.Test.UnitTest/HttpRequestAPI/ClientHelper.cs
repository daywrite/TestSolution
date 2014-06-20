using L.Test.Models;
using L.Test.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Globalization;
namespace L.Test.UnitTest
{
    public static class ClientHelper
    {
        private static readonly MediaTypeFormatter[] s_formatters = new MediaTypeFormatter[] { new JsonMediaTypeFormatter() };

        static readonly HttpClient s_httpClient = new HttpClient();

        public static TEntity JsonRequest<TEntity>(string strUri, EHttpMethod method, string queryCondition = "", Object objToSend = null, long tick = 0)
        {
            //请求访问的Uri
            string strToRequest = strUri;

            if (tick != 0 && (method == EHttpMethod.Put || method == EHttpMethod.Delete))
                strToRequest += "?UpdateTicks=" + tick.ToString(CultureInfo.InvariantCulture);

            if (queryCondition != null && method == EHttpMethod.Get)
                //strToRequest += queryCondition.QueryString;
                strToRequest += queryCondition;

            HttpRequestMessage requestMsg = new HttpRequestMessage();
            //向请求头增加东西
            MakePrincipleHeader(requestMsg, strToRequest);
            requestMsg.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMsg.RequestUri = new Uri(strToRequest);

            //设定请求内容
            HttpContent content = null;

            if (objToSend != null)
                content = new StringContent(JsonConvert.SerializeObject(objToSend), Encoding.UTF8, "application/json");

            switch (method)
            {
                case EHttpMethod.Post:
                    requestMsg.Method = HttpMethod.Post;
                    requestMsg.Content = content;
                    break;
                case EHttpMethod.Put:
                    requestMsg.Method = HttpMethod.Put;
                    requestMsg.Content = content;
                    break;
                case EHttpMethod.Delete:
                    requestMsg.Method = HttpMethod.Delete;
                    break;
                default: //EnuHttpMethod.Get:
                    requestMsg.Method = HttpMethod.Get;
                    break;
            }

            Task<HttpResponseMessage> rtnAll = s_httpClient.SendAsync(requestMsg);

            //执行
            HttpResponseMessage resultMessage = null;
            Task<TEntity> rtnFinal;

            try
            {
                try
                {
                    resultMessage = rtnAll.Result;
                }
                catch (AggregateException ae)
                {
                    foreach (var ex in ae.InnerExceptions)
                    {
                        if (ex is HttpRequestException)
                        {
                            throw new ClientException(Consts.ERRMSG_FAILED_TO_SEND_MESSAGE, ex);
                        }
                    }
                }

                if (!resultMessage.IsSuccessStatusCode)
                {
                    Task<WebApiHttpInfo> error;
                    try
                    {
                        error = resultMessage.Content.ReadAsAsync<WebApiHttpInfo>(s_formatters);
                    }
                    catch (Exception ex)
                    {
                        throw new ClientException(Consts.ERRMSG_SERVER_EXCEPTIONAL_FAILURE, ex);
                    }
                    throw new ClientException(error.Result.Message);
                }

                if (method != EHttpMethod.Get)
                {
                    return default(TEntity);
                }

                try
                {
                    rtnFinal = resultMessage.Content.ReadAsAsync<TEntity>(s_formatters);
                }
                catch (Exception ex)
                {
                    throw new ClientException(Consts.ERRMSG_RESULT_CONTENT_DOESNOT_MATCH, ex);
                }
            }
            catch (ClientException ex)
            {
                ex.ParameterObject = new { Uri = strUri, Method = method, Data = objToSend, Tick = tick };
                throw;
            }

            return rtnFinal.Result;
        }

        private static void MakePrincipleHeader(HttpRequestMessage reqMsg, string strUri)
        {
            //reqMsg.Headers.Add(Consts.HTTP_HEADER_AUTH_USER, UserName);
            //reqMsg.Headers.Add(Consts.HTTP_HEADER_AUTH_KEY, strTheAuthKey);
        }
    }
}
