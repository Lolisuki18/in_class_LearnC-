using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAliasClone
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }

        public int quantity { get; set; }
        public int price { get; set; }

        override public string ToString()
        {
            return $" {id}\tName: {name}\tQuantity: {quantity}\tPrice: {price}";
        }
        public Product Clone()
        {
            return MemberwiseClone() as Product;
        }
        //MemberwiseClone() sẽ tạo ra một bản sao nông (shallow copy) của đối tượng hiện tại.
        //Điều này có nghĩa là nó sẽ sao chép các giá trị của các trường dữ liệu trong đối tượng,
        //nhưng nếu có trường nào là tham chiếu đến một đối tượng khác (ví dụ: một mảng hoặc một đối tượng phức tạp),
        //thì nó sẽ chỉ sao chép tham chiếu đó, không phải nội dung của đối tượng được tham chiếu.

        //Shallow copy là
    }

}
