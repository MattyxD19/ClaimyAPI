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
    public class CountryListsController : ApiController
    {
        private Web_Application_for_ClaimyContext db = new Web_Application_for_ClaimyContext();

        // GET: api/CountryLists
        public IQueryable<CountryList> GetCountryLists()
        {
            return db.CountryLists;
        }

        // GET: api/CountryLists/5
        [ResponseType(typeof(CountryList))]
        public async Task<IHttpActionResult> GetCountryList(int id)
        {
            CountryList countryList = await db.CountryLists.FindAsync(id);
            if (countryList == null)
            {
                return NotFound();
            }

            return Ok(countryList);
        }

        // PUT: api/CountryLists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCountryList(int id, CountryList countryList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countryList.ID)
            {
                return BadRequest();
            }

            db.Entry(countryList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryListExists(id))
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

        // POST: api/CountryLists
        [ResponseType(typeof(CountryList))]
        public async Task<IHttpActionResult> PostCountryList(CountryList countryList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CountryLists.Add(countryList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = countryList.ID }, countryList);
        }

        // DELETE: api/CountryLists/5
        [ResponseType(typeof(CountryList))]
        public async Task<IHttpActionResult> DeleteCountryList(int id)
        {
            CountryList countryList = await db.CountryLists.FindAsync(id);
            if (countryList == null)
            {
                return NotFound();
            }

            db.CountryLists.Remove(countryList);
            await db.SaveChangesAsync();

            return Ok(countryList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryListExists(int id)
        {
            return db.CountryLists.Count(e => e.ID == id) > 0;
        }
    }
}