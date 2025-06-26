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
    /// Interaction logic for OrderHistoryView.xaml
    /// </summary>
    public partial class OrderHistoryView : UserControl
    {
        private readonly int customerId;

        private readonly OrderService orderService = new OrderService(new OrderRepository());

        public OrderHistoryView(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            var orders = orderService.GetAll()
                            .Where(o => o.CustomerID == customerId)
                            .OrderByDescending(o => o.OrderDate)
                            .ToList();

            OrderHistoryGrid.ItemsSource = orders;
        }
    }
}
