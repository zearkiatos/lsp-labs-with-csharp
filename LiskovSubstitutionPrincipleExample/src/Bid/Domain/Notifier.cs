
namespace LiskovSubstitutionPrincipleExample.src.Bid.Domain
{

    public class Notifier
    {
        protected string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        
    }

}