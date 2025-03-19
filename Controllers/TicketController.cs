using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TicketSystemPrototype.Data;
using TicketSystemPrototype.Objects;

namespace TicketSystemPrototype.Controllers
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, Ticket updatedTicket)
        {
            var ticket = await _ticketDbContext.Tickets.FindAsync(id);
            if (ticket is null)
            {
                return NotFound();
            }

            ticket = updatedTicket;

            await _ticketDbContext.SaveChangesAsync();

            return NoContent();
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

            return NoContent();
        }
    }
}
