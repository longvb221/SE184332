using Repositories.Implement;
using Services.Implement;
using Services.Interface;
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
using System.Windows.Shapes;

namespace LongVuBaoWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>

    public partial class LoginWindow : Window
    {
        private readonly IEmployeeService employeeService = new EmployeeService(new EmployeeRepository());
        private readonly ICustomerService customerService = new CustomerService(new CustomerRepository());

        public ObservableCollection<string> Roles { get; set; } = new() { "Employee", "Customer" };

        private string password = "";

        public LoginWindow()
        {
            InitializeComponent();
            RoleComboBox.ItemsSource = Roles;
            RoleComboBox.SelectedIndex = 0; // Default to Employee
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox pb)
                password = pb.Password;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedRole = RoleComboBox.SelectedItem?.ToString();
            string username = UsernameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter username or phone.");
                return;
            }

            if (selectedRole == "Employee")
            {
                var emp = employeeService.Login(username, password);
                if (emp != null)
                {
                    new MainWindow().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid employee credentials.", "Login Failed");
                }
            }
            else // Customer
            {
                var cus = customerService.GetAll().FirstOrDefault(c => c.Phone == username);
                if (cus != null)
                {
                    new CustomerWindow1(cus).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Phone number not found.", "Login Failed");
                }
            }
        }
    }
}
