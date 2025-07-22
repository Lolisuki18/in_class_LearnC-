using BusinessObject_EF_IO;
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

namespace WpfAPP_EF_IO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    
    public partial class MainWindow : Window
    {
        public AccountMember LoginInfor { get; set; }
        public MainWindow(AccountMember user)
        {
            InitializeComponent();
            LoginInfor = user;
            nameLogin.Content = " Xin chào [" + LoginInfor.FullName + "]" ;
        }
    }
}