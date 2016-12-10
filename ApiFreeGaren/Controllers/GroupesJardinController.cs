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
using Model;

namespace ApiFreeGaren.Controllers
{
    public class GroupesJardinController : ApiController
    {
        private JardinContext db = new JardinContext();

        // GET: api/GroupesJardin
        public IQueryable<GroupeJardin> GetGroupesJardin()
        {
            return db.GroupesJardin;
        }

        // GET: api/GroupesJardin/5
        [ResponseType(typeof(GroupeJardin))]
        public IHttpActionResult GetGroupeJardin(long id)
        {
            GroupeJardin groupeJardin = db.GroupesJardin.Find(id);
            if (groupeJardin == null)
            {
                return NotFound();
            }

            return Ok(groupeJardin);
        }

        // PUT: api/GroupesJardin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupeJardin(long id, GroupeJardin groupeJardin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupeJardin.Id)
            {
                return BadRequest();
            }

            db.Entry(groupeJardin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupeJardinExists(id))
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

        // POST: api/GroupesJardin
        [ResponseType(typeof(GroupeJardin))]
        public IHttpActionResult PostGroupeJardin(GroupeJardin groupeJardin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupesJardin.Add(groupeJardin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = groupeJardin.Id }, groupeJardin);
        }

        // DELETE: api/GroupesJardin/5
        [ResponseType(typeof(GroupeJardin))]
        public IHttpActionResult DeleteGroupeJardin(long id)
        {
            GroupeJardin groupeJardin = db.GroupesJardin.Find(id);
            if (groupeJardin == null)
            {
                return NotFound();
            }

            db.GroupesJardin.Remove(groupeJardin);
            db.SaveChanges();

            return Ok(groupeJardin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupeJardinExists(long id)
        {
            return db.GroupesJardin.Count(e => e.Id == id) > 0;
        }
    }
}