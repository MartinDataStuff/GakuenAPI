using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class SchoolEventRepository : IRepository<SchoolEvent>
    {
        //Creates SchoolEvent and save changes.
        public SchoolEvent Create(SchoolEvent o)
        {
            using (var db = new GakuenContext())
            {
                if (db.SchoolEvents == null) return null;

                o.Schedule = db.Schedules.Include(schedule => schedule.SchoolEvents).FirstOrDefault(schedule => schedule.Id == o.Schedule.Id);

                var tmpList = new List<User>();

                foreach (var user1 in o.Users)
                {
                    tmpList.Add(db.Users.Include(user => user.Address).Include(user => user.OrderLists).Include(user => user.SchoolEvents).FirstOrDefault(user => user.Id == user1.Id));
                }

                o.Users = tmpList;

                db.SchoolEvents.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        //Read List of all SchoolEvents.
        public List<SchoolEvent> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.SchoolEvents != null)
                    return db.SchoolEvents.Include(schoolEvent => schoolEvent.Schedule).Include(schoolEvent => schoolEvent.Users).ToList();
                return new List<SchoolEvent>();
            }
        }

        //Read SchoolEvent with Id.
        public SchoolEvent Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.SchoolEvents.Include(schoolEvent => schoolEvent.Schedule).Include(schoolEvent => schoolEvent.Users).FirstOrDefault(schoolEvent => schoolEvent.Id == id);
            }
        }

        //Updates a SchoolEvent and save changes.
        public SchoolEvent Update(SchoolEvent o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        //Deletes a SchoolEvent and save changes.
        public bool Delete(SchoolEvent o)
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
