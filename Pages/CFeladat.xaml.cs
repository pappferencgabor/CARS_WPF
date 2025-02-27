using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySqlConnector;

using CARS_WPF.Models;
using CARS_WPF.Helpers;

namespace CARS_WPF.Pages
{
    /// <summary>
    /// Interaction logic for CFeladat.xaml
    /// </summary>
    public partial class CFeladat : Page
    {
        MySqlConnection _connection;
        ObservableCollection<Order> orders = new ObservableCollection<Order>();
        ObservableCollection<OrderedProduct> orderedProducts = new ObservableCollection<OrderedProduct>();

        public CFeladat()
        {
            InitializeComponent();

            _connection = GetMySQLConnection.getMysqlConnection();
            _connection.Open();

            LoadData();
        }

        private void LoadData()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM orders", _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orders.Add(new Order(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetDateTime(2),
                    reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                    reader.GetString(4),
                    reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                    reader.GetInt32(6)
                ));
            }
            reader.Close();

            dgAdatok.DataContext = orders;
            dgAdatok.ItemsSource = orders;
        }

        private void dgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAdatok.SelectedIndex >= 0)
            {
                lbAdatok.Items.Clear();
                orderedProducts.Clear();

                Order order = orders[dgAdatok.SelectedIndex];

                MySqlCommand command = new MySqlCommand("SELECT products.productName, products.buyPrice " +
                                                        "FROM orders " +
                                                        "INNER JOIN orderdetails ON orders.orderNumber = orderdetails.orderNumber " +
                                                        "INNER JOIN products ON orderdetails.productCode = products.productCode " +
                                                        $"WHERE orders.orderNumber = {order.OrderNumber} " +
                                                        $"ORDER BY products.productName", _connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orderedProducts.Add(new OrderedProduct(reader.GetString(0), reader.GetDouble(1)));
                }
                reader.Close();

                foreach (var product in orderedProducts)
                {
                    lbAdatok.Items.Add($"{product.ProductName} - {product.BuyPrice}");
                }
            }
        }
    }
}
