using System;
using System.Threading.Tasks;
using Newtonsoft.JsonResult;
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
            string jsonStr  = "";
            try
            {
                var notification = (TwitterNotifier)notifier;
                var textData = new Dictionary<string, string> {
                { "status", notification.Message } };
                string jsonPost = JsonConvert.SerializeObject(new { status = "Hello World" });
                var objectContent = new StringContent(jsonPost, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("authorization", $"OAuth oauth_consumer_key={notification.ConsumerKey},oauth_token={notification.AccessToken},oauth_signature_method='HMAC-SHA1',oauth_timestamp={notification.Timestamp},oauth_nonce={notification.Nonce},oauth_version='1.0'");
                HttpResponseMessage response = await httpClient.PostAsync($"{_client.BaseUrl}/{_client.Path}?include_entities=true", new FormUrlEncodedContent(textData));
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