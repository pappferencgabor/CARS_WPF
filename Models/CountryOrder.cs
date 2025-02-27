using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_WPF.Models
{
    internal class CountryOrder
    {
        string customerName;
        string phone;
        string city;
        string country;

        public CountryOrder(string customerName, string phone, string city, string country)
        {
            this.CustomerName = customerName;
            this.Phone = phone;
            this.City = city;
            this.Country = country;
        }

        public string CustomerName { get => customerName; set => customerName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
    }
}
