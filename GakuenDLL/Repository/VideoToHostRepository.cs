using System.Collections.Generic;
using System.Linq;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class VideoToHostRepository : IRepository<VideoToHost>
    {
        //Creates VideoToHost and save changes.
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

        //Read List of all VideoToHosts.
        public VideoToHost Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.VideoToHosts.FirstOrDefault(videoToHost => videoToHost.Id == id);
            }
        }

        //Read VideoToHost with Id.
        public List<VideoToHost> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.VideoToHosts != null)
                    return db.VideoToHosts.ToList();
                return new List<VideoToHost>();
            }
        }

        //Updates a VideoToHost and save changes.
        public VideoToHost Update(VideoToHost o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        //Deletes a VideoToHost and save changes.
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
