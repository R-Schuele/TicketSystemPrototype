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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    Id = 1,
                    Name = "Learn Blazor",
                    Description = "Read Tutorials and make a project",
                    CreatedBy = "Robin",
                    AssingedTo = "Robin",
                    CreatedAt = DateTime.Now.Date,
                    Priority = TicketPriority.High,
                    Status = TicketStatus.InProgress
                },
                new Ticket
                {
                    Id = 2,
                    Name = "Implement Entity Framework Core",
                    Description = "Download EFCore NuGet Package and configure",
                    CreatedBy = "Robin",
                    AssingedTo = "Robin",
                    CreatedAt = DateTime.Now.Date,
                    Priority = TicketPriority.Medium,
                    Status = TicketStatus.Done
                },
                new Ticket 
                {
                    Id = 3,
                    Name = "Implement SQLite Database with SQLite Browser",
                    Description = "Download SQLite Browser and open generated Datebase file",
                    CreatedBy = "Robin",
                    AssingedTo = "Robin",
                    CreatedAt = DateTime.Now.Date,
                    Priority = TicketPriority.Medium,
                    Status = TicketStatus.Open
                }
            );
        }
    }
}
