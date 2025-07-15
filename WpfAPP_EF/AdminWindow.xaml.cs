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

        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriesAndProductsIntoTreeView();
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

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count == 0) // không có sản phẩm nào được chọn 
            {
                return;
            }
            Product product = e.AddedItems[0] as Product;
            DisplayProductDetails(product);

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
            if (e.NewValue == null)
            {
                return;
            }
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item == null) {
                return;
            }
            List<Product> products = null;
            Object data = item.Tag ;
            if (data == null) { // người dùng ấnvaof nút gốc
                products = productService.GetProducts();

                
            }else if (data is Category)
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
        }

        private void LoadProductsIntoListView(Category category)
        {
            // lọc sản phẩm theo danh mục 
            var products = productService.GetProductsByCategory(category.CategoryId);
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }
    }
}
