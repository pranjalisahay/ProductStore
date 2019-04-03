using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductQueryApi.Events;

namespace ProductQueryApi.Queues
{
    public delegate void ProductAddedEventReceivedDelegate(NewProductEvent evt);

    public interface IEventSubscriber
    {
        void Subscribe();
        void Unsubscribe();

        event ProductAddedEventReceivedDelegate ProductAddedEventReceived;
    }
}
