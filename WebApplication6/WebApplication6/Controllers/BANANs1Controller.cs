using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication6;

namespace WebApplication6.Controllers
{
    public class BANANs1Controller : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/BANANs1
        public IQueryable<BANAN> GetBANANs()
        {
            return db.BANANs;
        }

        // GET: api/BANANs1/5
        [ResponseType(typeof(BANAN))]
        public IHttpActionResult GetBANAN(int id)
        {
            BANAN bANAN = db.BANANs.Find(id);
            if (bANAN == null)
            {
                return NotFound();
            }

            return Ok(bANAN);
        }

        // PUT: api/BANANs1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBANAN(int id, BANAN bANAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bANAN.MABAN)
            {
                return BadRequest();
            }

            db.Entry(bANAN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BANANExists(id))
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

        // POST: api/BANANs1
        [ResponseType(typeof(BANAN))]
        public IHttpActionResult PostBANAN(BANAN bANAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BANANs.Add(bANAN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bANAN.MABAN }, bANAN);
        }

        // DELETE: api/BANANs1/5
        [ResponseType(typeof(BANAN))]
        public IHttpActionResult DeleteBANAN(int id)
        {
            BANAN bANAN = db.BANANs.Find(id);
            if (bANAN == null)
            {
                return NotFound();
            }

            db.BANANs.Remove(bANAN);
            db.SaveChanges();

            return Ok(bANAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BANANExists(int id)
        {
            return db.BANANs.Count(e => e.MABAN == id) > 0;
        }
    }
}