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
                string jsonPost = JsonConvert.SerializeObject("");
                var objectContent = new StringContent(jsonPost, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Authorization", $"OAuth oauth_consumer_key={notification.ConsumerKey},oauth_token={notification.AccessToken},oauth_signature_method='HMAC-SHA1',oauth_version='1.0'");
                HttpResponseMessage response = await httpClient.PostAsync($"{_client.BaseUrl}/{_client.Path}?status={notifier.Message}",objectContent);
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