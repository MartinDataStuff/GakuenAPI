using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class ScheduleRepository : IRepository<Schedule>
    {
        public Schedule Create(Schedule o)
        {
            using (var db = new GakuenContext())
            {
                if (db.Schedules == null)
                    return null;
                db.Schedules.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public List<Schedule> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.Schedules != null)
                    return db.Schedules.Include(schedule => schedule.SchoolEvents).ToList();
                return new List<Schedule>();
            }
        }

        public Schedule Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.Schedules.Include(schedule => schedule.SchoolEvents).FirstOrDefault(schedule => schedule.Id == id);
            }
        }

        public Schedule Update(Schedule o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

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
