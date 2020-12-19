using Newtonsoft;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Application.Notification
{
    public interface Notification
    {
        JsonResult Send(string message);
    }
}