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
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        AccountMemberService accountMemberService = new AccountMemberService();
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string oldPassword = txtOldPassword.Password.Trim();
            string newPassword = txtNewPassword.Password.Trim();
            string confirmPassword = txtConfirmPassword.Password.Trim();
            if(newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.",
                    "Lỗi xác nhận mật khẩu", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool ret = accountMemberService.ChangePassword(email, newPassword, oldPassword);
            if (ret)
            {
                MessageBox.Show("Đặt lại mật khẩu thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại. Vui lòng kiểm tra lại thông tin.",
                    "Lỗi đặt lại mật khẩu", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void txtThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
