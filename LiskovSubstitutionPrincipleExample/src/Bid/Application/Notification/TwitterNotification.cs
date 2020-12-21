using Newtonsoft.JsonResult;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Application.Notification
{
        public class TwitterNotification : Notification 
        {
            public JsonResult Send(string message) 
            {
                return null;
            }
        }
}