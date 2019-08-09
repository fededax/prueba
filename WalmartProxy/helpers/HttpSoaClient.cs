using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WalmartProxy.Entidades;

namespace WalmartProxy.helpers
{
    public class HttpSoaClient
    {
        public string ServerUrl { get; set; }
        public string ProxyServer { get; set; }
        public bool ByPassLocalAddresses { get; set; } = true;

        public HttpSoaClient(string serverUrl)
        {
            ServerUrl = serverUrl;
        }

        private HttpClient GetClient(string token = null)
        {
            HttpClient client = new HttpClient();

            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public async Task<T> GetRequestAsync<T>(string endpoint, string token)
        {
            T result = default(T);

            try
            {
                HttpClient client = GetClient(token);

                Uri url = new Uri(ServerUrl + endpoint);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var contentJson = await response.Content.ReadAsStringAsync();

                    result = JsonConvert.DeserializeObject<T>(contentJson);
                }
                else
                {
                    throw new Exception(string.Format("Error accediendo a los servicios: {0}. Por favor verifique la documentacion. Error: {1} {2}", url?.ToString(), (int)response.StatusCode, response.ReasonPhrase));
                }
            }
            catch (Exception ee)
            {
                throw new Exception(string.Format("Error accediendo a la capa de servicios.\r\nUrl: {0}\r\n{1}\r\n{2}\r\nProxy:", ServerUrl + endpoint, ee.Message, ee.InnerException?.Message, this.ProxyServer));
            }
            return result;
        }

        public async Task<T> PostContentAsyncBase<T>(string endpoint, string token, HttpContent content = null)
        {
            T result = default(T);
            Uri url = null;

            try
            {
                HttpClient client = GetClient(token);

                url = new Uri(ServerUrl + endpoint);

                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var contentJson = await response.Content.ReadAsStringAsync();

                    result = JsonConvert.DeserializeObject<T>(contentJson);
                }
                else
                {
                    throw new Exception(string.Format("Error accediendo a los servicios: {0}. Por favor verifique la documentacion. Error: {1} {2}", url?.ToString(), (int)response.StatusCode, response.ReasonPhrase));
                }
            }
            catch (Exception ee)
            {
                throw new Exception(string.Format("Error accediendo a la capa de servicios.\r\nUrl: {0}\r\n{1}\r\n{2}\r\nProxy:", ServerUrl + endpoint, ee.Message, ee.InnerException?.Message, this.ProxyServer));
            }
            return result;
        }
    }
}
