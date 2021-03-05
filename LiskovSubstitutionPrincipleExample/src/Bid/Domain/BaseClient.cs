
namespace LiskovSubstitutionPrincipleExample.src.Bid.Domain
{

    public class BaseClient
    {
        protected string _baseUrl;
        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        protected string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        
        
        
    }

}