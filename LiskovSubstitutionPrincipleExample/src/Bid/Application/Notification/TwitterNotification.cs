using Newtonsoft.JsonResult;
using LiskovSubstitutionPrincipleExample.src.Bid.Domain;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Application.Notification
{
        public class TwitterNotification : Notification 
        {
            public JsonResult Send(Notifier notifier) 
            {
                return null;
            }
        }
}