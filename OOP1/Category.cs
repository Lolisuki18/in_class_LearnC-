using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Category
    //internal class là tất cả các lớp trong 1 namespace có thể truy xuất được -> mình sửa hết internal thành public -> để nhiều nơi có thể xài
    {
        public int id;
        public string name;
        public void printInfor()
        {
            string msg = $"{id}\t{name}";
            Console.WriteLine(msg);
        }
    }
}
