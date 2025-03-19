namespace TicketSystemPrototype.Objects
{
    public class Ticket
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string CreatedBy { get; set; }

        public string? AssingedTo { get; set; }

        public DateTime CreatedAt { get; set; }

        public TicketPriority Priority { get; set; }

        public TicketStatus Status { get; set; }
    }
}
