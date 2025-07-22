using BusinessObject_EF_IO;
using Services_EF_IO;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfAPP_EF_IO
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    

    public partial class LoginWindow : Window
    {
        AccountMemberService accountMemberService = new AccountMemberService();
        public LoginWindow()
        {
            InitializeComponent();
            RestoreLoginInformation();
        }

        private void RestoreLoginInformation()
        {
            string file_log = "log_login.txt";
            if (File.Exists(file_log))
            {
               StreamReader sr = new StreamReader(file_log);
                string line = sr.ReadLine();
                //tách line thành mảng 3 phần tử 
                //email;password;checked
                string[] arr = line.Split(';');
                if(arr.Length == 3 && arr[2] == "True")
                {
                    txtUserName.Text = arr[0];
                    txtPassword.Text = arr[1];
                    chkSaveLogin.IsChecked = true;
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = txtUserName.Text;
                string password = txtPassword.Text;
                AccountMember user = accountMemberService.Login(email, password);
                if (user == null)
                {
                    MessageBox.Show("Đăng nhập thất bại, vui lòng kiểm tra lại thông tin đăng nhập",
                        "Đăng nhập thất bại ",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    MainWindow mw = new MainWindow(user);
                    mw.Show();
                    Close();
                    SaveLoginInformation(user, chkSaveLogin.IsChecked.Value);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ở đăng nhập" + ex.Message,
                     "Đăng nhập thất bại ",
                     MessageBoxButton.OK,
                     MessageBoxImage.Error);
            }
            
        }
        void SaveLoginInformation(AccountMember am, bool saved)
        {
            string data = am.EmailAddress + ";" + am.MemberPassword + ";" + saved;
            string file_log = "log_login.txt";
            StreamWriter sw = new StreamWriter(file_log,false,Encoding.UTF8);
            sw.WriteLine(data);
            sw.Close();
        }
    }
}
