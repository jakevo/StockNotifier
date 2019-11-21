using System;
using StockNotifier.Domain;

namespace StockNotifier.Application
{
    public class TwilioSubcribeUseCase: IUseCase
    {
        private readonly IMessageSubscriber _subscriber;

        public TwilioSubcribeUseCase(IMessageSubscriber subscriber)
        {
            _subscriber = subscriber;
        }

        public void Execute()
        {
            try
            {
                _subscriber.Subscribe();
            }
            catch
            {
                Console.Write("Fail to subscribe.");
                throw;
            }
            
        }
    }
}
