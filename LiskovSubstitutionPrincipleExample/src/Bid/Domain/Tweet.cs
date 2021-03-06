using Newtonsoft.Json;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Domain
{

    public class Tweet
    {
        [JsonProperty("text")]
        protected string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        
    }

}