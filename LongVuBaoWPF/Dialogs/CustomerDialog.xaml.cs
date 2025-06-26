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
    /// Interaction logic for CustomerDialog.xaml
    /// </summary>
    public partial class CustomerDialog : Window
    {
       
        public Customers Customer { get; private set; }

        public CustomerDialog(Customers existing = null)
        {
            InitializeComponent();

            if (existing != null)
            {
                Customer = existing;
                txtName.Text = existing.ContactName;
                txtCompany.Text = existing.CompanyName;
                txtPhone.Text = existing.Phone;
            }
            else
            {
                Customer = new Customers();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Customer.ContactName = txtName.Text;
            Customer.CompanyName = txtCompany.Text;
            Customer.Phone = txtPhone.Text;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
