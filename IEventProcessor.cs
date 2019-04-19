using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductQueryApi.Events
{
    public interface IEventProcessor
    {
        void Start();
        void Stop();
    }
}
