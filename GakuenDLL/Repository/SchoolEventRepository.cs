using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class SchoolEventRepository : IRepository<SchoolEvent>
    {
        public SchoolEvent Create(SchoolEvent o)
        {
            using (var db = new GakuenContext())
            {
                if (db.SchoolEvents == null)
                    return null;
                db.SchoolEvents.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public List<SchoolEvent> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.SchoolEvents != null)
                    return db.SchoolEvents.ToList();
                return new List<SchoolEvent>();
            }
        }

        public SchoolEvent Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.SchoolEvents.FirstOrDefault(schoolEvent => schoolEvent.Id == id);
            }
        }

        public SchoolEvent Update(SchoolEvent o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

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
