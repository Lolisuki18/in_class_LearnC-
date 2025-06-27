using BusinessObject;
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
    /// Interaction logic for ProductWindown.xaml
    /// </summary>
    public partial class ProductWindown : Window
    {
        ProductService productService = new ProductService();
        bool isCompleted = false;// Flag to indicate if the operation is completed
        public ProductWindown()
        {
            InitializeComponent();
            isCompleted = false;
            productService.GenerateSampleDataset();
            //lvProduct.ItemsSource = null; // Reset the ItemsSource
            lvProduct.ItemsSource = productService.GetAllProducts();
            isCompleted = true;
        }
        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                Product p = new Product();
                p.Id = int.Parse(txtId.Text);
                p.Name = txtName.Text;
                p.Quantity = int.Parse(txtQuantity.Text);
                p.Price = double.Parse(txtPrice.Text);

                bool kq = productService.SaveProduct(p);
                if (kq)
                {
                    lvProduct.ItemsSource = null;// result
                    lvProduct.ItemsSource = productService.GetAllProducts();
                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : lỗi tùm lum " + ex.Message);
            }

        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                int id = int.Parse(txtId.Text);
                Product p = productService.GetProduct(id);
                if (p == null)
                {
                    return;// không tìm thấy để sửa 
                }
                //nếu tìm thấy thì thay đổi dữ liệu
                p.Name = txtName.Text;
                p.Quantity = int.Parse(txtQuantity.Text);
                p.Price = double.Parse(txtPrice.Text);
                bool kq = productService.UpdateProduct(p);
                if (kq == true)
                {
                    lvProduct.ItemsSource = null; // reset
                    lvProduct.ItemsSource = productService.GetAllProducts();
                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : lỗi cập nhật :  " + ex.Message);
            }
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isCompleted == false)
            {
                return;// vì thực hiện thao tác chưa hoàn thành nên không cho phép chọn sản phẩm
            }
            if (e.AddedItems.Count < 0)
            {
                return; //vì người dùng chưa chọn dòng nào 
            }
            //lấy product được chọn ra 
            Product p = e.AddedItems[0] as Product;
            if (p == null) return;
            txtId.Text = p.Id.ToString();
            txtName.Text = p.Name;
            txtQuantity.Text = p.Quantity.ToString();
            txtPrice.Text = p.Price.ToString(); // Format to 2 decimal places
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // luôn luôn phải xác thực có muốn xoá không ?
                MessageBoxResult result = MessageBox.Show("Bạn muốn xoá sản phẩm này hả ?",// nội dung hỏi của cửa sổ
                    "Xác nhận xoá",//Tiêu đề của cửa sổ hỏi
                    MessageBoxButton.YesNo,//Hiện thị 2 lựa chọn Yes-No cho người dùng
                    MessageBoxImage.Question);//Hiện thị biểu tượng hỏi
                if (result == MessageBoxResult.No) return; // tức là không xoá
                isCompleted = false;// Đặt cờ là chưa hoàn thành thao tác
                int id = int.Parse(txtId.Text);
                bool kq = productService.DeleteProduct(id);
                lvProduct.ItemsSource = null; // Reset the ItemsSource
                lvProduct.ItemsSource = productService.GetAllProducts();

                //Reset ô nhập liệu
                txtId.Text = " ";
                txtName.Text = " ";
                txtQuantity.Text = " ";
                txtPrice.Text = " ";

                isCompleted = true; // Đặt cờ là hoàn thành thao tác
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : lỗi xóa sản phẩm " + ex.Message);
            }
        }
    }
}
