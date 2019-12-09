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
    public class ImageTablesController : ApiController
    {
        private Web_Application_for_ClaimyContext db = new Web_Application_for_ClaimyContext();

        // GET: api/ImageTables
        public IQueryable<ImageTable> GetImageTables()
        {
            return db.ImageTables;
        }

        // GET: api/ImageTables/5
        [ResponseType(typeof(ImageTable))]
        public async Task<IHttpActionResult> GetImageTable(int id)
        {
            ImageTable imageTable = await db.ImageTables.FindAsync(id);
            if (imageTable == null)
            {
                return NotFound();
            }

            return Ok(imageTable);
        }

        // PUT: api/ImageTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutImageTable(int id, ImageTable imageTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageTable.ID)
            {
                return BadRequest();
            }

            db.Entry(imageTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageTableExists(id))
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

        // POST: api/ImageTables
        [ResponseType(typeof(ImageTable))]
        public async Task<IHttpActionResult> PostImageTable(ImageTable imageTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImageTables.Add(imageTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = imageTable.ID }, imageTable);
        }

        // DELETE: api/ImageTables/5
        [ResponseType(typeof(ImageTable))]
        public async Task<IHttpActionResult> DeleteImageTable(int id)
        {
            ImageTable imageTable = await db.ImageTables.FindAsync(id);
            if (imageTable == null)
            {
                return NotFound();
            }

            db.ImageTables.Remove(imageTable);
            await db.SaveChangesAsync();

            return Ok(imageTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageTableExists(int id)
        {
            return db.ImageTables.Count(e => e.ID == id) > 0;
        }
    }
}