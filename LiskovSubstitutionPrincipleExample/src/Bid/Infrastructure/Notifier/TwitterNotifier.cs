using LiskovSubstitutionPrincipleExample.src.Bid.Domain;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Infrastructure
{
    public class TwitterNotifier : Notifier
    {

        TwitterNotifier(string message, string consumerKey, string consumerSecret, string accessToken, string tokenSecret) 
        {
            _message = message;
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _accessToken = accessToken;
            _tokenSecret = tokenSecret;
        }

        private string _consumerKey;
        public string ConsumerKey
        {
            get { return _consumerKey; }
            set { _consumerKey = value; }
        }

        private string _consumerSecret;
        public string ConsumerSecret
        {
            get { return _consumerSecret; }
            set { _consumerSecret = value; }
        }

        private string _accessToken;
        public string AccessToken
        {
            get { return _accessToken; }
            set { _accessToken = value; }
        }

        private string _tokenSecret;
        public string TokenSecret
        {
            get { return _tokenSecret; }
            set { _tokenSecret = value; }
        }
        
    }
}