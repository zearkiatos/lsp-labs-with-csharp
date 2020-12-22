using Newtonsoft.JsonResult;
using LiskovSubstitutionPrincipleExample.src.Bid.Domain;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Application.Notification
{
    interface Notification
    {
        JsonResult Send(Notifier notifier);
    }
}