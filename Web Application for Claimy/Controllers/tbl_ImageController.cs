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
    public class tbl_ImageController : ApiController
    {
        private DB_ClaimyEntities1 db = new DB_ClaimyEntities1();

        // GET: api/tbl_Image
        public IQueryable<tbl_Image> Gettbl_Image()
        {
            return db.tbl_Image;
        }

        // GET: api/tbl_Image/5
        [ResponseType(typeof(tbl_Image))]
        public async Task<IHttpActionResult> Gettbl_Image(int id)
        {
            tbl_Image tbl_Image = await db.tbl_Image.FindAsync(id);
            if (tbl_Image == null)
            {
                return NotFound();
            }

            return Ok(tbl_Image);
        }

        // PUT: api/tbl_Image/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_Image(int id, tbl_Image tbl_Image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Image.fld_Image_ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Image).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ImageExists(id))
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

        // POST: api/tbl_Image
        [ResponseType(typeof(tbl_Image))]
        public async Task<IHttpActionResult> Posttbl_Image(tbl_Image tbl_Image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Image.Add(tbl_Image);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tbl_ImageExists(tbl_Image.fld_Image_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_Image.fld_Image_ID }, tbl_Image);
        }

        // DELETE: api/tbl_Image/5
        [ResponseType(typeof(tbl_Image))]
        public async Task<IHttpActionResult> Deletetbl_Image(int id)
        {
            tbl_Image tbl_Image = await db.tbl_Image.FindAsync(id);
            if (tbl_Image == null)
            {
                return NotFound();
            }

            db.tbl_Image.Remove(tbl_Image);
            await db.SaveChangesAsync();

            return Ok(tbl_Image);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ImageExists(int id)
        {
            return db.tbl_Image.Count(e => e.fld_Image_ID == id) > 0;
        }
    }
}