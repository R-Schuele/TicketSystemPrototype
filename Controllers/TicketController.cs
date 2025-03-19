using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //[HttpGet]
        //public async Task<ActionResult<List<Ticket>>> GetTickets()
        //{
        //    return Ok(await _ticketDbContext.Tickets.ToListAsync());
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public ActionResult<Ticket> GetTicketById(int id)
        //{
        //    var ticket = tickets.FirstOrDefault(ticket => ticket.Id == id);
        //    if (ticket is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(ticket);
        //}

        //[HttpPost]
        //public ActionResult<Ticket> AddTicket(Ticket newTicket)
        //{
        //    if (newTicket is null)
        //    {
        //        return BadRequest();
        //    }

        //    newTicket.Id = tickets.Max(ticket => ticket.Id) + 1;
        //    tickets.Add(newTicket);
        //    return CreatedAtAction(nameof(GetTicketById), new { id = newTicket.Id}, newTicket);
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateTicket(int id, Ticket updatedTicket)
        //{
        //    var ticket = tickets.FirstOrDefault(ticket => ticket.Id == id);
        //    if (ticket is null)
        //    {
        //        return NotFound();
        //    }

        //    ticket = updatedTicket;

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteTicket (int id)
        //{
        //    var ticket = tickets.FirstOrDefault(ticket => ticket.Id == id);
        //    if (ticket is null)
        //    {
        //        return NotFound();
        //    }

        //    tickets.Remove(ticket);
        //    return NoContent();
        //}
    }
}
