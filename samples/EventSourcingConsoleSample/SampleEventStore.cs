using CASPR.Extensions.EventSourcing;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EventSourcingConsoleSample
{
    class SampleEventStore : IEventStore<int>
    {
        private readonly List<IEvent> _events = new List<IEvent>();

        public Task AddEventAsync(IEvent<int> eventObject, CancellationToken cancellationToken = default)
        {
            _events.Add(eventObject);
            return Task.CompletedTask;
        }

        public Task AddEventAsync<TPayload>(IEvent<int, TPayload> eventObject, CancellationToken cancellationToken = default) where TPayload : class
        {

            _events.Add(eventObject);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<IEvent>> GetEventsAsync(int aggregateId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<IEvent>>(_events);
        }
    }
}
