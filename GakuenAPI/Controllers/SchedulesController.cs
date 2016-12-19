using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using GakuenDLL.Entity;
using GakuenDLL.Facade;
using GakuenDLL.Interface;

namespace GakuenAPI.Controllers
{
    public class SchedulesController : ApiController
    {
        private readonly IRepository<Schedule> _db = new RepositoryFacade().GetScheduleRepository();

        // GET: api/Schedules
        public List<Schedule> GetSchedules()
        {
            //Reads all Schedules.
            return _db.ReadAll();
        }

        // GET: api/Schedules/5
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult GetSchedule(int id)
        {
            //Reads Schedule by Id.
            Schedule schedule = _db.Read(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        // PUT: api/Schedules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchedule(int id, Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schedule.Id)
            {
                return BadRequest();
            }
            

            try
            {
                //Updates Schedule.
                _db.Update(schedule);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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

        // POST: api/Schedules
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult PostSchedule(Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Creates Schedule.
            _db.Create(schedule);

            return CreatedAtRoute("DefaultApi", new { id = schedule.Id }, schedule);
        }

        // DELETE: api/Schedules/5
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult DeleteSchedule(int id)
        {
            //Read Schedule by Id.
            Schedule schedule = _db.Read(id);
            if (schedule == null)
            {
                return NotFound();
            }

            //Deletes Schedule.
            _db.Delete(schedule);

            return Ok(schedule);
        }
       
        //Checks if Schedule exists by Id.
        private bool ScheduleExists(int id)
        {
            return _db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}