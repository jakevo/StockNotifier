using System;
using Newtonsoft.Json;

namespace StockNotifier.Infrastructure
{
    public class TwilioAuthenticationModel
    {
        [JsonProperty("AccountSid")]
        public string SID { set; get; }

        [JsonProperty("AuthToken")]
        public string AuthToken { set; get; }

        public TwilioAuthenticationModel(string id, string token)
        {
            SID = id;
            AuthToken = token;
        }
    }
}
