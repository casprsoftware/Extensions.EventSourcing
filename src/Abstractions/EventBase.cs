using System;

namespace CASPR.Extensions.EventSourcing
{
    /// <summary>
    /// Base event class
    /// </summary>
    public abstract class EventBase<TAggregateId> : IEvent<TAggregateId> 
        where TAggregateId : struct
    {
        protected EventBase(
            Guid id,
            DateTime timestamp, 
            string name,
            TAggregateId aggregateId, 
            EventMetadata metadata)
        {
            AggregateId = aggregateId;
            Name = name;
            Metadata = metadata;
            Id = id;
            Timestamp = timestamp;
        }

        public EventBase(
            string name, 
            TAggregateId aggregateId, 
            EventMetadata metadata)
            : this(Guid.NewGuid(), DateTime.UtcNow, name, aggregateId, metadata)
        {
        }

        public Guid Id { get; }
        public TAggregateId AggregateId { get; }
        public string Name { get; }
        public DateTime Timestamp { get; }
        public EventMetadata Metadata { get; }
    }

    /// <summary>
    /// Base event class with payload
    /// </summary>
    /// <typeparam name="TAggregateId"></typeparam>
    /// <typeparam name="TPayload"></typeparam>
    public abstract class EventBase<TAggregateId, TPayload> : EventBase<TAggregateId>, IEvent<TAggregateId, TPayload> 
        where TPayload : class 
        where TAggregateId : struct
    {
        protected EventBase(
            Guid id, 
            DateTime timestamp, 
            string name, 
            TAggregateId aggregateId, 
            EventMetadata metadata, 
            TPayload payload) 
            : base(id, timestamp, name, aggregateId, metadata)
        {
            Payload = payload;
        }

        public EventBase(
            string name, 
            TAggregateId aggregateId, 
            EventMetadata metadata, 
            TPayload payload) 
            : base(name, aggregateId, metadata)
        {
            Payload = payload;
        }

        public TPayload Payload { get; }
    }
}
