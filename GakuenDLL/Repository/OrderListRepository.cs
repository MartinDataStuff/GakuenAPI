using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using GakuenDLL.Context;
using GakuenDLL.Entity;
using GakuenDLL.Interface;

namespace GakuenDLL.Repository
{
    class OrderListRepository : IRepository<OrderList>
    {
        //Creates OrderList and save changes.
        public OrderList Create(OrderList o)
        {
            using (var db = new GakuenContext())
            {
                if (db.OrderLists == null)
                    return null;
                foreach (var product in o.ItemsList)
                {
                    db.Entry(product).State = EntityState.Unchanged;
                }
                db.OrderLists.Add(o);
                db.SaveChanges();
                return o;
            }
        }

        //Read List of all OrderLists.
        public List<OrderList> ReadAll()
        {
            using (var db = new GakuenContext())
            {
                if (db.OrderLists != null)
                    return db.OrderLists.Include(orderList => orderList.User ).Include(orderList => orderList.ItemsList).ToList();
                return new List<OrderList>();
            }
        }

        //Read OrderLists with Id.
        public OrderList Read(int id)
        {
            using (var db = new GakuenContext())
            {
                return db.OrderLists.Include(orderList => orderList.User).Include(orderList => orderList.ItemsList).FirstOrDefault(list => list.Id == id);
            }
        }

        //Updates an OrderLists and save changes.
        public OrderList Update(OrderList o)
        {
            using (var db = new GakuenContext())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return o;
            }
        }

        //Deletes an OrderLists and save changes.
        public bool Delete(OrderList o)
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
