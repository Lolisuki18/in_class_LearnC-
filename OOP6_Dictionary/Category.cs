using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_Dictionary
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public Dictionary<int, Product> products { get; set; }

        public Category()
        {
            //khởi tạo Dictionary trong hàm khởi tạo
            products = new Dictionary<int, Product>();
        }
        override public string ToString()
        {
            return $"{id}\t{name}";
        }
        /*Khi quản lý mọi đối tượng ta đều phải đáp ứng đầy đủ tính năng CRUD (Create, Read, Update, Delete)
         *
         */
        public void AddProduct(Product product)
        {
            //kiểm tra nếu id của Product chưa tồn tại thì thêm mới
            if(product == null)
            {
                return; // dữ liệu đầu vào null
            }
            if (products.ContainsKey(product.id)){
                return; //id đã tồn tại thì ko thêm
            } 
            //thêm mới Product vào Dictionary
            products.Add(product.id, product);
        }
        //xuất toàn bộ sản phẩm trong Category
        public void PrintAllProducts()
        {
            //dùng kiểu KeyValuePair để duyệt qua từng phần tử trong Dictionary
            foreach (KeyValuePair<int, Product> kvp in products)
            {
                Product p = kvp.Value;
                Console.WriteLine(p);   
            }
        }

        //Lọc các sản phẩm có giá từ min tới max
        public Dictionary<int, Product> FileterProductsByPrice(double min, double max) { 
            return  products
                .Where(item => item.Value.price  >= min && item.Value.price <= max)//lọc điều kiện , => attention method
                .ToDictionary<int,Product>();
        }

        //Sắp xếp sản phẩm theo đơn giá tăng dần
        public Dictionary<int,Product> SortProductByPrice()
        {
            return products.OrderBy(item => item.Value.price).ToDictionary<int,Product>(); // sắp xếp theo thứ tự tăng dần 
        }

        //Sắp xếp sản phẩm theo đơn giá tăng dần Nếu đơn giá trùng nhau thì sắp xếp theo số lượng giảm dần
        public Dictionary<int, Product> SortComplex()
        {
            //return products
            //    .OrderBy(item => item.Value.quantity)
            //    .OrderByDescending(item => item.Value.price) // khi nó chạy thì nó chạy cái ngoài rìa trước
            //    .ToDictionary<int, Product>();
            return products
                .OrderBy(item => item.Value.quantity)
                .ThenByDescending(item => item.Value.price)
                .ToDictionary<int, Product>();
        }
        //Sửa 1 sản phẩm mới

        public bool UpdateProduct(Product product)
        {
            if (product == null || products.ContainsKey(product.id) == false)
            {
                return false; // Nhập null sao sửa được, hoặc id không tồn tại trong danh sách
            }
            //cập nhật lại sản phẩm
            products[product.id] = product;
            return true;//đánh dấu là sửa thành công
        }

        //Xoá 
        public bool RemoveProduct(int id)
        {
            if(products.ContainsKey(id) == false)
            {
                return false; // ko tìm thấy id để xoá
            }
            products.Remove(id);
            return true;

        }
            
        //viết hàm xoá nhiều sản phẩm có đơn giá từ a đến b
        public Dictionary<int,Product> RemoveProductByRange(int min , int max)
        {
          foreach(KeyValuePair<int,Product> kvl in products)
            {
                if(kvl.Value.price <= max && kvl.Value.price >= min)
                {
                    products.Remove(kvl.Key);
                }
            }
            return products;
        }

    }
}
