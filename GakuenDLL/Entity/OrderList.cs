using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Entity
{
    public class OrderList : AbstractEntity
    {
        private double _priceToPay;
        private double _priceToPay1;
        public List<Product> ItemsList { get; set; } = new List<Product>();
        public User User { get; set; }
        public string PaidStringCode { get; set; }

        public double PriceToPay => CalculatePrice();

        public DateTime DateTime { get; set; } = DateTime.Now;

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
