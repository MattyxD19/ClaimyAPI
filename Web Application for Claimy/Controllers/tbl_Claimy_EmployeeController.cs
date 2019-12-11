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
    public class tbl_Claimy_EmployeeController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/tbl_Claimy_Employee
        public IQueryable<tbl_Claimy_Employee> Gettbl_Claimy_Employee()
        {
            return db.tbl_Claimy_Employee;
        }

        // GET: api/tbl_Claimy_Employee/5
        [ResponseType(typeof(tbl_Claimy_Employee))]
        public async Task<IHttpActionResult> Gettbl_Claimy_Employee(string id)
        {
            tbl_Claimy_Employee tbl_Claimy_Employee = await db.tbl_Claimy_Employee.FindAsync(id);
            if (tbl_Claimy_Employee == null)
            {
                return NotFound();
            }

            return Ok(tbl_Claimy_Employee);
        }

        // PUT: api/tbl_Claimy_Employee/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_Claimy_Employee(string id, tbl_Claimy_Employee tbl_Claimy_Employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Claimy_Employee.fld_Email)
            {
                return BadRequest();
            }

            db.Entry(tbl_Claimy_Employee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_Claimy_EmployeeExists(id))
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

        // POST: api/tbl_Claimy_Employee
        [ResponseType(typeof(tbl_Claimy_Employee))]
        public async Task<IHttpActionResult> Posttbl_Claimy_Employee(tbl_Claimy_Employee tbl_Claimy_Employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Claimy_Employee.Add(tbl_Claimy_Employee);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tbl_Claimy_EmployeeExists(tbl_Claimy_Employee.fld_Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_Claimy_Employee.fld_Email }, tbl_Claimy_Employee);
        }

        // DELETE: api/tbl_Claimy_Employee/5
        [ResponseType(typeof(tbl_Claimy_Employee))]
        public async Task<IHttpActionResult> Deletetbl_Claimy_Employee(string id)
        {
            tbl_Claimy_Employee tbl_Claimy_Employee = await db.tbl_Claimy_Employee.FindAsync(id);
            if (tbl_Claimy_Employee == null)
            {
                return NotFound();
            }

            db.tbl_Claimy_Employee.Remove(tbl_Claimy_Employee);
            await db.SaveChangesAsync();

            return Ok(tbl_Claimy_Employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_Claimy_EmployeeExists(string id)
        {
            return db.tbl_Claimy_Employee.Count(e => e.fld_Email == id) > 0;
        }
    }
}