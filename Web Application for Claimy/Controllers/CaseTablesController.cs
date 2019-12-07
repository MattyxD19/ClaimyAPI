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
    public class CaseTablesController : ApiController
    {
        private Web_Application_for_ClaimyContext db = new Web_Application_for_ClaimyContext();

        // GET: api/CaseTables
        public IQueryable<CaseTable> GetCaseTables()
        {
            return db.CaseTables;
        }

        // GET: api/CaseTables/5
        [ResponseType(typeof(CaseTable))]
        public async Task<IHttpActionResult> GetCaseTable(int id)
        {
            CaseTable caseTable = await db.CaseTables.FindAsync(id);
            if (caseTable == null)
            {
                return NotFound();
            }

            return Ok(caseTable);
        }

        // PUT: api/CaseTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCaseTable(int id, CaseTable caseTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseTable.ID)
            {
                return BadRequest();
            }

            db.Entry(caseTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseTableExists(id))
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

        // POST: api/CaseTables
        [ResponseType(typeof(CaseTable))]
        public async Task<IHttpActionResult> PostCaseTable(CaseTable caseTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CaseTables.Add(caseTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = caseTable.ID }, caseTable);
        }

        // DELETE: api/CaseTables/5
        [ResponseType(typeof(CaseTable))]
        public async Task<IHttpActionResult> DeleteCaseTable(int id)
        {
            CaseTable caseTable = await db.CaseTables.FindAsync(id);
            if (caseTable == null)
            {
                return NotFound();
            }

            db.CaseTables.Remove(caseTable);
            await db.SaveChangesAsync();

            return Ok(caseTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaseTableExists(int id)
        {
            return db.CaseTables.Count(e => e.ID == id) > 0;
        }
    }
}