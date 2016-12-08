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
    class NewsMessageRepository : IRepository<NewsMessage>
    {
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

        public List<NewsMessage> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.NewsMessages != null)
                    return db.NewsMessages.Include(newsMessage => newsMessage.ImageToHost).Include(newsMessage => newsMessage.VideoToHost).ToList();
                return new List<NewsMessage>();
            }
        }

        public NewsMessage Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.NewsMessages.Include("ImageToHost").Include("VideoToHost").FirstOrDefault(message => message.Id == id);
            }
        }

        public NewsMessage Update(NewsMessage o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

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
