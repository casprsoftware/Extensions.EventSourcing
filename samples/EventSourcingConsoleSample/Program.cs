using System;
using System.Linq;
using System.Threading.Tasks;
using CASPR.Extensions.EventSourcing;
using Newtonsoft.Json;

namespace EventSourcingConsoleSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var eventStore = new SampleEventStore();
            var userCreatedEvent = new UserCreatedEvent(1, new EventMetadata("123"), new UserCreatedEventPayload
            {
                Name = "user_one",
                Email = "user@one.com"
            });
            
            await eventStore.AddEventAsync(userCreatedEvent);

            var userEnabled = new UserEnabledEvent(1, new EventMetadata("123"));
            await eventStore.AddEventAsync(userEnabled);
           
            // get events
            var events = await eventStore.GetEventsAsync(1);
            Console.WriteLine();
            Console.WriteLine("Events ({0})", events.Count());
            Console.WriteLine();
            foreach (var @event in events)
            {
                Console.WriteLine("Name: {0}", @event.Name);
                Console.WriteLine("ID: {0}", @event.Id);
                Console.WriteLine("Timestamp: {0}", @event.Timestamp);
                Console.WriteLine("Metadata: {0}", JsonConvert.SerializeObject(@event.Metadata));
                if (@event is IEvent<int> eventWithAggregateId)
                {
                    Console.WriteLine("Aggregate ID: {0}", eventWithAggregateId.AggregateId);
                }
                if (@event is IEvent<int, object> testWithPayloadEvent)
                {
                    Console.WriteLine("Payload: {0}", JsonConvert.SerializeObject(testWithPayloadEvent.Payload));
                }
                Console.WriteLine("-----------------------------------");
            }
            Console.Read();
        }
    }

    internal class TestPayload
    {
        public string SomeValue { get; set; }
    }
}
