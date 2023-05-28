using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Order
    {
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public String EmployeeName { get; set; }
        public String CustomerID { get; set; }
        public String CustomerName { get; set; }

        public String OrderDate { get; set; }
        //public String RequriedDate { get; set; }
        //public String ShippedDate { get; set; }
        //public int ShipVia { get; set; }
        public double Freight { get; set; }
        //public String ShipName { get; set; }
        //public String ShipAddress { get; set; }
        //public String ShipCity { get; set; }
        //public String ShipRegion { get; set; }
        //public String ShipPostalCode { get; set; }
        //public String ShipCountry { get; set; }

        public Order()
        {
            // Constructor vacío
        }

        public Order(int orderId, int employeeId, string employeeName, string customerId, string customerName, string orderDate, double freight)
        {
            this.OrderID = orderId;
            this.EmployeeID = employeeId;
            this.EmployeeName = employeeName;
            this.CustomerID = customerId;
            this.CustomerName = customerName;
            this.OrderDate = orderDate;
            this.Freight = freight;
        }
    }
}
