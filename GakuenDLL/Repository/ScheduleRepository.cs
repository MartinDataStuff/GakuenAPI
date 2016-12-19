using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class ScheduleRepository : IRepository<Schedule>
    {
        //Creates Schedule and save changes.
        public Schedule Create(Schedule o)
        {
            using (var db = new GakuenContext())
            {
                if (db.Schedules == null)
                    return null;
                foreach (var schoolEvent in o.SchoolEvents)
                {
                    db.Entry(schoolEvent).State = EntityState.Unchanged;
                }
                db.Schedules.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        //Read List of all Schedules.
        public List<Schedule> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.Schedules != null)
                    return db.Schedules.Include(schedule => schedule.SchoolEvents).ToList();
                return new List<Schedule>();
            }
        }

        //Read Schedules with Id.
        public Schedule Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.Schedules.Include(schedule => schedule.SchoolEvents).FirstOrDefault(schedule => schedule.Id == id);
            }
        }

        //Updates a Schedule and save changes.
        public Schedule Update(Schedule o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        //Deletes a Schedule and save changes.
        public bool Delete(Schedule o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Read(o.Id) == null;
            }
        }
    }
}
