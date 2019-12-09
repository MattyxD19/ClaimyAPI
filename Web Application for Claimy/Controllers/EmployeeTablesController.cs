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
    public class EmployeeTablesController : ApiController
    {
        private Web_Application_for_ClaimyContext db = new Web_Application_for_ClaimyContext();

        // GET: api/EmployeeTables
        public IQueryable<EmployeeTable> GetEmployeeTables()
        {
            return db.EmployeeTables;
        }

        // GET: api/EmployeeTables/5
        [ResponseType(typeof(EmployeeTable))]
        public async Task<IHttpActionResult> GetEmployeeTable(int id)
        {
            EmployeeTable employeeTable = await db.EmployeeTables.FindAsync(id);
            if (employeeTable == null)
            {
                return NotFound();
            }

            return Ok(employeeTable);
        }

        // PUT: api/EmployeeTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployeeTable(int id, EmployeeTable employeeTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeTable.ID)
            {
                return BadRequest();
            }

            db.Entry(employeeTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTableExists(id))
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

        // POST: api/EmployeeTables
        [ResponseType(typeof(EmployeeTable))]
        public async Task<IHttpActionResult> PostEmployeeTable(EmployeeTable employeeTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeTables.Add(employeeTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employeeTable.ID }, employeeTable);
        }

        // DELETE: api/EmployeeTables/5
        [ResponseType(typeof(EmployeeTable))]
        public async Task<IHttpActionResult> DeleteEmployeeTable(int id)
        {
            EmployeeTable employeeTable = await db.EmployeeTables.FindAsync(id);
            if (employeeTable == null)
            {
                return NotFound();
            }

            db.EmployeeTables.Remove(employeeTable);
            await db.SaveChangesAsync();

            return Ok(employeeTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeTableExists(int id)
        {
            return db.EmployeeTables.Count(e => e.ID == id) > 0;
        }
    }
}