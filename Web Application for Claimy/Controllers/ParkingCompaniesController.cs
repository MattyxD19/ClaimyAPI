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
    public class ParkingCompaniesController : ApiController
    {
        private Web_Application_for_ClaimyContext db = new Web_Application_for_ClaimyContext();

        // GET: api/ParkingCompanies
        public IQueryable<ParkingCompany> GetParkingCompanies()
        {
            return db.ParkingCompanies;
        }

        // GET: api/ParkingCompanies/5
        [ResponseType(typeof(ParkingCompany))]
        public async Task<IHttpActionResult> GetParkingCompany(int id)
        {
            ParkingCompany parkingCompany = await db.ParkingCompanies.FindAsync(id);
            if (parkingCompany == null)
            {
                return NotFound();
            }

            return Ok(parkingCompany);
        }

        // PUT: api/ParkingCompanies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParkingCompany(int id, ParkingCompany parkingCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parkingCompany.ID)
            {
                return BadRequest();
            }

            db.Entry(parkingCompany).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingCompanyExists(id))
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

        // POST: api/ParkingCompanies
        [ResponseType(typeof(ParkingCompany))]
        public async Task<IHttpActionResult> PostParkingCompany(ParkingCompany parkingCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParkingCompanies.Add(parkingCompany);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = parkingCompany.ID }, parkingCompany);
        }

        // DELETE: api/ParkingCompanies/5
        [ResponseType(typeof(ParkingCompany))]
        public async Task<IHttpActionResult> DeleteParkingCompany(int id)
        {
            ParkingCompany parkingCompany = await db.ParkingCompanies.FindAsync(id);
            if (parkingCompany == null)
            {
                return NotFound();
            }

            db.ParkingCompanies.Remove(parkingCompany);
            await db.SaveChangesAsync();

            return Ok(parkingCompany);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParkingCompanyExists(int id)
        {
            return db.ParkingCompanies.Count(e => e.ID == id) > 0;
        }
    }
}