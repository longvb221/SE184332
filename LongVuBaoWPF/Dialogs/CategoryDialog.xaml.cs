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
using BusinessObject;
using System.Windows;
namespace LongVuBaoWPF.View
{
    /// <summary>
    /// Interaction logic for CategoryDialog.xaml
    /// </summary>
    public partial class CategoryDialog : Window
    {
      
        public Categories Category { get; private set; }

        public CategoryDialog(Categories existing = null)
        {
            InitializeComponent();

            if (existing != null)
            {
                Category = existing;
                txtName.Text = existing.CategoryName;
                txtDesc.Text = existing.Description;
            }
            else
            {
                Category = new Categories();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Category.CategoryName = txtName.Text;
            Category.Description = txtDesc.Text;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

