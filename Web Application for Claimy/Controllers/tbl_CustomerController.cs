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
    public class tbl_CustomerController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/tbl_Customer
        public IQueryable<tbl_Customer> Gettbl_Customer()
        {
            return db.tbl_Customer;
        }

        // GET: api/tbl_Customer/5
        [ResponseType(typeof(tbl_Customer))]
        public async Task<IHttpActionResult> Gettbl_Customer(string id)
        {
            tbl_Customer tbl_Customer = await db.tbl_Customer.FindAsync(id);
            if (tbl_Customer == null)
            {
                return NotFound();
            }

            Console.WriteLine(tbl_Customer.fld_Email);
            return Ok(tbl_Customer);
        }

        // PUT: api/tbl_Customer/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_Customer(string id, tbl_Customer tbl_Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Customer.fld_Email)
            {
                return BadRequest();
            }

            db.Entry(tbl_Customer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_CustomerExists(id))
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

        // POST: api/tbl_Customer
        [ResponseType(typeof(tbl_Customer))]
        public async Task<IHttpActionResult> Posttbl_Customer(tbl_Customer tbl_Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Customer.Add(tbl_Customer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tbl_CustomerExists(tbl_Customer.fld_Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_Customer.fld_Email }, tbl_Customer);
        }

        // DELETE: api/tbl_Customer/5
        [ResponseType(typeof(tbl_Customer))]
        public async Task<IHttpActionResult> Deletetbl_Customer(string id)
        {
            tbl_Customer tbl_Customer = await db.tbl_Customer.FindAsync(id);
            if (tbl_Customer == null)
            {
                return NotFound();
            }

            db.tbl_Customer.Remove(tbl_Customer);
            await db.SaveChangesAsync();

            return Ok(tbl_Customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_CustomerExists(string id)
        {
            return db.tbl_Customer.Count(e => e.fld_Email == id) > 0;
        }
    }
}