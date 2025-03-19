using Microsoft.EntityFrameworkCore;
using TicketSystemPrototype.Objects;

namespace TicketSystemPrototype.Data
{
    public class TicketDbContext: DbContext
    {

        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
        {
            
        }

        public DbSet<Ticket> Tickets {  get; set; }
    }
}
