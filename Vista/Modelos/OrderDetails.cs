using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public OrderDetails(int OrderID, int ProductID, double UnitPrice, int Quantity)
        {
            this.OrderID = OrderID;
            this.ProductID = ProductID;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
        }
    }
}
