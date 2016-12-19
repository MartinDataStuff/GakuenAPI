using System.Collections.Generic;
using System.Linq;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class ProductRepository : IRepository<Product>
    {
        //Creates Product and save changes.
        public Product Create(Product o)
        {
            using (var db = new GakuenContext())
            {
                if (db.Products == null)
                    return null;
                db.Products.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        //Read List of all Products.
        public List<Product> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.Products != null)
                    return db.Products.ToList();
                return new List<Product>();
            }
        }

        //Read Products with Id.
        public Product Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.Products.FirstOrDefault(product => product.Id == id);
            }
        }

        //Updates a Product and save changes.
        public Product Update(Product o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        //Deletes a Product and save changes.
        public bool Delete(Product o)
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
