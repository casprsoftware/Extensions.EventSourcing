using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CASPR.Extensions.EventSourcing
{
    /// <summary>
    /// Event store interface
    /// </summary>
    public interface IEventStore<in TAggregateId> 
        where TAggregateId : struct
    {
        Task AddEventAsync(
            IEvent<TAggregateId> eventObject,
            CancellationToken cancellationToken = default);

        Task AddEventAsync<TPayload>(
            IEvent<TAggregateId, TPayload> eventObject,
            CancellationToken cancellationToken = default) 
            where TPayload : class;

        Task<IEnumerable<IEvent>> GetEventsAsync(
            TAggregateId aggregateId,
            CancellationToken cancellationToken = default);
    }
}