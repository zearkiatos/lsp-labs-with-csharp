using Newtonsoft.Json;
using Newtonsoft.JsonResult;
using System.Threading.Tasks;
using LiskovSubstitutionPrincipleExample.src.Bid.Domain;
using LiskovSubstitutionPrincipleExample.src.Bid.Infrastructure.Client;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Application.Notification
{
        public class TwitterNotification : Notification 
        {
            public JsonResult Send(Notifier notifier) 
            {
                var baseClient = new BaseClient();
                baseClient.BaseUrl = "https://api.twitter.com";
                baseClient.Path = "1.1/statuses/update.json";
                var twitterAdapter = new TwitterAdapter(baseClient);
                var notificationResponse = Task.Run(() => twitterAdapter.Send(notifier)).Result;
                var result = new JsonResult{
                    Data = JsonConvert.DeserializeObject(notificationResponse)
                };
                return result;
            }
        }
}