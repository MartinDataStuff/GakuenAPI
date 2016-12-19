using System.Collections.Generic;
using System.Linq;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class AdminUserRepository : IRepository<AdminUser>
    {
        //Creates AdminUser and save changes.
        public AdminUser Create(AdminUser o)
        {
            using (var db = new GakuenContext())
            {
                if (db.AdminUsers == null)
                    return null;
                db.AdminUsers.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        //Read List of all AdminUsers.
        public List<AdminUser> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.AdminUsers != null)
                    return db.AdminUsers.ToList();
                return new List<AdminUser>();
            }
        }

        //Read AdminUser with Id.
        public AdminUser Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.AdminUsers.FirstOrDefault(user => user.Id == id);
            }
        }

        //Updates an AdminUser and save changes.
        public AdminUser Update(AdminUser o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        //Deletes an AdminUser and save changes.
        public bool Delete(AdminUser o)
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
