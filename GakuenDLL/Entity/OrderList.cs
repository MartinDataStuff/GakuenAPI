using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Entity
{
    public class OrderList : AbstractEntity
    {
        public List<Product> ItemsList { get; set; } = new List<Product>();
        public User User { get; set; }
        public string PaidStringCode { get; set; }
        public double PriceToPay { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
