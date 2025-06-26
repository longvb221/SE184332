using System.Text;
using System.Windows;

namespace LongVuBaoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCustomerView(); // default view

        }

             private void BtnCustomer_Click(object sender, RoutedEventArgs e)
        {
            LoadCustomerView();
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new View.ProductView();
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new View.OrderView();
        }

        private void BtnCategory_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new View.CategoryView();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }

        private void LoadCustomerView()
        {
            MainContent.Content = new View.CustomerView();
        }
        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new View.ReportView();
        }
    }
    }
