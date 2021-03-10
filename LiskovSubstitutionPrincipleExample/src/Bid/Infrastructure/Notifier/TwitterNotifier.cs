using System;
using System.Security.Cryptography;
using System.Text;
using LiskovSubstitutionPrincipleExample.src.Bid.Domain;
namespace LiskovSubstitutionPrincipleExample.src.Bid.Infrastructure
{
    public class TwitterNotifier : Notifier
    {

        public TwitterNotifier(string message, string consumerKey, string consumerSecret, string accessToken, string tokenSecret) 
        {
            _message = message;
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _accessToken = accessToken;
            _tokenSecret = tokenSecret;
            _hmacsha1 = new HMACSHA1(new ASCIIEncoding().GetBytes($"{_consumerKey}&{_accessToken}"));
            _nonce = Guid.NewGuid().ToString();
            DateTime epochUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (int)((DateTime.UtcNow - epochUtc).TotalSeconds);
            _timestamp = timestamp;
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

        private HMACSHA1 _hmacsha1;

        public HMACSHA1 Hmacsha1
        {
            get { return _hmacsha1; }
            private set { _hmacsha1 = new HMACSHA1(new ASCIIEncoding().GetBytes($"{_consumerKey}&{_accessToken}")); }
        }

        private int _timestamp;

        public int Timestamp
        {
            get { return _timestamp; }
            private set {
                DateTime epochUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var timestamp = (int)((DateTime.UtcNow - epochUtc).TotalSeconds);
                _timestamp = timestamp;
            }
        }

        private string _nonce;

        public string Nonce
        {
            get { return _nonce; }
            private set
            {
                _nonce = Guid.NewGuid().ToString();
            }
        }

    }
}