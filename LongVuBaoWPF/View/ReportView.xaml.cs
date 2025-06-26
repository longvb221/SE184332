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
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        private OrderService orderService = new OrderService(new OrderRepository());
        private OrderDetailService orderDetailService = new OrderDetailService(new OrderDetailRepository());

        public ReportView()
        {
            InitializeComponent();
            LoadReportData();
        }

        private void LoadReportData()
        {
            var orders = orderService.GetAll()
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            var reportData = orders.Select(order =>
            {
                var details = orderDetailService.GetByOrderId(order.OrderID);
                int totalItems = details.Sum(d => d.Quantity);

                return new
                {
                    OrderID = order.OrderID,
                    OrderDate = order.OrderDate.ToString("yyyy-MM-dd"),
                    CustomerID = order.CustomerID,
                    TotalItems = totalItems
                };
            }).ToList();

            ReportGrid.ItemsSource = reportData;
        }
    }
}
