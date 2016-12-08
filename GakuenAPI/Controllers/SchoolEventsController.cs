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
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Facade;
using GakuenDLL.Interface;

namespace GakuenAPI.Controllers
{
    public class SchoolEventsController : ApiController
    {
        private readonly IRepository<SchoolEvent> _db = new RepositoryFacade().GetSchoolEvent();

        // GET: api/SchoolEvents
        public List<SchoolEvent> GetSchoolEvents()
        {
            return _db.ReadAll();
        }

        // GET: api/SchoolEvents/5
        [ResponseType(typeof(SchoolEvent))]
        public IHttpActionResult GetSchoolEvent(int id)
        {
            SchoolEvent schoolEvent = _db.Read(id);
            if (schoolEvent == null)
            {
                return NotFound();
            }

            return Ok(schoolEvent);
        }

        // PUT: api/SchoolEvents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchoolEvent(int id, SchoolEvent schoolEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schoolEvent.Id)
            {
                return BadRequest();
            }
            
            try
            {
                _db.Update(schoolEvent);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolEventExists(id))
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

        // POST: api/SchoolEvents
        [ResponseType(typeof(SchoolEvent))]
        public IHttpActionResult PostSchoolEvent(SchoolEvent schoolEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Create(schoolEvent);
            return CreatedAtRoute("DefaultApi", new { id = schoolEvent.Id }, schoolEvent);
        }

        // DELETE: api/SchoolEvents/5
        [ResponseType(typeof(SchoolEvent))]
        public IHttpActionResult DeleteSchoolEvent(int id)
        {
            SchoolEvent schoolEvent = _db.Read(id);
            if (schoolEvent == null)
            {
                return NotFound();
            }

            _db.Delete(schoolEvent);

            return Ok(schoolEvent);
        }

       private bool SchoolEventExists(int id)
        {
            return _db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}