using BusinessObject;
using Repositories.Implement;
using Services.Implement;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace LongVuBaoWPF.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    
        public partial class CustomerView : UserControl
        {
            private readonly CustomerService customerService = new(new CustomerRepository());
            private List<Customers> customers;

            public CustomerView()
            {
                InitializeComponent();
                LoadData();
            }

            private void LoadData()
            {
                customers = customerService.GetAll();
                CustomerGrid.ItemsSource = customers;
            }

            private void Add_Click(object sender, RoutedEventArgs e)
            {
                var dialog = new CustomerDialog();
                if (dialog.ShowDialog() == true)
                {
                    customerService.Add(dialog.Customer);
                    LoadData();
                }
            }

            private void Edit_Click(object sender, RoutedEventArgs e)
            {
                if (CustomerGrid.SelectedItem is Customers selected)
                {
                    var dialog = new CustomerDialog(selected);
                    if (dialog.ShowDialog() == true)
                    {
                        customerService.Update(dialog.Customer);
                        LoadData();
                    }
                }
            }

            private void Delete_Click(object sender, RoutedEventArgs e)
            {
                if (CustomerGrid.SelectedItem is Customers selected &&
                    MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    customerService.Delete(selected.CustomerID);
                    LoadData();
                }
            }
        }
    }

