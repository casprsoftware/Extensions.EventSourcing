using CASPR.Extensions.EventSourcing;

namespace EventSourcingConsoleSample
{
    public class UserEnabledEvent : EventBase<int>
    {
        public UserEnabledEvent(int aggregateId, EventMetadata metadata)
            : base("UserEnabled", aggregateId, metadata)
        {
        }
    }
}