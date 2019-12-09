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
    public class CustomerTablesController : ApiController
    {
        private Web_Application_for_ClaimyContext db = new Web_Application_for_ClaimyContext();

        // GET: api/CustomerTables
        public IQueryable<CustomerTable> GetCustomerTables()
        {
            return db.CustomerTables;
        }

        // GET: api/CustomerTables/5
        [ResponseType(typeof(CustomerTable))]
        public async Task<IHttpActionResult> GetCustomerTable(int id)
        {
            CustomerTable customerTable = await db.CustomerTables.FindAsync(id);
            if (customerTable == null)
            {
                return NotFound();
            }

            return Ok(customerTable);
        }

        // PUT: api/CustomerTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerTable(int id, CustomerTable customerTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerTable.ID)
            {
                return BadRequest();
            }

            db.Entry(customerTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerTableExists(id))
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

        // POST: api/CustomerTables
        [ResponseType(typeof(CustomerTable))]
        public async Task<IHttpActionResult> PostCustomerTable(CustomerTable customerTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerTables.Add(customerTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customerTable.ID }, customerTable);
        }

        // DELETE: api/CustomerTables/5
        [ResponseType(typeof(CustomerTable))]
        public async Task<IHttpActionResult> DeleteCustomerTable(int id)
        {
            CustomerTable customerTable = await db.CustomerTables.FindAsync(id);
            if (customerTable == null)
            {
                return NotFound();
            }

            db.CustomerTables.Remove(customerTable);
            await db.SaveChangesAsync();

            return Ok(customerTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerTableExists(int id)
        {
            return db.CustomerTables.Count(e => e.ID == id) > 0;
        }
    }
}