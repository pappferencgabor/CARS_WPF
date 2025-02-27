//using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CARS_WPF.Pages;
using CARS_WPF.Helpers;

namespace CARS_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AdatbazisMegnyitas();
        }

        MySqlConnection connection;

        private void AdatbazisMegnyitas()
        {
            try
            {
                connection = GetMySQLConnection.getMysqlConnection();
                connection.Open();

                frameMain.Navigate(new AFeladat());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void btnFeladatA_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new AFeladat());
        }

        private void btnFeladatB_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new BFeladat());
        }

        private void btnFeladatC_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new CFeladat());
        }
    }
}