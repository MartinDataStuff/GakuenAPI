using System.Collections.Generic;
using System.Linq;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class AddressRepository : IRepository<Address>
    {
        //Creates Address and save changes.
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

        //Read List of all Addresses.
        public List<Address> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.Addresses != null)
                    return db.Addresses.ToList();
                return new List<Address>();
            }
        }

        //Read Address with Id.
        public Address Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.Addresses.FirstOrDefault(address => address.Id == id);
            }
        }

        //Updates an Adress and save changes.
        public Address Update(Address o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        //Deletes an Address and save changes.
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
