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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCustomerWindown_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindown customerWindown = new CustomerWindown();
            customerWindown.Show();
        }

        private void btnProductWindown_Click(object sender, RoutedEventArgs e)
        {
            ProductWindown productWindown = new ProductWindown();
            productWindown.Show();
        }
    }
}