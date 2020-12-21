using Newtonsoft.JsonResult;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Application.Notification
{
    interface Notification
    {
        JsonResult Send(string message);
    }
}