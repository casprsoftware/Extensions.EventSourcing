using System;

namespace CASPR.Extensions.EventSourcing
{
    public interface IEvent
    {
        Guid Id { get; }
        string Name { get; }
        DateTime Timestamp { get; }
        EventMetadata Metadata { get; }
    }

    public interface IEvent<out TAggregateId> : IEvent 
        where TAggregateId : struct
    {
        TAggregateId AggregateId { get; }
    }

    public interface IEvent<out TAggregateId, out TPayload> : IEvent<TAggregateId> 
        where TPayload : class 
        where TAggregateId : struct
    {
        TPayload Payload { get; }
    }
}