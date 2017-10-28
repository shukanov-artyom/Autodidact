using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bot.Api.Gateway
{
    public abstract class WebServiceClientBase
    {
        private const string JsonContentType = "application/json";

        private readonly string serviceUrl;

        protected WebServiceClientBase(string serviceUrl)
        {
            this.serviceUrl = serviceUrl;
        }

        protected TResult QueryParse<TResult>(string apiAddress)
            where TResult : class
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    var awaitable = client.GetAsync(apiAddress);
                    awaitable.Wait();
                    return ParseResponse<TResult>(awaitable.Result);
                }
                catch (AggregateException ag)
                {
                    throw ag.InnerException;
                }
            }
        }

        protected async Task<TResult> QueryParseAsync<TResult>(string apiAddress)
            where TResult : class
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    var result = await client.GetAsync(apiAddress);
                    return ParseResponse<TResult>(result);
                }
                catch (AggregateException ag)
                {
                    throw ag.InnerException;
                }
            }
        }

        protected TResultId Post<TResultId>(string url, string payload)
            where TResultId : struct
        {
            using (HttpClient client = GetClient())
            {
                HttpContent httpContent = new StringContent(
                    payload,
                    Encoding.UTF8,
                    JsonContentType);
                var awaitable = client.PostAsync(url, httpContent);
                try
                {
                    awaitable.Wait();
                    return ParseResponseValue<TResultId>(awaitable.Result);
                }
                catch (AggregateException ag)
                {
                    throw ag.InnerException;
                }
            }
        }

        protected TResultId Post<TResultId>(string url, object payload)
            where TResultId : struct
        {
            using (HttpClient client = GetClient())
            {
                string payloadString = JsonConvert.SerializeObject(payload);
                HttpContent httpContent = new StringContent(
                    payloadString,
                    Encoding.UTF8,
                    JsonContentType);
                var awaitable = client.PostAsync(url, httpContent);
                try
                {
                    awaitable.Wait();
                    return ParseResponseValue<TResultId>(awaitable.Result);
                }
                catch (AggregateException ag)
                {
                    throw ag.InnerException;
                }
            }
        }

        protected void Post(string url, string payload)
        {
            using (HttpClient client = GetClient())
            {
                HttpContent httpContent = new StringContent(
                    payload,
                    Encoding.UTF8,
                    JsonContentType);
                var awaitable = client.PostAsync(url, httpContent);
                try
                {
                    awaitable.Wait();
                }
                catch (AggregateException ag)
                {
                    throw ag.InnerException;
                }
            }
        }

        protected void Post(string url, object payload)
        {
            string payloadString = JsonConvert.SerializeObject(payload);
            using (HttpClient client = GetClient())
            {
                HttpContent httpContent = new StringContent(
                    payloadString,
                    Encoding.UTF8,
                    JsonContentType);
                var awaitable = client.PostAsync(url, httpContent);
                try
                {
                    awaitable.Wait();
                }
                catch (AggregateException ag)
                {
                    throw ag.InnerException;
                }
            }
        }

        private HttpClient GetClient()
        {
            return new HttpClientFactory(serviceUrl).GetClient();
        }

        private static TResult ParseResponse<TResult>(HttpResponseMessage response)
            where TResult : class
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TResult>(resultString);
            }
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return null;
            }
            throw new InvalidOperationException("Unexpected response from API.");
        }

        private static TValueResult ParseResponseValue<TValueResult>(
            HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TValueResult>(resultString);
            }
            throw new InvalidOperationException("Unexpected response from API.");
        }
    }
}
