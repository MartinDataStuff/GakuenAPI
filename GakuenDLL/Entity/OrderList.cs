using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Entity
{
    public class OrderList : AbstractEntity
    {
        //Has a To-Many Relation
        public List<Product> ItemsList { get; set; } = new List<Product>();
        //Has a To-1 Relation
        public User User { get; set; }
        //A randomly generated string
        public string PaidStringCode { get; set; }
        //Wheter or not it has been paid yet
        public bool PaymentAccepted { get; set; } = false;

        //Calulated the total price, based on all the product on the list
        public double PriceToPay => CalculatePrice();

        //Finds the time the order was made
        public DateTime DateTime { get; set; } = DateTime.Now;

        //Methods to calculate the price
        private double CalculatePrice()
        {
            double price = 0;

            foreach (var product in ItemsList)
            {
                price += product.Price;
            }
            return price;
        }
    }
}
