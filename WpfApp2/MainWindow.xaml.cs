﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TreeViewWpfApp.models; // phải thêm dòng này
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, Category> categories = SampleDataset.GenerateDataset(); 
        public MainWindow()
        {
            InitializeComponent();
            DisplayDataIntoTreeView();
        }

        private void DisplayDataIntoTreeView()
        {
            //xoá dữ liệu cũ đi : 
            tvCategory.Items.Clear();
            //tạo nút gốc :
            TreeViewItem root = new TreeViewItem();
            root.Header = "Waifu của tôi (Anime)";

            //vòng lặp 1 : nạp toàn bộ danh mục lên Cây :
            foreach(KeyValuePair<int, Category> item in categories)
            {
                Category cate = item.Value;
                //Tạo category node:
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = cate;
                root.Items.Add(cate_node);
                //vòng lặp 2 : nạp các sản phẩm của danh mục lên cây:
                foreach(KeyValuePair<int, Product> subItem in cate.Products)
                {
                    Product p = subItem.Value;
                    //tạo Product node:
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = p;
                    //đưa p_node lên cateNode;
                    cate_node.Items.Add(product_node);
                }
            }
            tvCategory.Items.Add(root);
        }
    }
}