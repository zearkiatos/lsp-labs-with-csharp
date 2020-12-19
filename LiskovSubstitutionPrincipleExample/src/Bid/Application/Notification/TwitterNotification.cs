using Newtonsoft;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Application.Notification
{
        public class TwitterNotification : Notification 
        {
            JsonResult Send(string message) {
                
                return Json();
            }
        }
}