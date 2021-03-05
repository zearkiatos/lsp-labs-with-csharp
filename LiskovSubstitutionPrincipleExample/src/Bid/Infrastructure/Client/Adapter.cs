using Newtonsoft.JsonResult;
using LiskovSubstitutionPrincipleExample.src.Bid.Domain;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Infrastructure.Client
{
    interface Adapter
    {
        JsonResult Send(BaseClient client);
    }
}