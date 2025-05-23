using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Employee
    {
        #region Nhóm các thuộc tính của Employee
        //instance variable là biến thuộc về đối tượng
        private int _id;// dùng theo cơ chế tự động tăng trong database để áp dụng cơ chế tìm kiếm nhị phân 1 cách nhanh chóng
        private string _id_card;
        private string _name;
        private string _email;
        private string _phone;
        #endregion

        #region Các constructor của Employee
        //constructor là khởi tạo giá trị ban đầu cho các thuộc tính của đối tượng
        //tuỳ vào nhu cầu của mình thì viết bao nhiêu constructor cũng được
        //constructor mặc định
        public Employee()
        {
            this._id = 0;
            this._id_card = "000";
            this._name = "OBAMA";
            this._email = "obama@gmail.com";
            this._phone = "12345";
            //shift F9 để coi dòng đó có j trong chế độ debug
        }

        //constructor đẩy đủ đối số 
        public Employee(int _id, string _id_card,string _name,string _email,string _phone)
        {
            //nó ưu tiên xử lý cho local variable trước rồi mới xử lý cho instance variable
            //nên mình phải dùng this để phân biệt giữa local variable và instance variable
            //this là từ khoá chỉ đối tượng hiện tại đang gọi hàm này
            //local variable là biến cục bộ chỉ tồn tại trong hàm đó thôi được khái bao trong đối số của hàm
            this._id = _id;
            this._id_card = _id_card;
            this._name = _name;
            this._email = _email;
            this._phone = _phone;
        }
        #endregion

        #region getter setter của các properties
        //getter setter
        //id
        public int id
        {
            get { return _id; }//nếu xoá cái set đi thì chỉ có get thôi -> chỉ đọc được mà ko ghi được ->  readOnly property
            set { _id = value; }//nếu xoá cái get đi thì chỉ có cái set thôi -> chỉ ghi được mà ko đọc được -> writeOnly property
        }
        //idCard
        public string idCard
        {
            get { return _id_card; }
            set { _id_card = value; }
        }
        //name
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        //email
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        //phone
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        #endregion

        #region Nhóm các phương thức của Employess
        //hàm xuất thông tin 
        public void printInfor()
        {
            string msg = $"{id}\t{idCard}\t{name}\t{email}\t{phone}";
            Console.WriteLine(msg);
        }

        public override string ToString()
        {
            string msg = $"{id}\t{idCard}\t{name}\t{email}\t{phone}";
            return msg;
        }
        #endregion
    }
}
