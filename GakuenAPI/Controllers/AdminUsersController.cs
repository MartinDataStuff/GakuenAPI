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
    public class AdminUsersController : ApiController
    {
        private readonly IRepository<AdminUser> _db = new RepositoryFacade().GetAdminUserRepository();

        // GET: api/AdminUsers
        public List<AdminUser> GetAdminUsers()
        {
            return _db.ReadAll();
        }

        // GET: api/AdminUsers/5
        [ResponseType(typeof(AdminUser))]
        public IHttpActionResult GetAdminUser(int id)
        {
            AdminUser adminUser = _db.Read(id);
            if (adminUser == null)
            {
                return NotFound();
            }

            return Ok(adminUser);
        }

        // PUT: api/AdminUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdminUser(int id, AdminUser adminUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminUser.Id)
            {
                return BadRequest();
            }
            
            try
            {
                _db.Update(adminUser);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminUserExists(id))
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

        // POST: api/AdminUsers
        [ResponseType(typeof(AdminUser))]
        public IHttpActionResult PostAdminUser(AdminUser adminUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Create(adminUser);

            return CreatedAtRoute("DefaultApi", new { id = adminUser.Id }, adminUser);
        }

        // DELETE: api/AdminUsers/5
        [ResponseType(typeof(AdminUser))]
        public IHttpActionResult DeleteAdminUser(int id)
        {
            AdminUser adminUser = _db.Read(id);
            _db.Delete(adminUser);

            return Ok(adminUser);
        }

        private bool AdminUserExists(int id)
        {
            return _db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}