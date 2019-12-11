using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Web_Application_for_Claimy.EF;

namespace Web_Application_for_Claimy.Controllers
{
    public class tbl_Ticket_CaseController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/tbl_Ticket_Case
        public IQueryable<tbl_Ticket_Case> Gettbl_Ticket_Case()
        {
            return db.tbl_Ticket_Case;
        }

        // GET: api/tbl_Ticket_Case/5
        [ResponseType(typeof(tbl_Ticket_Case))]
        public async Task<IHttpActionResult> Gettbl_Ticket_Case(string id)
        {
            tbl_Ticket_Case tbl_Ticket_Case = await db.tbl_Ticket_Case.FindAsync(id);
            if (tbl_Ticket_Case == null)
            {
                return NotFound();
            }

            return Ok(tbl_Ticket_Case);
        }

        // PUT: api/tbl_Ticket_Case/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_Ticket_Case(string id, tbl_Ticket_Case tbl_Ticket_Case)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Ticket_Case.fld_Case_Ticket_ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Ticket_Case).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Ticket_CaseExists(id))
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

        // POST: api/tbl_Ticket_Case
        [ResponseType(typeof(tbl_Ticket_Case))]
        public async Task<IHttpActionResult> Posttbl_Ticket_Case(tbl_Ticket_Case tbl_Ticket_Case)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Ticket_Case.Add(tbl_Ticket_Case);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tbl_Ticket_CaseExists(tbl_Ticket_Case.fld_Case_Ticket_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_Ticket_Case.fld_Case_Ticket_ID }, tbl_Ticket_Case);
        }

        // DELETE: api/tbl_Ticket_Case/5
        [ResponseType(typeof(tbl_Ticket_Case))]
        public async Task<IHttpActionResult> Deletetbl_Ticket_Case(string id)
        {
            tbl_Ticket_Case tbl_Ticket_Case = await db.tbl_Ticket_Case.FindAsync(id);
            if (tbl_Ticket_Case == null)
            {
                return NotFound();
            }

            db.tbl_Ticket_Case.Remove(tbl_Ticket_Case);
            await db.SaveChangesAsync();

            return Ok(tbl_Ticket_Case);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_Ticket_CaseExists(string id)
        {
            return db.tbl_Ticket_Case.Count(e => e.fld_Case_Ticket_ID == id) > 0;
        }
    }
}