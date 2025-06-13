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

namespace BaiTap5_ListWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> dsDuLieu = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
           //x lá giá trị muốn đưa vào cuối danh sách
           int x = int.Parse(txtGiaTri.Text);
            //thêm x vào danh sách
            dsDuLieu.Add(x);
            HienThiDanhSach();
            txtGiaTri.Text = "";
        }

        //hàm để hiện thị danh sách lên giao diện
        void HienThiDanhSach()
        {
            stDuLieu.Items.Clear();
            for (int i = 0; i < dsDuLieu.Count; i++)
            {
                int x = dsDuLieu[i];
                stDuLieu.Items.Add(x);
            }
        }

        //Hàm cho nút chèn
        private void BtnChen_Click(object sender, RoutedEventArgs e)
        {
          //x là giá trị muốn chèn
          int x = int.Parse(txtGiaTriChen.Text);
            //vt mà ta chèn x vào
            int vt = int.Parse(txtViTriChen.Text);
            //chèn x vào vị trí vt
            dsDuLieu.Insert(vt, x);
            //hiện thị lại danh sách
            HienThiDanhSach();
            txtViTriChen.Text = "";
            txtGiaTriChen.Text = "";
        }

        //Hàm cho nút sắp xếp tăng
        private void BtnSapXepTang_Click(object sender, RoutedEventArgs e)
        {
            //gọi lệnh sắp xếp danh sách
            dsDuLieu.Sort();
            //hiện thị lại danh sách
            HienThiDanhSach();
        }

        //Hàm cho nút sắp xếp giảm
        private void BtnSapXepGiam_Click(object sender, RoutedEventArgs e)
        {
            //sắp xếp tăng dần
            dsDuLieu.Sort();
            //đạo ngược lại danh sách
            dsDuLieu.Reverse();
            //hiện thị lại danh sách
            HienThiDanhSach();
        }

        //Hàm cho xoá 1 phần tử 
        private void BtnXoa1PhanTu_Click(object sender, RoutedEventArgs e)
        {
            if(stDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Phải có phần tử mới xoá được","Thông Báo lỗi",
                    MessageBoxButton.OK);
                return;
            }
            //Xoá phần từ tại vị trí đã chọn
            dsDuLieu.RemoveAt(stDuLieu.SelectedIndex);
            HienThiDanhSach();
        }

        //Hàm dùng để xoá nhiều phần tử
        private void BtnXoaNhieuPhanTu_Click(object sender, RoutedEventArgs e)
        {
            if (stDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Phải có phần tử mới xoá được", "Thông Báo lỗi",
                    MessageBoxButton.OK);
                return;
            }
            //vòng lặp lấy các phần tử được chọn trên giao diẹn
            while(stDuLieu.SelectedItems.Count > 0)
            {
                //lấy phần tử đầu tiên ra
                int data = (int)stDuLieu.SelectedItems[0];
                //xoá khỏi danh sách
                dsDuLieu.Remove(data);
                //xoá dư liệu trên giaop diện
                stDuLieu.Items.Remove(data);
            }
        }
        private void BtnXoaToanBoPhanTu_Click(object sender, RoutedEventArgs e)
        {
            dsDuLieu.Clear();//xoá toàn bộ dữ liệu
            //hiện thị lại danh sách
            HienThiDanhSach();
        }
    }
}