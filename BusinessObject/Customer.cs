using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Đây là nơi truy xuất trực tiếp và tương tác với cơ sở dữ liệu, bao gồm các thao tác CRUD (Create, Read, Update, Delete) và các truy vấn phức tạp khác.
//sẽ tham chiều tới bussinessObject
namespace BusinessObject
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return Id + "\t" + Name + "\t" + Email + "\t" + Phone;
        }
    }
}
