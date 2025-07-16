using BusinessObjects_EF;
using Services_EF;
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

namespace WpfAPP_EF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        ICategoryService categoryService = new CategoryService();
        IProductService productService = new ProductService();
        bool is_load_product_completed = false;
        public AdminWindow()
        {
            InitializeComponent();
            is_load_product_completed = false;
            LoadCategoriesAndProductsIntoTreeView();
            is_load_product_completed = true;

        }

        private void LoadCategoriesAndProductsIntoTreeView()
        {
            tvCategory.Items.Clear();
            //Tạo nút gốc: 
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Phú Bổn";
            tvCategory.Items.Add(root);
            //Nạp toàn bộ danh mục lên cây
            List<Category> categories = categoryService.GetCategories();
            foreach (Category category in categories)
            {
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);
                //nạp sản phẩm vào danh mục
                List<Product> products = productService.GetProductsByCategory(category.CategoryId);
                category.Products = products;
                foreach (Product product in category.Products)
                {
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node);
                }
            }
            root.ExpandSubtree();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtId.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Chọn Danh mục: 
            TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
            if(cate_node == null)
            {
                MessageBox.Show("Chưa chọn danh mục nên không lưu được sản phẩm!!!", "Lỗi lưu sản phẩm"
                    ,MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            Category selectedCate = cate_node.Tag as Category;
            if (selectedCate == null)
            {
                MessageBox.Show("Chưa chọn danh mục nên không lưu được sản phẩm!!!", "Lỗi lưu sản phẩm"
                   , MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } 
            //Tạo sản phẩm mới
            Product product = new Product();
            product.ProductName = txtName.Text;
            product.UnitPrice =decimal.Parse(txtPrice.Text);
            product.UnitsInStock = short.Parse(txtQuantity.Text);
            product.CategoryId = selectedCate.CategoryId;
            bool ret = productService.SaveProduct(product);
            if (ret)
            {
                //Lưu thành công ==> nạp lại cây cho cate_note + product cho ListView
                //nạp lại cate_node;
                cate_node.Items.Clear();
                List<Product> products = productService.GetProductsByCategory(selectedCate.CategoryId);
                selectedCate.Products = products;
                foreach (Product product_update in selectedCate.Products)
                {
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product_update.ProductName;
                    product_node.Tag = product_update;
                    cate_node.Items.Add(product_node);
                }
                //nạp lại listview:
                is_load_product_completed = false;
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = products;
                is_load_product_completed = true;
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Chọn Danh mục: 
                TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node == null)
                {
                    MessageBox.Show("Chưa chọn danh mục nên không lưu cập nhập được sản phẩm!!!", "Lỗi cập nhập sản phẩm"
                        , MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Category selectedCate = cate_node.Tag as Category;
                if (selectedCate == null)
                {
                    MessageBox.Show("Chưa chọn danh mục nên không lưu cập nhập được sản phẩm!!!", "Lỗi cập nhập sản phẩm"
                      , MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Tạo sản phẩm mới
                Product product = new Product();
                product.ProductId = int.Parse(txtId.Text);
                product.ProductName = txtName.Text;
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.CategoryId = selectedCate.CategoryId;
                bool ret = productService.UpdateProduct(product);
                if (ret)
                {
                    //Cập nhập thành công => nạp lại giao diện
                    cate_node.Items.Clear();
                    List<Product> products = productService.GetProductsByCategory(selectedCate.CategoryId);
                    selectedCate.Products = products;
                    foreach (Product product_update in selectedCate.Products)
                    {
                        TreeViewItem product_node = new TreeViewItem();
                        product_node.Header = product_update.ProductName;
                        product_node.Tag = product_update;
                        cate_node.Items.Add(product_node);
                    }
                    //nạp lại listview:
                    is_load_product_completed = false;
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = products;
                    is_load_product_completed = true;
                }
            }
            catch (Exception ex) { 

             MessageBox.Show("Lỗi cập nhập sản phẩm : \n" + ex.Message,
                 "Lỗi cập nhập sản phẩm",MessageBoxButton.OK, MessageBoxImage.Error);   
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // xoá thì phải luôn luôn hỏi có muốn xoá hay không ?
                //Chọn Danh mục: 
                TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node == null)
                {
                    MessageBox.Show("Chưa chọn danh mục nên không lưu cập nhập được sản phẩm!!!", "Lỗi cập nhập sản phẩm"
                        , MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Category selectedCate = cate_node.Tag as Category;
                if (selectedCate == null)
                {
                    MessageBox.Show("Chưa chọn danh mục nên không lưu cập nhập được sản phẩm!!!", "Lỗi cập nhập sản phẩm"
                      , MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

              
                
                //Tự copy bên kia
                Product product = new Product();
                product.ProductId = int.Parse(txtId.Text);
                product.ProductName = txtName.Text;
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.CategoryId = selectedCate.CategoryId;
                MessageBoxResult result = MessageBox.Show($"Bạn có chắc muốn xoá sản phẩm {product.ProductName} không ?", "Xoá sản phẩm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;// không làm gì cả
                }
                int productId = int.Parse(txtId.Text);
                product.CategoryId = selectedCate.CategoryId;
                bool ret = productService.DeleteProduct(productId);
                if (ret)
                {
                    //Xoá dữ liệu trên các ô chi tiết
                    btnClear.RaiseEvent(e);
                    //Cập nhập thành công => nạp lại giao diện
                    cate_node.Items.Clear();
                    List<Product> products = productService.GetProductsByCategory(selectedCate.CategoryId);
                    selectedCate.Products = products;
                    foreach (Product product_update in selectedCate.Products)
                    {
                        TreeViewItem product_node = new TreeViewItem();
                        product_node.Header = product_update.ProductName;
                        product_node.Tag = product_update;
                        cate_node.Items.Add(product_node);
                    }
                    //nạp lại listview:
                    is_load_product_completed = false;
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = products;
                    is_load_product_completed = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi xoá sản phẩm : \n" + ex.Message,
                    "Lỗi xoá sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(is_load_product_completed == false)
            {
                return;
            }
            if (e.AddedItems.Count <= 0) return;
            Product p = e.AddedItems[0] as Product;
            txtId.Text = p.ProductId.ToString();
            txtName.Text = p.ProductName;
            txtQuantity.Text = p.UnitsInStock.ToString();
            txtPrice.Text = p.UnitPrice.ToString();

        }

        private void DisplayProductDetails(Product? product)
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

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            is_load_product_completed = false;
            if (e.NewValue == null)
            {
                return;
            }
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item == null)
            {
                return;
            }
            List<Product> products = null;
            Object data = item.Tag;
            if (data == null)
            { // người dùng ấnvaof nút gốc
                products = productService.GetProducts();


            }
            else if (data is Category)
            {//Người dùng ấn vào nút Category
                Category category = (Category)data;
                products = productService.GetProductsByCategory(category.CategoryId);
            }
            else if (data is Product)
            {//Người dùng ấn vào nút Product
                products = new List<Product>();
                products.Add((Product)data);
            }
            // nạp vào listview
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
            is_load_product_completed = true;
        }

        private void LoadProductsIntoListView(Category category)
        {
            // lọc sản phẩm theo danh mục 
            var products = productService.GetProductsByCategory(category.CategoryId);
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }

        private void menusystem_changepassword_Click(object sender, RoutedEventArgs e)
        {
            Window resetpasswordWindonw = new ResetPassword();
            resetpasswordWindonw.Show();
        }
    }
}
