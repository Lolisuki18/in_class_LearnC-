using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//tập hơpj các phương thức abstract để thao tác với dữ liệu khách hàng
namespace Repositories
{
    public interface ICustomerRepository
    {
        public void GenerateSampleDataset();
        public List<Customer> GetAllCustomers();
    }
}
