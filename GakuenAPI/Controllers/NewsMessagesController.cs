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
    public class NewsMessagesController : ApiController
    {
        private readonly IRepository<NewsMessage> _db = new RepositoryFacade().GetNewsMessageRepository();

        // GET: api/NewsMessages
        public List<NewsMessage> GetNewsMessages()
        {
            return _db.ReadAll();
        }

        // GET: api/NewsMessages/5
        [ResponseType(typeof(NewsMessage))]
        public IHttpActionResult GetNewsMessage(int id)
        {
            NewsMessage newsMessage = _db.Read(id);
            if (newsMessage == null)
            {
                return NotFound();
            }

            return Ok(newsMessage);
        }

        // PUT: api/NewsMessages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNewsMessage(int id, NewsMessage newsMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsMessage.Id)
            {
                return BadRequest();
            }


            try
            {
                _db.Update(newsMessage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsMessageExists(id))
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

        // POST: api/NewsMessages
        [ResponseType(typeof(NewsMessage))]
        public IHttpActionResult PostNewsMessage(NewsMessage newsMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Create(newsMessage);

            return CreatedAtRoute("DefaultApi", new { id = newsMessage.Id }, newsMessage);
        }

        // DELETE: api/NewsMessages/5
        [ResponseType(typeof(NewsMessage))]
        public IHttpActionResult DeleteNewsMessage(int id)
        {
            NewsMessage newsMessage = _db.Read(id);

            _db.Delete(newsMessage);


            return Ok(newsMessage);
        }

        private bool NewsMessageExists(int id)
        {
            return _db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}