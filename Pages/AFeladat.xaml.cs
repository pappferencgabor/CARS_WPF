using CARS_WPF.Helpers;
using CARS_WPF.Models;
using MySqlConnector;
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
using static System.Net.Mime.MediaTypeNames;

namespace CARS_WPF.Pages
{
    /// <summary>
    /// Interaction logic for AFeladat.xaml
    /// </summary>
    public partial class AFeladat : Page
    {
        MySqlConnection _connection;
        ObservableCollection<ProductDetails> productDetails = new ObservableCollection<ProductDetails>();

        public AFeladat()
        {
            InitializeComponent();

            _connection = GetMySQLConnection.getMysqlConnection();
            _connection.Open();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT products.productCode, products.productName, quantityOrdered " +
                                                        "FROM products " +
                                                        "INNER JOIN orderdetails ON products.productCode = orderdetails.productCode " +
                                                        "GROUP BY products.productCode", _connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    productDetails.Add(new ProductDetails(reader.GetString(0), reader.GetString(1), reader.GetInt32(2)));
                }
                reader.Close();

                dgAdatok.ItemsSource = productDetails;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void dgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAdatok.SelectedIndex >= 0)
            {
                if (productDetails[dgAdatok.SelectedIndex].QuantityOrdered == 0)
                {
                    MessageBox.Show("Nincs rendelés erre a termékre");
                }
                else
                {
                    txtResult.Text = $"Erre a termékre jelenleg {productDetails[dgAdatok.SelectedIndex].QuantityOrdered} rendelés van";
                }
            }
        }
    }
}
