using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class EventMessageRepository : IRepository<EventMessage>
    {
        public EventMessage Create(EventMessage o)
        {
            using (var db = new GakuenContext())
            {
                if (db.EventMessages == null)
                    return null;
                db.EventMessages.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public List<EventMessage> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.EventMessages != null)
                    return db.EventMessages.ToList();
                return new List<EventMessage>();
            }
        }

        public EventMessage Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.EventMessages.FirstOrDefault(message => message.Id == id);
            }
        }

        public EventMessage Update(EventMessage o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        public bool Delete(EventMessage o)
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
