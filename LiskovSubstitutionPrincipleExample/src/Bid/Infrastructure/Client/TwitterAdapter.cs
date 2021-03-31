using System;
using System.Threading.Tasks;
using Newtonsoft.JsonResult;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using LiskovSubstitutionPrincipleExample.src.Bid.Domain;

namespace LiskovSubstitutionPrincipleExample.src.Bid.Infrastructure.Client
{
    public class TwitterAdapter : Adapter
    {
        static readonly HttpClient httpClient = new HttpClient();

        private BaseClient _client;

        public TwitterAdapter(BaseClient client)
        {
            _client = client;
        }
        async public Task<string> Send(Notifier notifier)
        {
            string jsonStr = "";
            try
            {

               //HttpClient client = new HttpClient();
               //client.BaseAddress = new Uri(Constants.Server);
               //client.DefaultRequestHeaders.Add("Accept", "application/json");
               //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               //
               //
               ////ResultDocumento result = new ResultDocumento();
               //
               //
               //string jsonPost = JsonConvert.SerializeObject(transaccion);
               //
               //var objectContent = new StringContent(jsonPost, Encoding.UTF8, "application/json");
               //
               //HttpResponseMessage response = new HttpResponseMessage();
               //
               //response = await client.PostAsync(Constants.Endpoint + "/Transacciones", objectContent);
                var notification = (TwitterNotifier)notifier;
                var textData = new Dictionary<string, string> { };
                string jsonPost = JsonConvert.SerializeObject(new { });
                var objectContent = new StringContent(jsonPost, Encoding.UTF8, "application/json");
                httpClient.BaseAddress = new Uri($"{ _client.BaseUrl}"); ;
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Authorization", $"OAuth oauth_consumer_key='{Uri.EscapeDataString(notification.ConsumerKey)}',oauth_token='{Uri.EscapeDataString(notification.AccessToken)}',oauth_signature_method='HMAC-SHA1',oauth_timestamp='{Uri.EscapeDataString(notification.Timestamp.ToString())}',oauth_nonce='{Uri.EscapeDataString(notification.Nonce)}',oauth_version='1.0'");
                HttpResponseMessage response = await httpClient.PostAsync($"{_client.Path}?status='Hello%20world'", objectContent);
                if (response.IsSuccessStatusCode)
                {
                    jsonStr = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(string.Format("Error into comunication to web api"));
                }
            }
            catch (HttpRequestException requestException)
            {
                Console.WriteLine($"Http request error: {requestException.StatusCode} {requestException.Message} {requestException.StackTrace}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unknow Exception error: {exception.StackTrace}  {exception.Message}");
            }
            return jsonStr;
        }
    }
}