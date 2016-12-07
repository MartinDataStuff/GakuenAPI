using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class UserRepository : IRepository<User>
    {
        public User Create(User o)
        {
            using (var db = new GakuenContext())
            {
                if (db.Users == null)
                    return null;
                db.Users.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public List<User> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.Users != null)
                    return db.Users.Include(user => user.Address).ToList();
                return new List<User>();
            }
        }

        public User Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.Users.Include(user => user.Address).FirstOrDefault(customer => customer.Id == id);
            }
        }

        public User Update(User o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        public bool Delete(User o)
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
