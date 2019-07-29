using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace SysManager.Common.Utilities
{
    /// <summary>
    /// HTTP请求帮助类
    /// </summary>
    public class HTTPHelper
    {
        private string BaseURI = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseURI">请求地址</param>
        public HTTPHelper(string baseURI)
        {
            this.BaseURI = baseURI;
        }

        #region GET调用webapi公共方法

        /// <summary>
        /// 通过GET方法调用HTTP服务
        /// </summary>
        /// <typeparam name="T">入参类型</typeparam>
        /// <param name="url">服务地址</param>
        /// <param name="requestId">发起请求的行为标识</param>
        /// <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns></returns>
        public T getContent<T>(string url, Guid requestId, int timeout = 30)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(this.BaseURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("RequestId", requestId.ToString());
                client.Timeout = new TimeSpan(0, 0, timeout);

                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var str_result = response.Content.ReadAsStringAsync().Result;
                        T result = JsonConvert.DeserializeObject<T>(str_result);
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 通过GET方法调用HTTP服务
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="requestId">发起请求的行为标识</param>
        /// <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns></returns>
        public string getContentForString(string url, Guid requestId, int timeout = 30)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(this.BaseURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("RequestId", requestId.ToString());
                client.Timeout = new TimeSpan(0, 0, timeout);

                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常,response:" + JsonConvert.SerializeObject(response));
                    }
                    else
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "},response:" + JsonConvert.SerializeObject(response));
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region POST调用webapi公共方法

        /// <summary>
        /// 通过POST方法调用HTTP服务
        /// </summary>
        /// <typeparam name="T">入参类型</typeparam>
        /// <typeparam name="T2">出参类型</typeparam>
        /// <param name="url">服务地址</param>
        /// <param name="parameter">入参</param>
        /// <param name="requestId">发起请求的行为标识</param>
        /// <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns></returns>
        public T2 postContent<T, T2>(string url, T parameter, Guid requestId, int timeout = 30)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(this.BaseURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("RequestId", requestId.ToString());
                client.Timeout = new TimeSpan(0, 0, timeout);

                string str = JsonConvert.SerializeObject(parameter);
                var httpContent = new StringContent(str, Encoding.UTF8);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                using (HttpResponseMessage response = client.PostAsync(url, httpContent).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var str_result = response.Content.ReadAsStringAsync().Result;
                        T2 result = JsonConvert.DeserializeObject<T2>(str_result);
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 通过POST方法调用HTTP服务
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="parameter">入参</param>
        /// <param name="requestId">发起请求的行为标识</param>
        /// <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns></returns>
        public string postContentForString(string url, IDictionary<string, string> parameter,
            Guid requestId, int timeout = 30)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(this.BaseURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("RequestId", requestId.ToString());
                client.Timeout = new TimeSpan(0, 0, timeout);

                string str = JsonConvert.SerializeObject(parameter);
                var httpContent = new StringContent(str, Encoding.UTF8);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                using (HttpResponseMessage response = client.PostAsync(url, httpContent).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 通过POST方法调用HTTP服务
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="parameter">入参字符串</param>
        /// <param name="requestId">发起请求的行为标识</param>
        /// <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns></returns>
        public string postContentForString(string url, string parameter,
            Guid requestId, int timeout = 30)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(this.BaseURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("RequestId", requestId.ToString());
                client.Timeout = new TimeSpan(0, 0, timeout);

                var httpContent = new StringContent(parameter, Encoding.UTF8);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                using (HttpResponseMessage response = client.PostAsync(url, httpContent).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 通过POST方法调用HTTP服务
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="parameter">入参字符串</param>
        /// <param name="requestId">发起请求的行为标识</param>
        /// <param name="token">令牌</param>
        /// <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns></returns>
        public string postContentForStringWithToken(string url, string parameter,
            Guid requestId, string token, int timeout = 30)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(this.BaseURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("RequestId", requestId.ToString());
                client.DefaultRequestHeaders.Add("Authorization", token.ToString());
                client.Timeout = new TimeSpan(0, 0, timeout);

                var httpContent = new StringContent(parameter, Encoding.UTF8);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                using (HttpResponseMessage response = client.PostAsync(url, httpContent).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region PUT调用webapi公共方法

        /// <summary>
        /// 通过PUT方法调用HTTP服务
        /// </summary>
        /// <typeparam name="T">入参类型</typeparam>
        /// <typeparam name="T2">出参类型</typeparam>
        /// <param name="url">服务地址</param>
        /// <param name="parameter">入参</param>
        /// <param name="requestId">发起请求的行为标识</param>
        /// <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns></returns>
        public T2 putContent<T, T2>(string url, T parameter, Guid requestId, int timeout = 30)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(this.BaseURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("RequestId", requestId.ToString());
                client.Timeout = new TimeSpan(0, 0, timeout);

                string str = JsonConvert.SerializeObject(parameter);
                var httpContent = new StringContent(str, Encoding.UTF8);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                using (HttpResponseMessage response = client.PutAsync(url, httpContent).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var str_result = response.Content.ReadAsStringAsync().Result;
                        T2 result = JsonConvert.DeserializeObject<T2>(str_result);
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 通过PUT方法调用HTTP服务
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="parameter">入参</param>
        /// <param name="requestId">发起请求的行为标识</param>
        /// <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns></returns>
        public string putContentForString(string url, IDictionary<string, string> parameter,
            Guid requestId, int timeout = 30)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(this.BaseURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("RequestId", requestId.ToString());
                client.Timeout = new TimeSpan(0, 0, timeout);

                string str = JsonConvert.SerializeObject(parameter);
                var httpContent = new StringContent(str, Encoding.UTF8);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                using (HttpResponseMessage response = client.PutAsync(url, httpContent).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 通过POST方法调用HTTP服务
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="parameter">入参字符串</param>
        /// <param name="requestId">发起请求的行为标识</param>
        /// <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns></returns>
        public string putContentForString(string url, string parameter,
            Guid requestId, int timeout = 30)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(this.BaseURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("RequestId", requestId.ToString());
                client.Timeout = new TimeSpan(0, 0, timeout);

                var httpContent = new StringContent(parameter, Encoding.UTF8);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                using (HttpResponseMessage response = client.PutAsync(url, httpContent).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + this.BaseURI + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
