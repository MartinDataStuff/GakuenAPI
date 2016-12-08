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
    class VideoToHostRepository : IRepository<VideoToHost>
    {
        public VideoToHost Create(VideoToHost o)
        {
            using (var db = new GakuenContext())
            {
                if (db.VideoToHosts == null)
                    return null;
                db.VideoToHosts.Add(o);
                db.SaveChanges();
                return o;
            }
        }



        public VideoToHost Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.VideoToHosts.FirstOrDefault(videoToHost => videoToHost.Id == id);
            }
        }

        public List<VideoToHost> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.VideoToHosts != null)
                    return db.VideoToHosts.ToList();
                return new List<VideoToHost>();
            }
        }

        public VideoToHost Update(VideoToHost o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        public bool Delete(VideoToHost o)
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
