using Microsoft.AspNetCore.Mvc;
using TicketSystemPrototype.Objects;

namespace TicketSystemPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        static private List<Ticket> tickets = new List<Ticket>
        {
            new Ticket
            {
                Id = 1,
                Name = "Issue01",
                Description = "Test Ticket",
                CreatedBy = "Robin",
                AssingedTo = "Robin",
                CreatedAt = DateTime.Now,
                Priority = TicketPriority.Low,
                Status = TicketStatus.Open
            },
            new Ticket
            {
                Id = 2,
                Name = "Issue02",
                Description = "Test Ticket",
                CreatedBy = "Robin",
                AssingedTo = "Robin",
                CreatedAt = DateTime.Now,
                Priority = TicketPriority.Low,
                Status = TicketStatus.Open
            }
        };

        [HttpGet]
        public ActionResult<List<Ticket>> GetTickets()
        {
            return Ok(tickets);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Ticket> GetTicketById(int id)
        {
            var ticket = tickets.FirstOrDefault(ticket => ticket.Id == id);
            if (ticket is null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPost]
        public ActionResult<Ticket> AddTicket(Ticket newTicket)
        {
            if (newTicket is null)
            {
                return BadRequest();
            }

            newTicket.Id = tickets.Max(ticket => ticket.Id) + 1;
            tickets.Add(newTicket);
            return CreatedAtAction(nameof(GetTicketById), new { id = newTicket.Id}, newTicket);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTicket(int id, Ticket updatedTicket)
        {
            var ticket = tickets.FirstOrDefault(ticket => ticket.Id == id);
            if (ticket is null)
            {
                return NotFound();
            }

            ticket = updatedTicket;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket (int id)
        {
            var ticket = tickets.FirstOrDefault(ticket => ticket.Id == id);
            if (ticket is null)
            {
                return NotFound();
            }

            tickets.Remove(ticket);
            return NoContent();
        }
    }
}
