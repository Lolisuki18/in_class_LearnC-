using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//thao tác trực tiếp với cơ sở dữ liệu, bao gồm các thao tác CRUD (Create, Read, Update, Delete) và các truy vấn phức tạp khác.
//sẽ tham chiều tới bussinessObject
namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customer = new List<Customer>();
        public void GenerateSampleDataset()
        {
            customer.Add(new Customer() { Id = 1, Name = "Yoshino", Phone = "123456789", Email = "Yoshino@gmail.com" });
            customer.Add(new Customer() { Id = 2, Name = "Enju", Phone = "123456789", Email = "Enju@gmail.com" });
            customer.Add(new Customer() { Id = 3, Name = "Menma", Phone = "123456789", Email = "Menma@gmail.com" });
            customer.Add(new Customer() { Id = 4, Name = "Midori", Phone = "123456789", Email = "Midori@gmail.com" });
            customer.Add(new Customer() { Id = 5, Name = "chika", Phone = "123456789", Email = "Chika@gmail.com" });

        }
        public List<Customer> GetAllCustomers()
        {
            return customer;
        }
    }
}
