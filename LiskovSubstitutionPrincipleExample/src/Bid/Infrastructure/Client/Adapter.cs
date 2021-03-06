using System.Threading.Tasks;
using LiskovSubstitutionPrincipleExample.src.Bid.Domain;

namespace LiskovSubstitutionPrincipleExample.src.Bid.Infrastructure.Client
{
    interface Adapter
    {
        Task<string> Send(Notifier notifier);
    }
}