using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Web_Application_for_Claimy.Models;

namespace Web_Application_for_Claimy.Controllers
{
    public class TicketTablesController : ApiController
    {
        private Web_Application_for_ClaimyContext db = new Web_Application_for_ClaimyContext();

        // GET: api/TicketTables
        public IQueryable<TicketTable> GetTicketTables()
        {
            return db.TicketTables;
        }

        // GET: api/TicketTables/5
        [ResponseType(typeof(TicketTable))]
        public async Task<IHttpActionResult> GetTicketTable(string id)
        {
            TicketTable ticketTable = await db.TicketTables.FindAsync(id);
            if (ticketTable == null)
            {
                return NotFound();
            }

            return Ok(ticketTable);
        }

        // PUT: api/TicketTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTicketTable(string id, TicketTable ticketTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketTable.ID)
            {
                return BadRequest();
            }

            db.Entry(ticketTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TicketTables
        [ResponseType(typeof(TicketTable))]
        public async Task<IHttpActionResult> PostTicketTable(TicketTable ticketTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TicketTables.Add(ticketTable);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TicketTableExists(ticketTable.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ticketTable.ID }, ticketTable);
        }

        // DELETE: api/TicketTables/5
        [ResponseType(typeof(TicketTable))]
        public async Task<IHttpActionResult> DeleteTicketTable(string id)
        {
            TicketTable ticketTable = await db.TicketTables.FindAsync(id);
            if (ticketTable == null)
            {
                return NotFound();
            }

            db.TicketTables.Remove(ticketTable);
            await db.SaveChangesAsync();

            return Ok(ticketTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketTableExists(string id)
        {
            return db.TicketTables.Count(e => e.ID == id) > 0;
        }
    }
}