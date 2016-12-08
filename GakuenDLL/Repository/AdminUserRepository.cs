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
    class AdminUserRepository : IRepository<AdminUser>
    {
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

        public List<AdminUser> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.AdminUsers != null)
                    return db.AdminUsers.ToList();
                return new List<AdminUser>();
            }
        }

        public AdminUser Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.AdminUsers.FirstOrDefault(user => user.Id == id);
            }
        }

        public AdminUser Update(AdminUser o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

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
