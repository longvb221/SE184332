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
    /// Interaction logic for ProductDialog.xaml
    /// </summary>
    public partial class ProductDialog : Window
    {

        public Products Product { get; private set; }

        public ProductDialog(Products existing = null)
        {
            InitializeComponent();

            if (existing != null)
            {
                Product = existing;
                txtName.Text = existing.ProductName;
                txtCategoryID.Text = existing.CategoryID.ToString();
                txtPrice.Text = existing.UnitPrice.ToString();
                txtStock.Text = existing.UnitsInStock.ToString();
            }
            else
            {
                Product = new Products();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Product.ProductName = txtName.Text;
            Product.CategoryID = int.Parse(txtCategoryID.Text);
            Product.UnitPrice = decimal.Parse(txtPrice.Text);
            Product.UnitsInStock = int.Parse(txtStock.Text);
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
