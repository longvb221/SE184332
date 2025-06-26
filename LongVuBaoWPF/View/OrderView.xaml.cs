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
    public partial class OrderView : UserControl
    {
        private readonly OrderService service = new(new OrderRepository());
        private List<Orders> orders;

        public OrderView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            orders = service.GetAll();
            OrderGrid.ItemsSource = orders;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OrderDialog();
            if (dialog.ShowDialog() == true)
            {
                service.Add(dialog.Order);
                LoadData();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem is Orders selected)
            {
                var dialog = new OrderDialog(selected);
                if (dialog.ShowDialog() == true)
                {
                    service.Update(dialog.Order);
                    LoadData();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem is Orders selected &&
                MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Delete(selected.OrderID);
                LoadData();
            }
        }
    }
}
