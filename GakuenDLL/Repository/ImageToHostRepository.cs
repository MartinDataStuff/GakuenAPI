using System.Collections.Generic;
using System.Linq;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class ImageToHostRepository : IRepository<ImageToHost>
    {
        //Creates ImageToHost and save changes.
        public ImageToHost Create(ImageToHost o)
        {
            using (var db = new GakuenContext())
            {
                if (db.Images == null)
                    return null;
                db.Images.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        //Read List of all ImageToHosts.
        public List<ImageToHost> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.Images != null)
                    return db.Images.ToList();
                return new List<ImageToHost>();
            }
        }

        //Read ImageToHost with Id.
        public ImageToHost Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.Images.FirstOrDefault(image => image.Id == id);
            }
        }

        //Updates an ImageToHost and save changes.
        public ImageToHost Update(ImageToHost o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        //Deletes an ImageToHost and save changes.
        public bool Delete(ImageToHost o)
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
