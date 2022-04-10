using System.Collections.Generic;
using System.Linq;
using Domain.Contracts;

namespace Application.Mediator
{
    public class MyMediator
    {
        private readonly List<IHandler> _handlers;

        public MyMediator()
        {
            _handlers = new List<IHandler>();
        }

        public void RegisterHandler(IHandler handler)
        {
            _handlers.Add(handler);
        }

        public void RegisterHandler(List<IHandler> handlers)
        {
            _handlers.AddRange(handlers);
        }

        public void Send(IDomainEvent @event)
        {
            foreach (var handler in _handlers.Where(x => x.ObservedEvents.Contains(@event.GetType().Name)))
            {
                handler.Handle(@event);
            }
        }
    }
}