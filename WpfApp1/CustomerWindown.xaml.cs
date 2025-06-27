using Services;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for CustomerWindown.xaml
    /// </summary>
    //tham chiếu tới Bustoner Object và DataAccessLayer để thao tác với dữ liệu khách hàng
    public partial class CustomerWindown : Window
    {
        CustomerService customerService = new CustomerService();
        
        public CustomerWindown()
        {
            //khơi tạo dữ liệu thực hiện sau lệnh này -> viết sau lệnh nàu thì mới ko bị null vì InitializeComponent() sẽ khởi tạo các thành phần giao diện người dùng
            InitializeComponent();
            customerService.GenerateSampleDataset(); //khởi tạo dữ liệu mẫu
            lbCustomer.ItemsSource = customerService.GetAllCustomers(); //lấy dữ liệu từ service và gán cho ListBox
        }
    }
}
