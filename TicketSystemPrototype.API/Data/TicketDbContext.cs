using Microsoft.EntityFrameworkCore;
using TicketSystemPrototype.Shared.Models;

namespace TicketSystemPrototype.API.Data
{
    public class TicketDbContext: DbContext
    {

        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
        {
            
        }

        public DbSet<Ticket> Tickets {  get; set; }
        public DbSet<ActionTrack> ActionTracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActionTrack>()
                .HasOne<Ticket>()
                .WithMany(t => t.ActionTracks)
                .HasForeignKey(a => a.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    Id = 1,
                    Name = "Learn Blazor",
                    Description = "Read Tutorials and make a project",
                    CreatedBy = "Robin",
                    AssignedTo = "Robin",
                    CreatedAt = new DateTime(2025, 3, 20),
                    Priority = TicketPriority.High,
                    Status = TicketStatus.InProgress
                },
                new Ticket
                {
                    Id = 2,
                    Name = "Implement Entity Framework Core",
                    Description = "Download EFCore NuGet Package and configure",
                    CreatedBy = "Robin",
                    AssignedTo = "Robin",
                    CreatedAt = new DateTime(2025, 3, 20),
                    Priority = TicketPriority.Medium,
                    Status = TicketStatus.Done
                },
                new Ticket 
                {
                    Id = 3,
                    Name = "Implement SQLite Database with SQLite Browser",
                    Description = "Download SQLite Browser and open generated Datebase file",
                    CreatedBy = "Robin",
                    AssignedTo = "Robin",
                    CreatedAt = new DateTime(2025, 3, 20),
                    Priority = TicketPriority.Medium,
                    Status = TicketStatus.Open
                }
            );
        }
    }
}
