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
using Web_Application_for_Claimy.Models;

namespace Web_Application_for_Claimy.Controllers
{
    public class tbl_Parking_CompanyController : ApiController
    {
        private DB_ClaimyEntities1 db = new DB_ClaimyEntities1();

        // GET: api/tbl_Parking_Company
        public IQueryable<tbl_Parking_Company> Gettbl_Parking_Company()
        {
            return db.tbl_Parking_Company;
        }

        // GET: api/tbl_Parking_Company/5
        [ResponseType(typeof(tbl_Parking_Company))]
        public async Task<IHttpActionResult> Gettbl_Parking_Company(string id)
        {
            tbl_Parking_Company tbl_Parking_Company = await db.tbl_Parking_Company.FindAsync(id);
            if (tbl_Parking_Company == null)
            {
                return NotFound();
            }

            return Ok(tbl_Parking_Company);
        }

        // PUT: api/tbl_Parking_Company/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_Parking_Company(string id, tbl_Parking_Company tbl_Parking_Company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Parking_Company.fld_CVRNR)
            {
                return BadRequest();
            }

            db.Entry(tbl_Parking_Company).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Parking_CompanyExists(id))
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

        // POST: api/tbl_Parking_Company
        [ResponseType(typeof(tbl_Parking_Company))]
        public async Task<IHttpActionResult> Posttbl_Parking_Company(tbl_Parking_Company tbl_Parking_Company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Parking_Company.Add(tbl_Parking_Company);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tbl_Parking_CompanyExists(tbl_Parking_Company.fld_CVRNR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_Parking_Company.fld_CVRNR }, tbl_Parking_Company);
        }

        // DELETE: api/tbl_Parking_Company/5
        [ResponseType(typeof(tbl_Parking_Company))]
        public async Task<IHttpActionResult> Deletetbl_Parking_Company(string id)
        {
            tbl_Parking_Company tbl_Parking_Company = await db.tbl_Parking_Company.FindAsync(id);
            if (tbl_Parking_Company == null)
            {
                return NotFound();
            }

            db.tbl_Parking_Company.Remove(tbl_Parking_Company);
            await db.SaveChangesAsync();

            return Ok(tbl_Parking_Company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_Parking_CompanyExists(string id)
        {
            return db.tbl_Parking_Company.Count(e => e.fld_CVRNR == id) > 0;
        }
    }
}