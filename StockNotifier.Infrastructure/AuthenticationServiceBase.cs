using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StockNotifier.Domain;
using HttpClient = System.Net.Http.HttpClient;

namespace StockNotifier.Infrastructure
{
    public class AuthenticationServiceBase: PubSubBase
    {
        protected HttpClient HttpClient { get; }

        public AuthenticationServiceBase( IConfiguration configuration) : base(configuration)
        {
        }

        //public async Task<string> Authenticate(TwilioAuthenticationModel request)
        //{
        //    var requestMessage = new HttpRequestMessage
        //    {
        //       Method = System.Net.Http.HttpMethod.Post,
        //       Content = new StringContent(JsonConvert.SerializeObject(request),Encoding.UTF8, "application/json"),
        //       RequestUri = new Uri( new Uri($"https://{request.SID}:{request.AuthToken}@api.twilio.com/2010-04-01/"), "Accounts")

        //    };

        //    var response = await HttpClient.SendAsync(requestMessage);
        //    response.EnsureSuccessStatusCode();
        //    return response.StatusCode.ToString();
        //}

        public void Subscribe()
        {
            var request = new TwilioAuthenticationModel(_sId, _authToken);

            var requestMessage = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"),
                RequestUri = new Uri(new Uri($"https://{request.SID}:{request.AuthToken}@api.twilio.com/2010-04-01/"), "Accounts")

            };
            try
            {
                var response = HttpClient.SendAsync(requestMessage);
                Console.WriteLine("Successfull Authorization");
            }
            catch
            {
                Console.WriteLine("Cann't connect to Twilio");
            }

            
        }
    }
}
