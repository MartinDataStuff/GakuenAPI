using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class UserRepository : IRepository<User>
    {
        //Creates User and save changes.
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

        //Read List of all Users.
        public List<User> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.Users != null)
                    return db.Users.Include(user => user.Address).Include(user => user.OrderLists).Include(user => user.SchoolEvents).ToList();
                return new List<User>();
            }
        }

        //Read User with Id.
        public User Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.Users.Include(user => user.Address).Include(user => user.OrderLists).Include(user => user.SchoolEvents).FirstOrDefault(customer => customer.Id == id);
            }
        }

        //Updates a User and save changes.
        public User Update(User o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        //Deletes a User and save changes.
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
