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
    public class EventMessagesController : ApiController
    {
        private readonly IRepository<EventMessage> _db = new RepositoryFacade().GetEventMessageRepository();

        // GET: api/EventMessages
        public List<EventMessage> GetEventMessages()
        {
            return _db.ReadAll();
        }

        // GET: api/EventMessages/5
        [ResponseType(typeof(EventMessage))]
        public IHttpActionResult GetEventMessage(int id)
        {
            EventMessage eventMessage = _db.Read(id);
            if (eventMessage == null)
            {
                return NotFound();
            }

            return Ok(eventMessage);
        }

        // PUT: api/EventMessages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventMessage(int id, EventMessage eventMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventMessage.Id)
            {
                return BadRequest();
            }
            
            try
            {
                _db.Update(eventMessage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventMessageExists(id))
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

        // POST: api/EventMessages
        [ResponseType(typeof(EventMessage))]
        public IHttpActionResult PostEventMessage(EventMessage eventMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Create(eventMessage);

            return CreatedAtRoute("DefaultApi", new { id = eventMessage.Id }, eventMessage);
        }

        // DELETE: api/EventMessages/5
        [ResponseType(typeof(EventMessage))]
        public IHttpActionResult DeleteEventMessage(int id)
        {
            EventMessage eventMessage = _db.Read(id);


            _db.Delete(eventMessage);

            return Ok(eventMessage);
        }
 

        private bool EventMessageExists(int id)
        {
            return _db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}