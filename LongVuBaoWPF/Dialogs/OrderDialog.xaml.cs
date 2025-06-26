using BusinessObject;
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
    /// Interaction logic for OrderDialog.xaml
    /// </summary>
    public partial class OrderDialog : Window
    {
        public Orders Order { get; private set; }

        public OrderDialog(Orders existing = null)
        {
            InitializeComponent();

            if (existing != null)
            {
                Order = existing;
                txtCustomerID.Text = existing.CustomerID.ToString();
                txtEmployeeID.Text = existing.EmployeeID.ToString();
                dpOrderDate.SelectedDate = existing.OrderDate;
            }
            else
            {
                Order = new Orders();
                dpOrderDate.SelectedDate = System.DateTime.Now;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Order.CustomerID = int.Parse(txtCustomerID.Text);
            Order.EmployeeID = int.Parse(txtEmployeeID.Text);
            Order.OrderDate = dpOrderDate.SelectedDate ?? System.DateTime.Now;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
