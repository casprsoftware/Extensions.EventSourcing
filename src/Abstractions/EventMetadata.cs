namespace CASPR.Extensions.EventSourcing
{
    /// <summary>
    /// Event metadata
    /// </summary>
    public class EventMetadata
    {
        public EventMetadata(string userId)
        {
            UserId = userId;
        }
        
        public string UserId { get; }
    }
}