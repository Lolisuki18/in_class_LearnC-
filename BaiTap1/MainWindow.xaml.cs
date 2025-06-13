using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaiTap1
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

        private void txtHeSoa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnTong_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = int.Parse(txtA.Text);
                var b = int.Parse(txtB.Text);
                int result = a + b;
                tbKetQua.Text = result.ToString();
            }
            catch {
                MessageBox.Show("Cõ lỗi xảy ra", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
               
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}