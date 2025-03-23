namespace TicketSystemPrototype.Objects
{
    public class ActionTrack
    {
        public int Id { get; set; }

        public required int TicketId { get; set; }

        public DateTime ActionDate { get; set; } = DateTime.UtcNow;

        public required string ActionBy { get; set; }

        public required string Description { get; set; }
    }
}