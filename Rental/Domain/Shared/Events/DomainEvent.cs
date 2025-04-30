using System;

namespace MottuRental.Domain.Shared.Events
{
    public abstract class DomainEvent
    {
        public Guid Id { get; private set; }
        public DateTime Timestamp { get; private set; }
        public Guid AggregateId { get; private set; }

        protected DomainEvent(Guid aggregateId)
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;
            AggregateId = aggregateId;
        }
    }
}