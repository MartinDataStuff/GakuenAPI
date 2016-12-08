using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class ImageToHostRepository : IRepository<ImageToHost>
    {
        public ImageToHost Create(ImageToHost o)
        {
            //Convert Image to Bytes
            //byte[] imgBytes;
            //var loadedImage =
            //    Image.FromFile(o.ImagePath);

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    loadedImage.Save(ms, ImageFormat.Jpeg);
            //    imgBytes = ms.ToArray();
            //}
            //o.Bytes = imgBytes;

            using (var db = new GakuenContext())
            {
                if (db.Images == null)
                    return null;
                db.Images.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public List<ImageToHost> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.Images != null)
                    return db.Images.ToList();
                return new List<ImageToHost>();
            }
        }

        public ImageToHost Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.Images.FirstOrDefault(image => image.Id == id);
            }
        }

        public ImageToHost Update(ImageToHost o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

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
