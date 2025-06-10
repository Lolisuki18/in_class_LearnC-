using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQToObjectModelClass
{
    public class ListProduct
    {
        List<Product> products;

        public ListProduct()
        {
            products = new List<Product>();
        }

        public void gen_products()
        {
            products.Add(new Product()
            {
                id = 1,
                name = "P1",
                quantity = 10,
                price = 1000
            });
            products.Add(new Product()
            {
                id = 2,
                name = "P2",
                quantity = 20,
                price = 2000
            });
            products.Add(new Product()
            {
                id = 3,
                name = "P3",
                quantity = 15,
                price = 1500
            });
            products.Add(new Product()
            {
                id = 4,
                name = "P4",
                quantity = 25,
                price = 2500
            });
            products.Add(new Product()
            {
                id = 5,
                name = "P5",
                quantity = 30,
                price = 3000
            });
            products.Add(new Product()
            {
                id = 6,
                name = "P6",
                quantity = 12,
                price = 1200
            });
            products.Add(new Product()
            {
                id = 7,
                name = "P7",
                quantity = 18,
                price = 1800
            });
            products.Add(new Product()
            {
                id = 8,
                name = "P8",
                quantity = 22,
                price = 2200
            });
            products.Add(new Product()
            {
                id = 9,
                name = "P9",
                quantity = 17,
                price = 1700
            });
            products.Add(new Product()
            {
                id = 10,
                name = "P10",
                quantity = 28,
                price = 2800
            });

        }

        public List<Product> FilterProductByPrice(double price1, double price2)
        {
            var result = from p in products
                         where p.price >= price1 && p.price <= price2
                         select p;

            return result.ToList();
        }

        public List<Product> FilterProductByPrice2(double price1, double price2)
        {
            var result = products.Where(p => p.price >= price1 && p.price <= price2);
            return result.ToList();
        }

        public List<Product> SortProductByPriceAsc()
        {
            var result = products.OrderBy(p => p.price);

            return result.ToList();
        }

        public List<Product> SortProductByPriceAsc2()
        {
            //var result = from p in products.OrderBy(p => p.price);
            var result = from p in products
                         orderby p.price ascending
                         select p;
            return result.ToList();
        }

        //
        //Sắp xếp sản phẩm theo đơn giá giảm dần
        public List<Product> SortProductByPriceDes()
        {
            var result = products.OrderByDescending(p => p.price);

            return result.ToList();
        }

        public List<Product> SortProductByPriceDes2()
        {
            var result = from p in products
                         orderby p.price descending
                         select p;
            return result.ToList();
        }

        public double SumOfValue()
        {
            return products.Sum(p => p.price * p.quantity);
        }

        public Product ProductById(int id)
        {
            
            var result = products.FirstOrDefault(p => p.id == id);//nếu tìm thấy trả về đối tượng đầu tiên tìm thấy 
            //còn ko là trả về null
            return result;
        }

        public List<Product> TopNProduct(int n)
        {
            var result = from p in products
                         orderby p.price * p.quantity descending
                         select p;
            //var result2 = result.ToArray();
            //var result_final = new List<Product>();
            //for(int i = 0; i <= n; i++)
            //{
            //    result_final.Add(result2[i]);
            //}
            //return result_final;

            //var result = products.OrderByDescending(p => p.price * p.quantity).Take(n);
            return result.Take(n).ToList(); //Lấy n sản phẩm đầu tiên trong danh sách đã sắp xếp
        }
    }
}
