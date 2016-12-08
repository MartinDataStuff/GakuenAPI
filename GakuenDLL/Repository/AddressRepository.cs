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
    class AddressRepository : IRepository<Address>
    {
        public Address Create(Address o)
        {
            using (var db = new GakuenContext())
            {
                if (db.Addresses == null)
                    return null;
                db.Addresses.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        public List<Address> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.Addresses != null)
                    return db.Addresses.ToList();
                return new List<Address>();
            }
        }

        public Address Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.Addresses.FirstOrDefault(address => address.Id == id);
            }
        }

        public Address Update(Address o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        public bool Delete(Address o)
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
