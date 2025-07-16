using BusinessObjects_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EF
{
    public class ProductDAO
    {
        MyStoreContext context = new MyStoreContext();
        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public List<Product> GetProductsByCategory(int cateId)
        {
            return context.Products.Where(p => p.CategoryId == cateId).ToList();
        }

        public bool SaveProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }
            Product p_existing = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (p_existing != null)
            { // bị trùng mã
                return false;
            }
            context.Products.Add(product);
            int ret = context.SaveChanges(); // nó sẽ trả về số dòng bị ảnh hưởng
            return ret > 0;
        }

        public bool UpdateProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }
            Product p_existing = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (p_existing == null)
            {//Nếu ko tồn tại thì không cho sửa
                return false;
            }
            p_existing.ProductName = product.ProductName;
            p_existing.UnitPrice = product.UnitPrice;
            p_existing.UnitsInStock = product.UnitsInStock;
            p_existing.CategoryId = product.CategoryId;
            int ret = context.SaveChanges();
            return ret > 0;
        }

        public bool DeleteProduct(int product)
        {
            if (product == null)
            {
                return false;
            }
            Product p_existing = context.Products.FirstOrDefault(p => p.ProductId == product);
            if (p_existing != null)
            {//Nếu tồn tại thì xoá
               context.Products.Remove(p_existing);
                int ret = context.SaveChanges();    
                return ret > 0;
            }
            return false;
        }
    }
}
