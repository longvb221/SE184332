﻿using BusinessObject;
using LongVuBaoWPF.View;
using Repositories.Implement;
using Services.Implement;
using System.Windows;


namespace LongVuBaoWPF
{
    /// <summary>
    /// Interaction logic for CustomerWindow1.xaml
    /// </summary>
    public partial class CustomerWindow1 : Window
    {
        private readonly Customers currentCustomer;
        private readonly CustomerService customerService = new CustomerService(new CustomerRepository());
        public CustomerWindow1()
        {
            InitializeComponent();
        }
        public CustomerWindow1(Customers customer)
        {
            InitializeComponent();

            if (customer == null)
            {
                MessageBox.Show("Invalid customer data.");
                Close();
                return;
            }

            currentCustomer = customer;
            LoadOrderHistory(); // Mặc định hiển thị đơn hàng
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            LoadOrderHistory();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ProfileDialog(currentCustomer);
            if (dialog.ShowDialog() == true)
            {
                var updated = dialog.UpdatedCustomer;

                try
                {
                    customerService.Update(updated);
                    MessageBox.Show("Profile updated successfully!");

                    // Cập nhật lại dữ liệu nội bộ
                    currentCustomer.ContactName = updated.ContactName;
                    currentCustomer.ContactTitle = updated.ContactTitle;
                    currentCustomer.Address = updated.Address;
                    currentCustomer.Phone = updated.Phone;
                }
                catch
                {
                    MessageBox.Show("Failed to update profile.");
                }
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }

        private void LoadOrderHistory()
        {
            MainContent.Content = new OrderHistoryView(currentCustomer.CustomerID);
        }
    }
}
