using System;
using Microsoft.Extensions.Configuration;

namespace StockNotifier.Infrastructure
{
    public abstract class PubSubBase
    {
        protected readonly string _sId;
        protected readonly string _authToken;

        public PubSubBase(IConfiguration configuration)
        {
            _sId = configuration["SID"];
            _authToken = configuration["Token"];
        }
    }
}
