using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewWpfApp.models
{
    public class SampleDataset
    {
        public static Dictionary<int, Category> GenerateDataset()
        {
            Dictionary<int, Category> categories = new Dictionary<int, Category>();
            Category c1 = new Category()
            {
                Id = 1,
                Name = "Yoshino"
            };
            Category c2 = new Category()
            {
                Id = 2,
                Name = "Menma"
            };
            Category c3 = new Category()
            {
                Id = 3,
                Name = "Enju"
            };
            categories.Add(c1.Id, c1);
            categories.Add(c2.Id, c2);
            categories.Add(c3.Id, c3);

            Product p1 = new Product() { Id = 1, Name = "Yoshino1", Quantity = 202, Price = 100 };
            Product p2 = new Product() { Id = 2, Name = "Yoshino2", Quantity = 201, Price = 200 };
            Product p3 = new Product() { Id = 3, Name = "Yoshino3", Quantity = 2210, Price = 212 };
            Product p4 = new Product() { Id = 4, Name = "Yoshino4", Quantity = 202, Price = 300 };
            Product p5 = new Product() { Id = 5, Name = "Yoshino5", Quantity = 20123, Price = 100 };
            Product p6 = new Product() { Id = 6, Name = "Menma1", Quantity = 201, Price = 900 };
            Product p7 = new Product() { Id = 7, Name = "Menma2", Quantity = 2012, Price = 129 };
            Product p8 = new Product() { Id = 8, Name = "Menma3", Quantity = 203, Price = 986 };
            Product p9 = new Product() { Id = 9, Name = "Menma4", Quantity = 30, Price = 287 };
            Product p10 = new Product() { Id = 10, Name = "Menma5", Quantity =10, Price = 875 };
            Product p11 = new Product() { Id = 11, Name = "Enju1", Quantity = 100, Price = 258 };
            Product p12 = new Product() { Id = 12, Name = "Enju2", Quantity = 202, Price = 1018 };
            Product p13 = new Product() { Id = 13, Name = "Enju3", Quantity = 301, Price = 1410 };
            Product p14 = new Product() { Id = 14, Name = "Enju4", Quantity = 2011, Price = 1002 };
            Product p15 = new Product() { Id = 15, Name = "Enju5", Quantity = 20111, Price = 0204 };

            c1.Products.Add(p1.Id, p1);
            c1.Products.Add(p2.Id, p2);
            c1.Products.Add(p3.Id, p3);
            c1.Products.Add(p4.Id, p4);
            c1.Products.Add(p5.Id, p5);

            c2.Products.Add(p6.Id, p6);
            c2.Products.Add(p7.Id, p7);
            c2.Products.Add(p8.Id, p8);
            c2.Products.Add(p9.Id, p9);
            c2.Products.Add(p10.Id, p10);

            c3.Products.Add(p11.Id, p11);
            c3.Products.Add(p12.Id, p12);
            c3.Products.Add(p13.Id, p13);
            c3.Products.Add(p14.Id, p14);
            c3.Products.Add(p15.Id, p15);
            return categories;
        }
    }
}
