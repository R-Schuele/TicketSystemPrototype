using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSystemPrototype.API.Data;
using TicketSystemPrototype.Shared.Models;

namespace TicketSystemPrototype.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketDbContext _ticketDbContext;

        public TicketController(TicketDbContext ticketDbContext)
        {
            _ticketDbContext = ticketDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetTickets()
        {
            return Ok(await _ticketDbContext.Tickets.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(int id)
        {
            var ticket = await _ticketDbContext.Tickets.FindAsync(id);
            if (ticket is null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpGet]
        [Route("{id}/actionTracks")]
        public async Task<ActionResult<List<ActionTrack>>> GetActionTracksByTicketId(int id)
        {
            var actionsTracks = await _ticketDbContext.ActionTracks
                .Where(x => x.TicketId == id)
                .ToListAsync();

            if (!actionsTracks.Any())
            {
                return NotFound();
            }

            return Ok(actionsTracks);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> AddTicket(Ticket newTicket)
        {
            if (newTicket is null)
            {
                return BadRequest();
            }

            _ticketDbContext.Tickets.Add(newTicket);
            await _ticketDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTicketById), new { id = newTicket.Id }, newTicket);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Ticket>> UpdateTicket(int id, Ticket updatedTicket)
        {
            var ticket = await _ticketDbContext.Tickets.FindAsync(id);
            if (ticket is null)
            {
                return NotFound();
            }

            var changes = new List<string>();

            //Update Ticket
            if (ticket.Name != updatedTicket.Name)
            {
                ticket.Name = updatedTicket.Name;
                changes.Add($"Name changed to: {updatedTicket.Name}");
            }
            if (ticket.Description != updatedTicket.Description)
            {
                ticket.Description = updatedTicket.Description;
                changes.Add($"Description changed to: {updatedTicket.Description}");
            }
            if (ticket.Priority != updatedTicket.Priority)
            {
                ticket.Priority = updatedTicket.Priority;
                changes.Add($"Priority changed to: {updatedTicket.Priority}");
            }
            if (ticket.Status != updatedTicket.Status)
            {
                ticket.Status = updatedTicket.Status;
                changes.Add($"Status changed to: {updatedTicket.Status}");
            }
            if (ticket.AssignedTo != updatedTicket.AssignedTo)
            {
                ticket.AssignedTo = updatedTicket.AssignedTo;
                changes.Add($"AssignedTo changed to: {updatedTicket.AssignedTo}");
            }
        
            if (!changes.Any())
            {
                return Ok("No changes made");                
            }

            AddActionTrack(ticket, changes);

            await _ticketDbContext.SaveChangesAsync();

            return Ok(ticket);
        }

        private void AddActionTrack(Ticket ticket, List<string> changes)
        {
            var actionTrack = new ActionTrack
            {
                TicketId = ticket.Id,                   
                ActionDate = DateTime.Now,
                ActionBy = "InserUserName",
                Description = string.Join(", ", changes)
            };

            _ticketDbContext.ActionTracks.Add(actionTrack);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _ticketDbContext.Tickets.FindAsync(id);
            if (ticket is null)
            {
                return NotFound();
            }

            _ticketDbContext.Tickets.Remove(ticket);
            
            await _ticketDbContext.SaveChangesAsync();

            return Ok("Ticket deleted");
        }
    }
}
