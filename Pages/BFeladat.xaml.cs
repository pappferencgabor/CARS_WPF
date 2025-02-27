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

using CARS_WPF.Models;
using CARS_WPF.Helpers;

namespace CARS_WPF.Pages
{
    /// <summary>
    /// Interaction logic for BFeladat.xaml
    /// </summary>
    public partial class BFeladat : Page
    {
        MySqlConnection _connection;
        ObservableCollection<CountryOrder> orders = new ObservableCollection<CountryOrder>();

        public BFeladat()
        {
            InitializeComponent();

            _connection = GetMySQLConnection.getMysqlConnection();
            _connection.Open();

            LoadData();
        }

        private void LoadData()
        {
            MySqlCommand command = new MySqlCommand("SELECT customerName, phone, city, country FROM customers", _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orders.Add(new CountryOrder(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }
            reader.Close();

            LoadCountries();
        }

        private void LoadCountries()
        {
            var countries = orders.Select(x => x.Country).Distinct().Order().ToList();

            cboCountries.ItemsSource = countries;
        }

        private void cboCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCountries.SelectedIndex >= 0)
            {
                var filtered = orders.Where(x => x.Country == cboCountries.SelectedItem.ToString());

                dgAdatok.ItemsSource = filtered;
            }
        }
    }
}
