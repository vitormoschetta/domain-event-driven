using System.Collections.Generic;

namespace Domain.Contracts
{
    public interface IHandler
    {
        IList<string> ObservedEvents { get; set; }
        void Handle(IDomainEvent @event);
    }
}