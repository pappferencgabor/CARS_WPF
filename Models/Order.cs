using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_WPF.Models
{
    internal class Order
    {
        int orderNumber;
        DateTime orderDate;
        DateTime requiredDate;
        DateTime? shippedDate;
        string status;
        string comments;
        int customerNumber;

        public Order(int orderNumber, DateTime orderDate, DateTime requiredDate, DateTime? shippedDate, string status, string comments, int customerNumber)
        {
            this.OrderNumber = orderNumber;
            this.OrderDate = orderDate;
            this.RequiredDate = requiredDate;
            this.ShippedDate = shippedDate;
            this.Status = status;
            this.Comments = comments;
            this.CustomerNumber = customerNumber;
        }

        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public DateTime RequiredDate { get => requiredDate; set => requiredDate = value; }
        public DateTime? ShippedDate { get => shippedDate; set => shippedDate = value; }
        public string Status { get => status; set => status = value; }
        public string Comments { get => comments; set => comments = value; }
        public int CustomerNumber { get => customerNumber; set => customerNumber = value; }
    }

    internal class OrderedProduct
    {
        string productName;
        double buyPrice;

        public OrderedProduct(string productName, double buyPrice)
        {
            this.ProductName = productName;
            this.BuyPrice = buyPrice;
        }

        public string ProductName { get => productName; set => productName = value; }
        public double BuyPrice { get => buyPrice; set => buyPrice = value; }
    }
}
