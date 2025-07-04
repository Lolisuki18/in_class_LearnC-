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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MyStoreContext context = new MyStoreContext();

        public LoginWindow()
        {
            InitializeComponent();
            ChangeBackground();
        }

        private void ChangeBackground()
        {
           // đổi màu nền cho nút thoát 
           LinearGradientBrush brush = new LinearGradientBrush();
        brush.GradientStops.Add(new GradientStop(Colors.Magenta, 0.0));
        brush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.5));
        brush.GradientStops.Add(new GradientStop(Colors.Cyan, 1.0));
            btnThoat.Background = brush;

            //Đổi màu nền cho nút đăng nhập 
            RadialGradientBrush brush1 = new RadialGradientBrush();
            brush1.GradientOrigin = new Point(0.5, 0.75);// ví dụ tâm hình tròn
            brush1.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            brush1.GradientStops.Add(new GradientStop(Colors.White, 0.5));
            brush1.GradientStops.Add(new GradientStop(Colors.Blue, 1.0));

            btnDangNhap.Background = brush1;
        }

        private void  btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pwd = txtPassword.Password.Trim();
            AccountMember? am = context.AccountMembers.FirstOrDefault(a => a.EmailAddress == email && a.MemberPassword == pwd);
            if(am == null)
            {
                MessageBox.Show("Đăng nhập thất bại- vui lòng kiểm tra lại account" ,"Thông báo",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            else
            {
                if(am.MemberRole == 1)
                {
                    MessageBox.Show("Đăng nhập Admin thành công", "Success Login", MessageBoxButton.OK, MessageBoxImage.Information);
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Close();
                    return;
                }
                else if (am.MemberRole == 2)
                {
                    MessageBox.Show("Đăng nhập Staff thành công", "Success Login", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else if (am.MemberRole == 3)
                {
                    MessageBox.Show("Đăng nhập Member thành công", "Success Login", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
        }
    }
}
