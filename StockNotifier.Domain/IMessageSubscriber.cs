using System;
namespace StockNotifier.Domain
{
    public interface IMessageSubscriber
    {
        void Subscribe();
    }
}
