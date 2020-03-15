using CASPR.Extensions.EventSourcing;

namespace EventSourcingConsoleSample
{
    public class UserCreatedEvent : EventBase<int, UserCreatedEventPayload>
    {
        public UserCreatedEvent(int aggregateId, EventMetadata metadata, UserCreatedEventPayload payload)
            : base("UserCreated", aggregateId, metadata, payload)
        {
        }
    }

    public class UserCreatedEventPayload
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}