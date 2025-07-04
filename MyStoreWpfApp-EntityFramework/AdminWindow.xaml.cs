using MyStoreWpfApp_EntityFramework.Models;
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

namespace MyStoreWpfApp_EntityFramework
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriesIntoTreeView();
        }

        private void LoadCategoriesIntoTreeView()
        {
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Bình Dương";
            tvCategory.Items.Add(root);
            //try vấn toàn bộ danh mục 
            var categories = context.Categories.ToList();
            //đưa danh mục lên treeView 
            foreach (var category in categories)
            {
                //Tạo nút danh mục
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);
                //Lọc sản phẩm theo danh mục
                var products = context.Products.Where(x => x.CategoryId == category.CategoryId).ToList();
                //nạp product vào node danh mục tương ứng 
                foreach (var product in products)
                {
                    // tạo node cho product 
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node);
                }
            }
            root.ExpandSubtree();
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null)
            {
                return;
            }
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item == null)
            {
                return;
            }
            Category category = item.Tag as Category;
            if (category == null)
            {
                return;
            }
            LoadProductsIntoListView(category);
        }

        private void LoadProductsIntoListView(Category category)
        {
            //Lọc sản phẩm theo danh mục
            var products = context.Products.Where(x => x.CategoryId == category.CategoryId).ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) // không làm gì 
            {
                return;
            }
            Product product = e.AddedItems[0] as Product;
            DisplayProductDetail(product);
        }
        void DisplayProductDetail(Product product)
        {
            if (product == null)
            {
                txtId.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";
            }
            else
            {
                txtId.Text = product.ProductId + "";
                txtName.Text = product.ProductName;
                txtQuantity.Text = product.UnitsInStock + "";
                txtPrice.Text = product.UnitPrice + "";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DisplayProductDetail(null);
            txtId.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Bước 1 : Tìm danh mục mà ta muốn lưu Product vào

                //Bước 2: tạo đối tượng product mới 

                //Bước 3 : gán giá trị cho các thuộc tính của product 

                //Bước 4: thực hiện lưu product  và cập nhập lại giao diện cho TreeView và ListView

                //-----Chi tiết--------
                TreeViewItem cate_note = tvCategory.SelectedItem as TreeViewItem;
                if (cate_note == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục để lưu sản phẩm", "Lỗi lưu sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Category category = cate_note.Tag as Category;
                if (category == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục để lưu sản phẩm", "Lỗi lưu sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Bước 2: tạo đối tượng product mới 
                Product product = new Product();
                //Bước 3 : gán giá trị cho các thuộc tính của product 
                product.ProductName = txtName.Text;
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.CategoryId = category.CategoryId;
                context.Products.Add(product);
                context.SaveChanges();
                //Bước 4: thực hiện lưu product  và cập nhập lại giao diện cho TreeView và ListView
                //4.1: Nạp lại treeView -tạo product node cho Cate note
                TreeViewItem product_node = new TreeViewItem();
                product_node.Header = product.ProductName;
                product_node.Tag = product;
                cate_note.Items.Add(product_node);
                //4.2: Nạp lại listView
                LoadProductsIntoListView(category);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {//Bước 1 : Tìm sản phẩm muốn sửa trước

                //Bước 2: Tiến hành thay đổi giá trị các thuộc tính

                //Bước 3: Thực hiện lưu thay đổi

                //Bước 4: Cập nhập lại giao diện cho TreeView và ListView



                //Bước 1 : Tìm sản phẩm muốn sửa trước
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để sửa", "Lỗi sửa sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Bước 2: Tiến hành thay đổi giá trị các thuộc tính
                product.ProductName = txtName.Text;
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                //Bước 3: Thực hiện lưu thay đổi
                context.SaveChanges();
                // Bước 4: Cập nhật lại giao diện cho TreeView và ListView
                //4.1: Nạp lại treeView -tạo product node cho Cate note
                TreeViewItem cate_note = tvCategory.SelectedItem as TreeViewItem;
                if (cate_note != null)
                {
                    Category category = cate_note.Tag as Category;
                    if (category != null)
                    {
                        //xoá toàn bộ node con cũ của cate_note
                        cate_note.Items.Clear();
                        //nạp lại Product 
                        //Lọc sản phẩm theo danh mục
                        var products = context.Products.Where(x => x.CategoryId == category.CategoryId).ToList();
                        //nạp product vào node danh mục tương ứng 
                        foreach (var product_update in products)
                        {
                            // tạo node cho product 
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_update.ProductName;
                            product_node.Tag = product_update;
                            cate_note.Items.Add(product_node);
                        }
                        //Bước 4.2 : Nạp lại listView
                        LoadProductsIntoListView(category);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try {
                //Bước 1 : tìm sản phẩm để xoá 

                //Bước 2: hỏi xác thực có muốn xoá hay không 

                //Bước 3: Tiến hành xoá nếu đồng ý 

                //bước 4: Cập nhập lại giao diện cho TreeView và listview
                //--Chi tiết--
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);

                if (product == null)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm để xoá nào có mã bằng ${id}", "Lỗi xoá sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBoxResult result = MessageBox.Show($"Bạn có chắc muốn xoá sản phẩm {product.ProductName} không ?", "Xoá sản phẩm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;// không làm gì cả
                }
                //Bước 3: Tiến hành xoá nếu đồng ý
                context.Products.Remove(product);
                context.SaveChanges();
                //Bước 4: Cập nhập lại giao diện cho TreeView và listview
                TreeViewItem cate_note = tvCategory.SelectedItem as TreeViewItem;
                if (cate_note != null)
                {
                    Category category = cate_note.Tag as Category;
                    if (category != null)
                    {
                        //xoá toàn bộ node con cũ của cate_note
                        cate_note.Items.Clear();
                        //nạp lại Product 
                        //Lọc sản phẩm theo danh mục
                        var products = context.Products.Where(x => x.CategoryId == category.CategoryId).ToList();
                        //nạp product vào node danh mục tương ứng 
                        foreach (var product_update in products)
                        {
                            // tạo node cho product 
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_update.ProductName;
                            product_node.Tag = product_update;
                            cate_note.Items.Add(product_node);
                        }
                        //Bước 4.2 : Nạp lại listView
                        LoadProductsIntoListView(category);
                        //xoá chi tiết 
                        DisplayProductDetail(null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
