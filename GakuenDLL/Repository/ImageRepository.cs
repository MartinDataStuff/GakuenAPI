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
    class ImageRepository : IRepository<Image>
    {
        public Image Create(Image o)
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

        public List<Image> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.Images != null)
                    return db.Images.ToList();
                return new List<Image>();
            }
        }

        public Image Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.Images.FirstOrDefault(image => image.Id == id);
            }
        }

        public Image Update(Image o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        public bool Delete(Image o)
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
