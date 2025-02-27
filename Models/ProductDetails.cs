using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_WPF.Models
{
    internal class ProductDetails
    {
        string productCode;
        string productName;
        int quantityOrdered;

        public ProductDetails(string productCode, string productName, int quantityOrdered)
        {
            this.ProductCode = productCode;
            this.ProductName = productName;
            this.QuantityOrdered = quantityOrdered;
        }

        public string ProductCode { get => productCode; set => productCode = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int QuantityOrdered { get => quantityOrdered; set => quantityOrdered = value; }
    }
}
