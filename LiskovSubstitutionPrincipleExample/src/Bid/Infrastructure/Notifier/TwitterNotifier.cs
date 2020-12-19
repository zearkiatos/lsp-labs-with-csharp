namespace LiskovSubstitutionPrincipleExample.src.Bid.Infrastructure.Notifier
{
    public class TwitterNotifier : Notifier
    {

        TwitterNotifier(string message, string consumerKey, string consumerSecret, string accessToken, string tokenSecret) 
        {
            Message = message;
            ConsumerKey = consumerKey;
        }
        public string ConsumerKey { get; set; }

        public string ConsumerSecret { get; set; }

        public string AccessToken { get; set; }

        public string TokenSecret { get; set; }
    }
}