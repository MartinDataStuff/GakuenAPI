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
    public class ImageToHostsController : ApiController
    {
        private readonly IRepository<ImageToHost> _db = new RepositoryFacade().GetImageRepository();

        // GET: api/Images
        public List<ImageToHost> GetImages()
        {
            return _db.ReadAll();
        }

        // GET: api/Images/5
        [ResponseType(typeof(ImageToHost))]
        public IHttpActionResult GetImage(int id)
        {
            ImageToHost imageToHost = _db.Read(id);
            if (imageToHost == null)
            {
                return NotFound();
            }

            return Ok(imageToHost);
        }

        // PUT: api/Images/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImage(int id, ImageToHost imageToHost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageToHost.Id)
            {
                return BadRequest();
            }
            
            try
            {
                _db.Update(imageToHost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Images
        [ResponseType(typeof(ImageToHost))]
        public IHttpActionResult PostImage(ImageToHost imageToHost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Create(imageToHost);

            return CreatedAtRoute("DefaultApi", new { id = imageToHost.Id }, imageToHost);
        }

        // DELETE: api/Images/5
        [ResponseType(typeof(ImageToHost))]
        public IHttpActionResult DeleteImage(int id)
        {
            ImageToHost imageToHost = _db.Read(id);
            if (imageToHost == null)
            {
                return NotFound();
            }

            _db.Delete(imageToHost);

            return Ok(imageToHost);
        }

              private bool ImageExists(int id)
        {
            return _db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}