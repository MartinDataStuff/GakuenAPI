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
    public class VideoToHostsController : ApiController
    {
        private readonly IRepository<VideoToHost> _db = new RepositoryFacade().GetVideoRepository();

        // GET: api/VideoToHosts
        public List<VideoToHost> GetVideoToHosts()
        {
            return _db.ReadAll();
        }

        // GET: api/VideoToHosts/5
        [ResponseType(typeof(VideoToHost))]
        public IHttpActionResult GetVideoToHost(int id)
        {
            VideoToHost videoToHost = _db.Read(id);
            if (videoToHost == null)
            {
                return NotFound();
            }

            return Ok(videoToHost);
        }

        // PUT: api/VideoToHosts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVideoToHost(int id, VideoToHost videoToHost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != videoToHost.Id)
            {
                return BadRequest();
            }
            

            try
            {
                _db.Update(videoToHost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoToHostExists(id))
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

        // POST: api/VideoToHosts
        [ResponseType(typeof(VideoToHost))]
        public IHttpActionResult PostVideoToHost(VideoToHost videoToHost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Create(videoToHost);

            return CreatedAtRoute("DefaultApi", new { id = videoToHost.Id }, videoToHost);
        }

        // DELETE: api/VideoToHosts/5
        [ResponseType(typeof(VideoToHost))]
        public IHttpActionResult DeleteVideoToHost(int id)
        {
            VideoToHost videoToHost = _db.Read(id);
            if (videoToHost == null)
            {
                return NotFound();
            }

            _db.Delete(videoToHost);
       

            return Ok(videoToHost);
        }

  
        private bool VideoToHostExists(int id)
        {
            return _db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}