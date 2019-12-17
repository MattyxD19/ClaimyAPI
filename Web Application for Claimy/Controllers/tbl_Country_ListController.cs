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
using Web_Application_for_Claimy.Model;

namespace Web_Application_for_Claimy.Controllers
{
    public class tbl_Country_ListController : ApiController
    {
        private ClaimyModel db = new ClaimyModel();

        // GET: api/tbl_Country_List
        public IQueryable<tbl_Country_List> Gettbl_Country_List()
        {
            return db.tbl_Country_List;
        }

        // GET: api/tbl_Country_List/5
        [ResponseType(typeof(tbl_Country_List))]
        public async Task<IHttpActionResult> Gettbl_Country_List(int id)
        {
            tbl_Country_List tbl_Country_List = await db.tbl_Country_List.FindAsync(id);
            if (tbl_Country_List == null)
            {
                return NotFound();
            }

            return Ok(tbl_Country_List);
        }

        // PUT: api/tbl_Country_List/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_Country_List(int id, tbl_Country_List tbl_Country_List)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Country_List.fld_Number)
            {
                return BadRequest();
            }

            db.Entry(tbl_Country_List).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Country_ListExists(id))
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

        // POST: api/tbl_Country_List
        [ResponseType(typeof(tbl_Country_List))]
        public async Task<IHttpActionResult> Posttbl_Country_List(tbl_Country_List tbl_Country_List)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Country_List.Add(tbl_Country_List);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Country_List.fld_Number }, tbl_Country_List);
        }

        // DELETE: api/tbl_Country_List/5
        [ResponseType(typeof(tbl_Country_List))]
        public async Task<IHttpActionResult> Deletetbl_Country_List(int id)
        {
            tbl_Country_List tbl_Country_List = await db.tbl_Country_List.FindAsync(id);
            if (tbl_Country_List == null)
            {
                return NotFound();
            }

            db.tbl_Country_List.Remove(tbl_Country_List);
            await db.SaveChangesAsync();

            return Ok(tbl_Country_List);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_Country_ListExists(int id)
        {
            return db.tbl_Country_List.Count(e => e.fld_Number == id) > 0;
        }
    }
}