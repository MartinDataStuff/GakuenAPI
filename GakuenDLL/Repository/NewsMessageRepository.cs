using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class NewsMessageRepository : IRepository<NewsMessage>
    {
        //Creates NewsMessage and save changes.
        public NewsMessage Create(NewsMessage o)
        {
            using (var db = new GakuenContext())
            {
                if (db.NewsMessages == null)
                    return null;
                db.NewsMessages.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        //Read List of all NewsMessages.
        public List<NewsMessage> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.NewsMessages != null)
                    return db.NewsMessages.Include(newsMessage => newsMessage.ImageToHost).Include(newsMessage => newsMessage.VideoToHost).ToList();
                return new List<NewsMessage>();
            }
        }

        //Read NewsMessages with Id.
        public NewsMessage Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.NewsMessages.Include("ImageToHost").Include("VideoToHost").FirstOrDefault(message => message.Id == id);
            }
        }

        //Updates a NewsMessage and save changes.
        public NewsMessage Update(NewsMessage o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        //Deletes a NewsMessage and save changes.
        public bool Delete(NewsMessage o)
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
