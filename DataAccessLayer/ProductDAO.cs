using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();

        public void GenerateSampleDataset()
        {
            products.Add(new Product { Id = 1, Name = "Product Yoshino", Quantity = 10, Price = 100.0 });
            products.Add(new Product { Id = 2, Name = "Product Menma", Quantity = 20, Price = 200.0 });
            products.Add(new Product { Id = 3, Name = "Product Enju", Quantity = 30, Price = 300.0 });
            products.Add(new Product { Id = 4, Name = "Product Touka", Quantity = 10, Price = 100.0 });
            products.Add(new Product { Id = 5, Name = "Product Midori", Quantity = 20, Price = 200.0 });
            products.Add(new Product { Id = 6, Name = "Product Lavie", Quantity = 30, Price = 300.0 });
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }
        public bool SaveProduct(Product product)
        {
           Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old != null)
            {
               return false; // Product with the same ID already exists
            }
            else
            {
                products.Add(product);
            }
            return true;
        }

        //tìm sản phẩm 
        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
        //chức năng cập nhập sản phẩm,
        public bool UpdateProduct(Product product)
        {
            //Bước 1: tìm xem product muốn sửa này có tồn tại không ?
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if(old == null)
            {
                return false;
            }
            old.Name = product.Name;
            old.Quantity = product.Quantity;
            old.Price = product.Price;
            return true;
        }

        //Thêm chức năng xoá sản phẩm 
        public bool DeleteProduct(int id)
        {
            Product product = GetProduct(id); 
            if(product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }

        public bool DeleteProduct(Product product)
        {
            if(product == null)
            {
                return false;
            }
            return DeleteProduct(product.Id);
        }
    }
}
