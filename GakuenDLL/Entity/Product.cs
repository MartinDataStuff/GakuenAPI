using System.Collections.Generic;

namespace GakuenDLL.Entity
{
    public class Product : AbstractEntity
    {
        //Information of the Product
        public string Info { get; set; }
        //The name of the product
        public string Name { get; set; }
        //The price of the product
        public double Price { get; set; }
        //Has a To-Many relation to OrderList
        public List<OrderList> OrderLists { get; set; } = new List<OrderList>();
    }
}
