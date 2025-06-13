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

namespace BaiTap4_XuLyChuoiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KhoaControl(true);
        }
        /*
         * Hàm để khoá controls
         */
        void KhoaControl(bool b)
        {
            btnDemSoKTHoa.IsEnabled = !b;
            btnDemSoTu.IsEnabled = !b;
            btnInChuHoa.IsEnabled = !b;
            btnInChuThuong.IsEnabled = !b;
            btnInNguyenAmPhuAm.IsEnabled = !b;
            btnInSoTuTrenMoiDong.IsEnabled = !b;
            btnSoKTThuong.IsEnabled = !b;
        }

        private void BtnNhap_Click(object sender, RoutedEventArgs e)
        {
            KhoaControl(false);
            txtNhap.Text = "";
            txtXuat.Text = "";
            txtNhap.Focus();
        }
        // sự kiện đưa chuỗi về in hoa
        private void BtnInChuHoa_Click(object sender, RoutedEventArgs e)
        {
            txtXuat.Text = txtNhap.Text.ToUpper();
        }
        //sự kiện đưa chuỗi về in thường
        private void BtnInChuThuong_Click(object sender, RoutedEventArgs e)
        {
            txtXuat.Text = txtNhap.Text.ToLower();
        }

        //sự kiện đếm số ký tự in thường
        private void BtnSoKTThuong_Click(object sender, RoutedEventArgs e)
        {
            int soKtInThuong = txtNhap.Text.Count(c => char.IsLower(c));
            txtXuat.Text = "Có " + soKtInThuong + " ký tự in thường trong chuỗi.";
        }

        //sự kiện đếm số ký tự in hoa
        private void BtnDemSoKTHoa_Click(object sender, RoutedEventArgs e)
        {
            int soKtInHoa = txtNhap.Text.Count(c => char.IsUpper(c));
            txtXuat.Text = "Có " + soKtInHoa + " ký tự in hoa trong chuỗi.";
        }

        //SỰ kiện tách từ trên từng dòng
        private void BtnInSoTuTrenMoiDong_Click(object sender, RoutedEventArgs e)
        {
            string[] arr = txtNhap.Text.Split(' ');
            txtXuat.Text = "";
            foreach (var word in arr)
            {
                txtXuat.AppendText(word + "\n");
            }

        }

        //sự kiện đếm số từ trong chuỗi
        private void BtnDemSoTu_Click(object sender, RoutedEventArgs e)
        {
            string[] arr = txtNhap.Text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            txtXuat.Text = "Có" + arr.Length + " từ trong chuỗi.";
        }
        //sự kiện đếm nguyên âm phụ âm 
        private void BtnInNguyenAmPhuAm_Click(object sender, RoutedEventArgs e)
        {
            char[] arr = txtNhap.Text.Where(c => char.IsLetter(c)).Select(c => char.ToLower(c)).ToArray();

            char[] arrNA = { 'a', 'ă', 'â', 'e', 'ê', 'i', 'o', 'ô', 'ơ', 'u', 'ư', 'y' };
            int soNA = arr.Count(c => arrNA.Contains(c));
            int soPA = arr.Length - soNA;
            txtXuat.Text = "Có " + soNA + " nguyên âm và " + soPA + " phụ âm trong chuỗi.";
        }

        //sự kiện kết thúc chương trình
        private void BtnKetThuc_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}